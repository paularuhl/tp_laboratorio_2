﻿using System;

namespace Excepciones
{
    /// <summary>
    /// Clase SinProfesorException, que se dispara al no tener un profesor disponible para una materia.
    /// </summary>
    public class SinProfesorException : Exception
    {
        public SinProfesorException() : this("Sin profesor para la clase.") { }
        public SinProfesorException(string message) : base(message) { }
    }
}
