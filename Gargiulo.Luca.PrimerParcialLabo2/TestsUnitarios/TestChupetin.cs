using Entidades.JerarquiaYContenedora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsUnitarios
{

    [TestClass]
    public class TestChupetin
    {
        [TestMethod]
        public void VerificarIgualdadChupetines_ok()
        {
            ////AAA

            //// ARANGE - GIVEN
            Chupetin chupetin1 = new Chupetin(1, 5, 10, 1, EFormasDeChupetin.Redondo, ENivelesDeDureza.Media);
            Chupetin chupetin2 = new Chupetin(1, 5, 10, 1, EFormasDeChupetin.Redondo, ENivelesDeDureza.Media);

            //// ACT - WHEN
            bool rta = chupetin1 == chupetin2;

            //// ASSERT - THEN - que esperamos?, espero que la rta sea true
            Assert.IsTrue(rta); // si no da true, el test tira la cruz
        }

        [TestMethod]
        public void VerificarIgualdadChupetines_Falla()
        {
            ////AAA

            //// ARANGE - GIVEN
            Chupetin chupetin1 = new Chupetin(1, 5, 10, 1, EFormasDeChupetin.Redondo, ENivelesDeDureza.Media);
            Chupetin chupetin2 = new Chupetin(2, 5, 10, 1, EFormasDeChupetin.Corazon, ENivelesDeDureza.Alta);

            //seguir con las demas opciones

            //// ACT - WHEN
            bool rta = chupetin1 == chupetin2;

            //// ASSERT - THEN - que esperamos?, que me de false
            Assert.IsFalse(rta); // si me da false, me tira un tilde
        }

        [TestMethod]
        public void VerificarCalculoPrecioFinalChupetines_SinDescuento()
        {
            // ARRANGE
            Chupetin chupetin = new Chupetin(1, 5, 10, 2); // Cantidad <= 2

            // ACT
            double precioFinal = chupetin.CalcularPrecioFinal();

            // ASSERT
            Assert.AreEqual(20, precioFinal); // 10 * 2
        }

        [TestMethod]
        public void VerificarCalculoPrecioFinalChupetines_ConDescuento()
        {
            // ARRANGE
            Chupetin chupetin = new Chupetin(1, 5, 10, 3); // Cantidad > 2

            // ACT
            double precioFinal = chupetin.CalcularPrecioFinal();

            // ASSERT
            Assert.AreEqual(24, precioFinal); // (10 * 3) * 0.80
        }
    }
}
