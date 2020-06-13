using System;
using System.Collections.Generic;
using ClasesInstanciables;
using EntidadesAbstractas;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TP3.Tests
{
    [TestClass]
    public class ExcepcionesTest
    {
        /// <summary>
        /// Si el DNI tiene caracteres no numericos, deberia lanzar DniInvalidoException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void DniInvalido_NoEsNumerico_Throws()
        {
            Alumno a1 = new Alumno(7, "Paula", "Ruhl", "1ABC4456",
            Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);

        }
        /// <summary>
        /// Si el DNI se parsea correctamente y no tiene valores no numéricos, debería coincidir con el expected.
        /// </summary>
        [TestMethod]
        public void DniValido_Ok()
        {
            Alumno a1 = new Alumno(7, "Paula", "Ruhl", "40011750",
            Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);
            int expected = 40011750;

            Assert.AreEqual(expected, a1.Dni);
        }

        /// <summary>
        /// Si la Nacionalidad no matchea con el tipo de dni, deberia lanzar NacionalidadInvalidaException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void NacionalidadInvalida_NoHayMatchConDni_Throws()
        {
            Alumno a1 = new Alumno(7, "Paula", "Ruhl", "99999998",
            Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);

        }

        /// <summary>
        /// Si el alumno ya es parte de la universidad, deberia lanzar AlumnoRepetidoException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void AlumnoRepetido_Throws()
        {
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(7, "Paula", "Ruhl", "40011750",
            Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);

            uni += a1;
            uni += a1;
        }

        /// <summary>
        /// Si el alumno ya es parte de la universidad, deberia lanzar AlumnoRepetidoException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void ArchivoInexistente_Throws()
        {
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(7, "Paula", "Ruhl", "40011750",
            Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);

            uni += a1;
            uni += a1;
        }



    }
}
