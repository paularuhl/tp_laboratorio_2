using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{    /// <summary>
     /// Clase NacionalidadInvalidaException, que engloba las excepciones relacionadas con formato de DNI en relacion a la Nacionalidad.
     /// </summary>
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException() : this("La nacionalidad no se condice con el número de DNI") { }
        public NacionalidadInvalidaException(string mensaje) : base(mensaje) { }
    }
}
