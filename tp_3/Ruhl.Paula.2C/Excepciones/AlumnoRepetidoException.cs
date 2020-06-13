﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Clase AlumnoRepetidoException, que se dispara al intentar inscribir un alumno más de una vez a la misma universidad.
    /// </summary>
    public class AlumnoRepetidoException : Exception
    {
        public AlumnoRepetidoException() : this("Alumno Repetido.") { }
        public AlumnoRepetidoException(string message) : base(message) { }
    }
}
