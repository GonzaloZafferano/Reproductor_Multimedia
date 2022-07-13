using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Entidades
{
    internal static class SerializadorJSON<T> where T : class
    {
        private const string extension = ".json";

        /// <summary>
        /// Obtiene la ruta completa del archivo, agregando la extension .json (si no la tiene).
        /// </summary>
        /// <param name="rutaRelativa">Ruta relativa del archivo.</param>
        /// <returns>La ruta completa del archivo con extension .json.</returns>
        /// <exception cref="Exception">Error.</exception>
        internal static string ObtenerRutaAbsolutaDelArchivoYAgregarExtensionJSON(string rutaRelativa)
        {
            try
            {
                string rutaAbsolutaDelArchivo = Archivo.ObtenerRutaAbsolutaDelArchivo(rutaRelativa);

                if (!rutaAbsolutaDelArchivo.EndsWith(SerializadorJSON<T>.extension))
                {
                    rutaAbsolutaDelArchivo += SerializadorJSON<T>.extension;
                }

                return rutaAbsolutaDelArchivo;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Guarda un elemento en la ruta indicada, con formato JSON.
        /// </summary>
        /// <param name="rutaRelativaDelArchivo">Ruta relativa del archivo.</param>
        /// <param name="elemento">Elemento a guardar.</param>
        /// <exception cref="Exception">Ocurrio un error al intentar guardar.</exception>
        internal static void Guardar(string rutaRelativaDelArchivo, T elemento)
        {
            string rutaAbsolutaDelArchivo;
            string rutaAbsolutaDelDirectorio;
            string jsonSerializado;

            try
            {
                if (elemento != null)
                {
                    rutaAbsolutaDelArchivo = SerializadorJSON<T>.ObtenerRutaAbsolutaDelArchivoYAgregarExtensionJSON(rutaRelativaDelArchivo);

                    rutaAbsolutaDelDirectorio = rutaAbsolutaDelArchivo.Substring(0, rutaAbsolutaDelArchivo.LastIndexOf(Archivo.CaracterSeparadorDeDirectorios) + 1);

                    if (Directory.Exists(rutaAbsolutaDelDirectorio) || Directory.CreateDirectory(rutaAbsolutaDelDirectorio).Exists)
                    {
                        DirectoryInfo informacion = new DirectoryInfo(rutaAbsolutaDelDirectorio);
                        informacion.Attributes = FileAttributes.Hidden;

                        JsonSerializerOptions opcionesDeSerializacion = new JsonSerializerOptions();
                        opcionesDeSerializacion.WriteIndented = true;

                        jsonSerializado = JsonSerializer.Serialize(elemento, opcionesDeSerializacion);

                        File.WriteAllText(rutaAbsolutaDelArchivo, jsonSerializado);

                        return;
                    }
                }
                throw new NullReferenceException("El elemento a serializar es NULL");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al intentar Serializar: {ex.Message}");
            }
        }

        /// <summary>
        /// Lee un elemento de un archivo JSON y lo retorna.
        /// </summary>
        /// <param name="rutaRelativaDelArchivo">Ruta del archivo</param>
        /// <returns>Elemento leido</returns>
        /// <exception cref="Exception">Ocurrio un error al intentar leer.</exception>
        internal static T Leer(string rutaRelativaDelArchivo)
        {
            string rutaAbsolutaDelArchivo;
            string jsonFormatoString;
            try
            {
                rutaAbsolutaDelArchivo = SerializadorJSON<T>.ObtenerRutaAbsolutaDelArchivoYAgregarExtensionJSON(rutaRelativaDelArchivo);

                if (File.Exists(rutaAbsolutaDelArchivo))
                {
                    jsonFormatoString = File.ReadAllText(rutaAbsolutaDelArchivo);

                    if (JsonSerializer.Deserialize(jsonFormatoString, typeof(T)) is T elemento)
                    {
                        return elemento;
                    }
                }
                throw new FileNotFoundException($"No se encontro un archivo en la ruta: {rutaAbsolutaDelArchivo}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al intentar Deserializar: {ex.Message}");
            }
        }
    }
}
