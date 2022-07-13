using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal static class Archivo
    {
        private static char caracterSeparadorDeDirectorios;
        private static string rutaAbsolutaDelDirectorioBase;

        static Archivo()
        {
            Archivo.caracterSeparadorDeDirectorios = Path.DirectorySeparatorChar;
            Archivo.rutaAbsolutaDelDirectorioBase = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Reproductor_Multimedia/");
        }

        internal static char CaracterSeparadorDeDirectorios { get => Archivo.caracterSeparadorDeDirectorios; }

        internal static string RutaAbsolutaDelDirectorioBase { get => Archivo.rutaAbsolutaDelDirectorioBase; }

        /// <summary>
        /// Valida que la ruta del archivo existe.
        /// </summary>
        /// <param name="rutaAbsolutaDeArchivo">Ruta del archivo que se validara.</param>
        /// <returns>La ruta valida de un archivo. Si la ruta no existe, lanza una excepcion.</returns>
        /// <exception cref="FileNotFoundException">La ruta no existe.</exception>
        internal static string ValidarRutaAbsolutaDeArchivo(string rutaAbsolutaDeArchivo)
        {
            if (!string.IsNullOrWhiteSpace(rutaAbsolutaDeArchivo) && File.Exists(rutaAbsolutaDeArchivo))
            {
                return rutaAbsolutaDeArchivo;
            }
            throw new FileNotFoundException($"La ruta del archivo '{rutaAbsolutaDeArchivo}' no existe.");
        }

        /// <summary>
        /// Obtiene el nombre de un archivo, a partir de la ruta completa del mismo.
        /// </summary>
        /// <param name="rutaAbsolutaDeArchivo">Ruta completa del archivo.</param>
        /// <returns>Nombre del archivo.</returns>
        /// <exception cref="NullReferenceException">Ruta archivo esta vacia.</exception>
        internal static string ObtenerNombreDelArchivoAPartirDeSuRutaAbsoluta(string rutaAbsolutaDeArchivo)
        {
            if (!string.IsNullOrWhiteSpace(rutaAbsolutaDeArchivo) && rutaAbsolutaDeArchivo.Contains('.') && rutaAbsolutaDeArchivo.Contains(Archivo.CaracterSeparadorDeDirectorios))
            {
                string rutaCompletaDelArchivoSinExtension = rutaAbsolutaDeArchivo.Substring(0, rutaAbsolutaDeArchivo.LastIndexOf('.'));

                string nombreDelArchivoSinRutaCompleta = rutaCompletaDelArchivoSinExtension.Substring(rutaCompletaDelArchivoSinExtension.LastIndexOf(Archivo.CaracterSeparadorDeDirectorios) + 1);

                return nombreDelArchivoSinRutaCompleta;
            }
            throw new NullReferenceException($"La ruta '{rutaAbsolutaDeArchivo}' es invalida, y no se pudo obtener el nombre del archivo.");
        }

        /// <summary>
        /// Obtiene la ruta completa del archivo (SIN EXTENSION), al combinar la ruta relativa con la ruta Base del proyecto.
        /// </summary>
        /// <param name="rutaRelativaDelArchivo">Ruta relativa del archivo.</param>
        /// <returns>La ruta completa del archivo (SIN EXTENSION).</returns>
        /// <exception cref="ArgumentNullException">Ruta NULL</exception>
        internal static string ObtenerRutaAbsolutaDelArchivo(string rutaRelativaDelArchivo)
        {
            string rutaAbsolutaDeArchivo;

            if (!string.IsNullOrWhiteSpace(rutaRelativaDelArchivo))
            {
                rutaAbsolutaDeArchivo = Path.Combine(Archivo.RutaAbsolutaDelDirectorioBase, rutaRelativaDelArchivo);

                return Archivo.AjustarCaracterSeparadorDeDirectoriosEnRuta(rutaAbsolutaDeArchivo);
            }
            throw new NullReferenceException("Ruta NULL");
        }

        /// <summary>
        /// Adecua el caracter separador de directorios en la ruta recibida por parametro.
        /// </summary>
        /// <param name="rutaAbsoluta">Ruta completa</param>
        /// <returns>Una ruta con el caracter separador de directorios adecuado al sistema.</returns>
        private static string AjustarCaracterSeparadorDeDirectoriosEnRuta(string rutaAbsoluta)
        {            
            rutaAbsoluta = rutaAbsoluta.Replace('\\', Archivo.CaracterSeparadorDeDirectorios);
            rutaAbsoluta = rutaAbsoluta.Replace('/', Archivo.CaracterSeparadorDeDirectorios);

            return rutaAbsoluta;
        }

        /// <summary>
        /// Obtiene las rutas absolutas de todos archivos que se encuentran en la ruta del directorio recibido por parametro.
        /// </summary>
        /// <param name="rutaAbsolutaDeDirectorio">Ruta de directorio.</param>
        /// <returns>Una lista que contiene todas las rutas de los archivos que se encuentran en la ruta del directorio recibido por parametro.
        /// Si ocurre un error o no encuentra archivos retorna una lista vacia.</returns>
        internal static List<string> ObtenerTodasLasRutasAbsolutasDeLosArchivosDeUnDirectorio(string rutaAbsolutaDeDirectorio)
        {
            List<string> rutasAbsolutasDeArchivos = new List<string>();
            string rutaAbsolutaValidaDeDirectorio;

            try
            {
                if (!string.IsNullOrWhiteSpace(rutaAbsolutaDeDirectorio) && 
                    Directory.Exists((rutaAbsolutaValidaDeDirectorio = Archivo.AjustarCaracterSeparadorDeDirectoriosEnRuta(rutaAbsolutaDeDirectorio))))
                {
                    rutasAbsolutasDeArchivos.AddRange(Directory.GetFiles(rutaAbsolutaValidaDeDirectorio).ToList());        
                }
            }
            catch (Exception) { }
 
            return rutasAbsolutasDeArchivos;
        }

        /// <summary>
        /// Elimina un archivo.
        /// </summary>
        /// <param name="rutaAbsolutaDeArchivo">Ruta completa del archivo que se eliminara.</param>
        /// <exception cref="Exception">Error al eliminar.</exception>
        internal static void EliminarArchivoDeDirectorio(string rutaAbsolutaDeArchivo)
        {
            if(!string.IsNullOrWhiteSpace(rutaAbsolutaDeArchivo) && File.Exists(rutaAbsolutaDeArchivo))
            {
                try
                {
                    File.Delete(rutaAbsolutaDeArchivo);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
