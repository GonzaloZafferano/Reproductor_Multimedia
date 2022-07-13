using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ExtensionString
    {
        /// <summary>
        /// Evalua que una cadena cumpla con la expresion regular recibida como argumento.
        /// </summary>
        /// <param name="cadena">Cadena a evaluar.</param>
        /// <param name="expresion">Expresion regular que se debe respetar.</param>
        /// <returns>True si la cadena cumple con la expresion regular, caso contrario False.</returns>
        private static bool EsCadenaValida(string cadena, string expresion)
        {
            bool retorno = false;

            if (!string.IsNullOrWhiteSpace(cadena) && !string.IsNullOrWhiteSpace(expresion))
            {
                Regex expresionRegular = new Regex(expresion);
                
                retorno = expresionRegular.IsMatch(cadena);
            }

            return retorno;
        }

        /// <summary>
        /// Determina si una cadena es alfanumerica (Con espacios).
        /// </summary>
        /// <param name="cadena">Cadena que se evaluara.</param>
        /// <returns>True si es una cadena Alfanumerica, caso contrario False.</returns>
        public static bool EsCadenaAlfanumericaConEspacios(this string cadena)
        {
            return ExtensionString.EsCadenaValida(cadena, "^[a-zA-Z0-9 ]+$");
        }
    }
}
