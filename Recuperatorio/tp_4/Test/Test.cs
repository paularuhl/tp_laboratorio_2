using System;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void Correo_ListaInstanciada_Ok()
        {
            //Arrange
            Correo correo;
            //Act
            correo = new Correo();
            //Assert
            Assert.IsNotNull(correo.Paquetes);
        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void Correo_SumaPaqueteRepetido_Throws()
        {
            //Arrange
            Correo correo = new Correo();
            Paquete p1 = new Paquete("Paraguay y Pueyrredon", "1234567890");
            Paquete p2 = new Paquete("Paraguay y Pueyrredon", "1234567890");

            //Act
            correo += p1;
            correo += p2;
        }

        [TestMethod]
        public void Correo_SumaPaquetesDistintos_Ok()
        {
            //Arrange
            Correo correo = new Correo();
            Paquete p1 = new Paquete("Paraguay y Pueyrredon", "1234567890");
            Paquete p2 = new Paquete("Paraguay y Pueyrredon", "1000000890");

            //Act
            correo += p1;
            correo += p2;

            //Assert
            Assert.IsTrue(correo.Paquetes.Count == 2);
        }
    }
}
