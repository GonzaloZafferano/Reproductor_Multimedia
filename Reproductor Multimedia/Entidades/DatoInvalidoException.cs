using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DatoInvalidoException : Exception
    {
        public DatoInvalidoException(string message) : base(message)
        {
        }

        public DatoInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }        
    }
}
