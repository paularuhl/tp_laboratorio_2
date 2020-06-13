using System;
using ClasesInstanciables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TP3.Tests
{
    [TestClass]
    public class ColeccionesTest
    {
        /// <summary>
        /// Valida si la lista de alumnos fue instanciada. 
        /// </summary>
        [TestMethod]
        public void Universidad_AtributoAlumnos_Instanciado()
        {
            Universidad uni = new Universidad();

            Assert.IsNotNull(uni.Alumnos);
        }

        /// <summary>
        /// Valida si la lista de profesores fue instanciada. 
        /// </summary>
        [TestMethod]
        public void Universidad_AtributoInstructores_Instanciado()
        {
            Universidad uni = new Universidad();

            Assert.IsNotNull(uni.Instructores);
        }

    }
}
