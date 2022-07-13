using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ContenidoMultimedia
    {
        private const string carpetaDeArchivosJSON = "Multimedia/";
        private static List<ContenidoMultimedia> archivosConContenidoMultimediaPersonalizado;
        private static ContenidoMultimedia contenidoMultimediaPrincipal;
        private ListadoDeArchivos<Multimedia> listaMultimedia;
        private string nombreListaMultimedia;

        static ContenidoMultimedia()
        {
            ContenidoMultimedia.contenidoMultimediaPrincipal = new ContenidoMultimedia("ListaMultimedia");
        }

        public ContenidoMultimedia(string nombreListaMultimedia)
        {
            this.NombreListaMultimedia = nombreListaMultimedia;
            this.listaMultimedia = new ListadoDeArchivos<Multimedia>(this.RutaRelativaListaMultimedia);
        }

        [Browsable(false)]
        public static event Action<string> OnError
        {
            add
            {
                ListadoDeArchivos<Multimedia>.OnError += value;
            }
            remove
            {
                ListadoDeArchivos<Multimedia>.OnError -= value;
            }
        }

        [Browsable(false)]
        public static ContenidoMultimedia ContenidoMultimediaPrincipal
        {
            get
            {
                return ContenidoMultimedia.contenidoMultimediaPrincipal;
            }
        }

        [Browsable(false)]
        public static List<ContenidoMultimedia> ArchivosConContenidoMultimediaPersonalizado
        {
            get
            {
                if(ContenidoMultimedia.archivosConContenidoMultimediaPersonalizado == null)
                {
                    ContenidoMultimedia.archivosConContenidoMultimediaPersonalizado = new List<ContenidoMultimedia>();
                }
                return ContenidoMultimedia.archivosConContenidoMultimediaPersonalizado;
            }
        }

        public string NombreListaMultimedia
        {
            get
            {
                if(string.IsNullOrWhiteSpace(this.nombreListaMultimedia))
                {
                    this.nombreListaMultimedia = "Lista sin nombre";
                }

                return this.nombreListaMultimedia;
            }
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new NullReferenceException("El nombre de la lista no puede estar vacio");
                }

                if(!value.EsCadenaAlfanumericaConEspacios())
                {
                    throw new DatoInvalidoException("El nombre de la lista solo puede contener letras, números y espacios.");
                }

                if(ContenidoMultimedia.ExisteNombreDeListaMultimediaPersonalizada(value))
                {
                    throw new DatoInvalidoException($"El nombre '{value}' ya existe!");
                }

                this.nombreListaMultimedia = value;
            }
        }

        [Browsable(false)]
        private string RutaRelativaListaMultimedia
        {
            get
            {
                return ContenidoMultimedia.carpetaDeArchivosJSON + this.NombreListaMultimedia;
            }
        }

        [Browsable(false)]
        private string RutaAbsolutaListaMultimedia
        {
            get
            {
                return SerializadorJSON<ContenidoMultimedia>.ObtenerRutaAbsolutaDelArchivoYAgregarExtensionJSON(this.RutaRelativaListaMultimedia);
            }
        }

        [Browsable(false)]
        public string[] RutasAbsolutasDeArchivosMultimediaEnContenidoMultimediaPersonalizado
        {
            get
            {
                List<string> rutasAbsolutas = new List<string>();

                foreach (Multimedia archivoMultimedia in this.ArchivosEnListaMultimedia)
                {
                    rutasAbsolutas.Add(archivoMultimedia.RutaAbsolutaDelArchivo);
                }
                return rutasAbsolutas.ToArray();               
            }
        }

        [Browsable(false)]
        public List<Multimedia> ArchivosEnListaMultimedia
        {
            get
            {
                return this.ListaMultimedia.Archivos;
            }
        }

        [Browsable(false)]
        public ListadoDeArchivos<Multimedia> ListaMultimedia
        {
            get
            {
                return this.listaMultimedia;
            }
        }    

        /// <summary>
        /// Agrega un archivo en la lista de archivos, a partir de una ruta completa valida.
        /// </summary>
        /// <param name="rutaAbsolutaDelArchivo">Ruta completa del archivo.</param>
        private void AgregarArchivoAPartirDeUnaRutaAbsoluta(string rutaAbsolutaDelArchivo)
        {       
            this.ListaMultimedia.AgregarArchivo(new Multimedia(rutaAbsolutaDelArchivo));    
        }

        /// <summary>
        /// Evalua cada archivo multimedia y su ruta de archivo, y aquellas rutas que sean validas 
        /// son agregadas a la lista existente de archivos. 
        /// Luego guarda los cambios en un archivo.
        /// </summary>
        /// <param name="archivosMultimedia">Archivos multimedia cuyas rutas seran guardadas.</param>
        /// <exception cref="Exception">Rutas invalidas.</exception>
        public void ExtenderListaDeArchivosYGuardarCambios(List<Multimedia> archivosMultimedia)
        {
            if(archivosMultimedia != null)
            {
                List<string> rutasAbsolutas = new List<string>();

                foreach(Multimedia archivoMultimedia in archivosMultimedia)
                {
                    rutasAbsolutas.Add(archivoMultimedia.RutaAbsolutaDelArchivo);
                }

                try
                {
                    this.ExtenderListaDeArchivosYGuardarCambios(rutasAbsolutas.ToArray());
                }
                catch(Exception)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Evalua cada ruta de archivo, y aquellas que sean validas 
        /// son agregadas a la lista existente de archivos. 
        /// Luego guarda los cambios en un archivo.
        /// </summary>
        /// <param name="rutasAbsolutas">Lista de rutas.</param>
        /// <exception cref="DatoInvalidoException">Rutas invalidas.</exception>
        public void ExtenderListaDeArchivosYGuardarCambios(string[] rutasAbsolutas)
        {
            List<string> rutasInvalidas = new List<string>();

            if (rutasAbsolutas != null)
            {
                for (int i = 0; i < rutasAbsolutas.Length; i++)
                {
                    try
                    {
                        this.AgregarArchivoAPartirDeUnaRutaAbsoluta(Archivo.ValidarRutaAbsolutaDeArchivo(rutasAbsolutas[i]));
                    }
                    catch(Exception)
                    {
                        rutasInvalidas.Add(rutasAbsolutas[i]);
                    }
                }

                this.ListaMultimedia.GuardarCambiosEnListaDeArchivos();

                if(rutasInvalidas.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"No se han podido guardar {rutasInvalidas.Count} archivos de {rutasAbsolutas.Length} archivos.");
                    sb.AppendLine("Archivos que no se han podido cargar:");

                    foreach(string rutaInvalida in rutasInvalidas)
                    {
                        sb.AppendLine(rutaInvalida);
                    }

                    throw new DatoInvalidoException(sb.ToString());
                }
            }
        }

        /// <summary>
        /// Agrega un archivo a la lista a partir de su ruta completa.
        /// </summary>
        /// <param name="rutaAbsoluta">Ruta completa del archivo</param>
        public void AgregarArchivoAPartirDeUnaRutaAbsolutaYGuardarCambios(string rutaAbsoluta)
        {
            this.AgregarArchivoAPartirDeUnaRutaAbsoluta(Archivo.ValidarRutaAbsolutaDeArchivo(rutaAbsoluta));

            this.ListaMultimedia.GuardarCambiosEnListaDeArchivos();
        }

        /// <summary>
        /// Obtiene todos los archivos con contenido multimedia personalizado que se encuentran en el directorio 'Multimedia'.
        /// </summary>
        /// <returns>Una lista que contiene todos los archivos con contenido multimedia personalizado. 
        /// En caso de error o no encontrar archivos, retorna una lista vacia.</returns>
        public static List<ContenidoMultimedia> ObtenerArchivosConContenidoMultimediaPersonalizado()
        {
            ContenidoMultimedia.ArchivosConContenidoMultimediaPersonalizado.Clear();

            List<string> rutasAbsolutas = Archivo.ObtenerTodasLasRutasAbsolutasDeLosArchivosDeUnDirectorio(Archivo.RutaAbsolutaDelDirectorioBase + ContenidoMultimedia.carpetaDeArchivosJSON);

            rutasAbsolutas = rutasAbsolutas.Where((archivo) => !archivo.Contains(ContenidoMultimedia.ContenidoMultimediaPrincipal.NombreListaMultimedia)).ToList();

            for(int i = 0; i < rutasAbsolutas.Count; i++)
            {
                try
                {
                    ContenidoMultimedia.ArchivosConContenidoMultimediaPersonalizado.Add(new ContenidoMultimedia(Archivo.ObtenerNombreDelArchivoAPartirDeSuRutaAbsoluta(rutasAbsolutas[i])));
                }
                catch { }
            }

            return ContenidoMultimedia.ArchivosConContenidoMultimediaPersonalizado;    
        }

        /// <summary>
        /// Evalua si el nombre de una lista ya existe en el directorio.
        /// </summary>
        /// <param name="nombreDeListaMultimediaPersonalizada">Nombre a evaluar.</param>
        /// <returns>True si ya existe, caso contrario False.</returns>
        internal static bool ExisteNombreDeListaMultimediaPersonalizada(string nombreDeListaMultimediaPersonalizada)
        {
            for(int i = 0; i < ContenidoMultimedia.ArchivosConContenidoMultimediaPersonalizado.Count; i++)
            {
                if(ContenidoMultimedia.ArchivosConContenidoMultimediaPersonalizado[i].NombreListaMultimedia == nombreDeListaMultimediaPersonalizada)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Evalua si una ruta ya esta cargada.
        /// </summary>
        /// <param name="contenidoMultimedia">Contenido cuya ruta sera evaluada.</param>
        /// <returns>True si existe, False si no existe.</returns>
        private static bool ExisteArchivoEnListaDeArchivosPersonalizados(ContenidoMultimedia contenidoMultimedia)
        {
            for (int i = 0; i < ContenidoMultimedia.ArchivosConContenidoMultimediaPersonalizado.Count; i++)
            {
                if (ContenidoMultimedia.ArchivosConContenidoMultimediaPersonalizado[i].RutaRelativaListaMultimedia == contenidoMultimedia.RutaRelativaListaMultimedia)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Agrega un archivo contenido multimedia a la lista de archivos con contenido multimedia, y guarda el contenido en un archivo.
        /// </summary>
        /// <param name="contenidoMultimedia">Contenido que se agregara.</param>
        /// <exception cref="DatoInvalidoException">Contenido invalido.</exception>
        /// <exception cref="NullReferenceException">Contenido NULL.</exception>
        public static void AgregarContenidoMultimediaPersonalizadoAListaYGuardar(ContenidoMultimedia contenidoMultimedia)
        {
            ContenidoMultimedia.AgregarContenidoMultimediaPersonalizadoALista(contenidoMultimedia);

            contenidoMultimedia.ListaMultimedia.GuardarCambiosEnListaDeArchivos();         
        }

        /// <summary>
        /// Agrega un archivo contenido multimedia a la lista de archivos con contenido multimedia (NO guarda el contenido).
        /// </summary>
        /// <param name="contenidoMultimedia">Contenido que se agregara.</param>
        /// <exception cref="DatoInvalidoException">Contenido invalido.</exception>
        /// <exception cref="NullReferenceException">Contenido NULL.</exception>
        public static void AgregarContenidoMultimediaPersonalizadoALista(ContenidoMultimedia contenidoMultimedia)
        {
            if (contenidoMultimedia != null)
            {
                if (!ContenidoMultimedia.ExisteArchivoEnListaDeArchivosPersonalizados(contenidoMultimedia))
                {
                    ContenidoMultimedia.ArchivosConContenidoMultimediaPersonalizado.Add(contenidoMultimedia);

                    return;
                }
                throw new DatoInvalidoException($"El contenido {contenidoMultimedia.NombreListaMultimedia} ya existe en la ruta '{contenidoMultimedia.RutaAbsolutaListaMultimedia}'.");
            }
            throw new NullReferenceException("El contenido que se intento agregar esta vacio.");
        }

        /// <summary>
        /// Elimina el archivo con contenido multimedia personalizado de la lista del sistema y
        /// tambien lo elimina del directorio.
        /// </summary>
        /// <param name="contenidoMultimedia">Contenido a eliminar</param>
        /// <returns>True si lo elimino, caso contrario False.</returns>
        public static bool EliminarArchivoConContenidoMultimediaPersonalizado(ContenidoMultimedia contenidoMultimedia)
        {
            if(contenidoMultimedia != null && ContenidoMultimedia.ArchivosConContenidoMultimediaPersonalizado.Remove(contenidoMultimedia))
            {
                try
                {
                    Archivo.EliminarArchivoDeDirectorio(contenidoMultimedia.RutaAbsolutaListaMultimedia);

                    return true;
                }
                catch (Exception) { }
            }
            return false;
        }

        /// <summary>
        /// Elimina todos los archivos con contenido multimedia personalizado, 
        /// tanto de la lista del sistema como del directorio.
        /// </summary>
        /// <exception cref="DatoInvalidoException">Archivo/s con ruta invalida.</exception>
        public static void EliminarTodosLosArchivosConContenidoMultimediaPersonalizado()
        {
            List<string> rutasAbsolutasInvalidas = new List<string>();
            int cantidadDeArchivosAEliminar = ContenidoMultimedia.ArchivosConContenidoMultimediaPersonalizado.Count;

            for(int i = 0; i < ContenidoMultimedia.ArchivosConContenidoMultimediaPersonalizado.Count; i++)
            {
                try
                {
                    Archivo.EliminarArchivoDeDirectorio(ContenidoMultimedia.ArchivosConContenidoMultimediaPersonalizado[i].RutaAbsolutaListaMultimedia);
                }
                catch(Exception)
                {
                    rutasAbsolutasInvalidas.Add(ContenidoMultimedia.ArchivosConContenidoMultimediaPersonalizado[i].RutaAbsolutaListaMultimedia);
                }
            }

            ContenidoMultimedia.ArchivosConContenidoMultimediaPersonalizado.Clear();

            if(rutasAbsolutasInvalidas.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"No se han podido eliminar {rutasAbsolutasInvalidas.Count} de {cantidadDeArchivosAEliminar} archivos");
                sb.AppendLine("Archivos que no se eliminaron:");

                foreach(string rutaAbsolutaInvalida in rutasAbsolutasInvalidas)
                {
                    sb.AppendLine($"{rutaAbsolutaInvalida}");
                }
                throw new DatoInvalidoException(sb.ToString());
            }
        }
    }
}
