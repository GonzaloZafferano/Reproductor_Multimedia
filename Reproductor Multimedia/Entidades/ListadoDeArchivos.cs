using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ListadoDeArchivos<T> where T : class
    {
        internal static event Action<string> OnError;

        private List<T> archivos;
        private string rutaRelativaArchivoJSON;

        public List<T> Archivos { get => this.archivos; }

        /// <summary>
        /// Constructor de la clase Lista. Al utilizar este constructor, se intenta leer el archivo recibido por parametro
        /// para cargar la lista. Si el archivo no se puede leer o no existe, la lista se crea vacia.
        /// </summary>
        /// <param name="rutaRelativaArchivoJSON"></param>
        public ListadoDeArchivos(string rutaRelativaArchivoJSON)
        {
            this.rutaRelativaArchivoJSON = rutaRelativaArchivoJSON;

            this.archivos = this.LeerListaDeArchivos();
        }

        /// <summary>
        /// Valida que el objeto no sea null y que no este repetido en la lista. 
        /// Esto solo valida la referencia del objeto, no impide que el usuario quiera agregar 
        /// varias veces el mismo contenido en distintos objetos.
        /// Luego de validar, lo agrega a la lista.
        /// </summary>
        /// <param name="elemento">Elemento a agregar</param>
        /// <returns>True si lo pudo guardar, caso contrario False.</returns>
        internal bool AgregarArchivo(T elemento)
        {
            if (elemento != null && !this.archivos.Contains(elemento))
            {
                this.archivos.Add(elemento);

                return true;
            }
            return false;
        }

        /// <summary>
        /// Valida que el objeto no sea null y que no este repetido en la lista. 
        /// Esto solo valida la referencia del objeto, no impide que el usuario quiera agregar 
        /// varias veces el mismo contenido en distintos objetos.
        /// Luego de validar, lo agrega a la lista y guarda cambios en el archivo.
        /// </summary>
        /// <param name="elemento">Elemento a agregar</param>
        public void AgregarArchivoYGuardarCambios(T elemento)
        {
            if (this.AgregarArchivo(elemento))
            {
                this.GuardarCambiosEnListaDeArchivos();
            }
        }

        /// <summary>
        /// Elimina un archivo de la lista.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>True si pudo eliminar el elemento, False si no se encontro el elemento en la lista.</returns>
        public bool EliminarArchivo(T elemento)
        {
            return elemento != null && this.archivos.Remove(elemento);
        }

        /// <summary>
        /// Elimina un archivo de la lista, y guarda cambios en el archivo.
        /// </summary>
        public void EliminarArchivoYGuardarCambios(T elemento)
        {
            if (this.EliminarArchivo(elemento))
            {
                this.GuardarCambiosEnListaDeArchivos();
            }
        }

        /// <summary>
        /// Vacia la lista de archivos.
        /// </summary>
        public void VaciarListaDeArchivos()
        {
            this.archivos.Clear();

        }

        /// <summary>
        /// Vacia la lista de archivos, y guarda cambios.
        /// </summary>
        public void VaciarListaDeArchivosYGuardarCambios()
        {
            this.VaciarListaDeArchivos();

            this.GuardarCambiosEnListaDeArchivos();
        }

        /// <summary>
        /// Guarda la lista de archivos en un Archivo JSON.
        /// </summary>
        public void GuardarCambiosEnListaDeArchivos()
        {
            Task.Run(() =>
            {
                try
                {
                    SerializadorJSON<List<T>>.Guardar(this.rutaRelativaArchivoJSON, this.archivos);
                }
                catch (Exception) 
                {
                    if (ListadoDeArchivos<T>.OnError != null)
                    {
                        ListadoDeArchivos<T>.OnError.Invoke("Ha ocurrido un error al intentar guardar cambios en la lista de archivos multimedia.");
                    }
                }
            });
        }

        /// <summary>
        /// Lee la lista de archivos, que esta almacenada en un archivo JSON.
        /// </summary>
        /// <returns>Si pudo leer, retorna una lista de archivos, caso contrario, retorna una lista vacia.</returns>
        private List<T> LeerListaDeArchivos()
        {
            try
            {
                return SerializadorJSON<List<T>>.Leer(this.rutaRelativaArchivoJSON);
            }
            catch (Exception)
            {
                return new List<T>();
            }
        }
    }
}
