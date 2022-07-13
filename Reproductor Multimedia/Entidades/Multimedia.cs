using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entidades
{
    public class Multimedia
    {
        private string rutaAbsolutaDelArchivo;
        private string nombreArchivo;
        private bool estaSeleccionado;

        [JsonInclude]
        [Browsable(false)]
        /// <summary>
        /// Obtiene y setea la ruta del archivo multimedia (Al cambiar la ruta, se setea tambien el nombre del archivo).
        /// </summary>
        /// <exception cref="FileNotFoundException">La ruta no existe.</exception>
        /// <exception cref="NullReferenceException">Ruta archivo esta vacia.</exception>
        public string RutaAbsolutaDelArchivo
        {
            get
            {
                return this.rutaAbsolutaDelArchivo;
            }
            set
            {
                this.rutaAbsolutaDelArchivo = Archivo.ValidarRutaAbsolutaDeArchivo(value);

                this.NombreArchivo = this.rutaAbsolutaDelArchivo;
            }
        }

        [JsonIgnore]
        /// <summary>
        /// Obtiene el nombre del archivo multimedia.
        /// </summary>
        /// <exception cref="NullReferenceException">Ruta archivo esta vacia.</exception>
        public string NombreArchivo
        {
            get
            {
                return this.nombreArchivo;
            }
            private set
            {
                this.nombreArchivo = Archivo.ObtenerNombreDelArchivoAPartirDeSuRutaAbsoluta(value);
            }
        }

        [JsonIgnore]
        public bool EstaSeleccionado { get => this.estaSeleccionado; set => this.estaSeleccionado = value; }

        [JsonConstructor]
        /// <summary>
        /// Crea un objeto de la clase Multimedia.
        /// </summary>
        /// <param name="rutaAbsolutaDelArchivo">Ruta absoluta del archivo.</param>
        /// <exception cref="NullReferenceException">Ruta archivo esta vacia.</exception>
        /// <exception cref="FileNotFoundException">La ruta no existe.</exception>
        public Multimedia(string rutaAbsolutaDelArchivo)
        {
            this.RutaAbsolutaDelArchivo = rutaAbsolutaDelArchivo;
        }      
    }
}
