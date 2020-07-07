using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidoException : Exception
    {
        /// <summary>
        /// Constructor de excepcion que solo recibe mensaje
        /// </summary>
        /// <param name="mensaje"></param>
        public TrackingIdRepetidoException(string mensaje) : this(mensaje, null) { }
        /// <summary>
        /// Constructor de excepcion que recibe mensaje y una inner exception
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="inner"></param>
        public TrackingIdRepetidoException(string mensaje, Exception inner) : base(mensaje, inner) { }
    }
}
