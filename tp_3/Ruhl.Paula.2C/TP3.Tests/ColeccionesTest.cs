using System;
using ClasesInstanciables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TP3.Tests
{
    [TestClass]
    public class ColeccionesTest
    {
        [TestMethod]
        public void Universidad_AtributoAlumnos_Instanciado()
        {
            Universidad uni = new Universidad();

            Assert.IsNotNull(uni.Alumnos);
        }

        [TestMethod]
        public void Universidad_AtributoInstructores_Instanciado()
        {
            Universidad uni = new Universidad();

            Assert.IsNotNull(uni.Instructores);
        }

    }
}
