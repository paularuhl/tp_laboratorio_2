using System;

namespace Excepciones
{
    /// <summary>
    /// Clase DniInvalidoException, que engloba las excepciones relacionadas con formato de DNI.
    /// </summary>
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException() : this ("DNI inválido") { }
        public DniInvalidoException(Exception e) : this ("DNI inválido", e) { }
        public DniInvalidoException(string message) : this (message, null) { }
        public DniInvalidoException(string message, Exception e) : base(message, e) { }

    }
}
