using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsUnitarios
{

    [TestClass]
    public class TestChicle
    {
        [TestMethod]
        public void VerificarIgualdadChicles_ok()
        {
            ////AAA

            //// ARANGE - GIVEN
            Chicle chicle1 = new Chicle(1, 5, 10, 1, ENivelesDeElasticidad.SuperElastico, ENivelesDuracionDeSabor.Alta);
            Chicle chicle2 = new Chicle(1, 5, 10, 1, ENivelesDeElasticidad.SuperElastico, ENivelesDuracionDeSabor.Alta);

            //// ACT - WHEN
            bool rta = chicle1 == chicle2;

            //// ASSERT - THEN - que esperamos?, espero que la rta sea true
            Assert.IsTrue(rta); // si no da true, el test tira la cruz
        }

        [TestMethod]
        public void VerificarIgualdadChicles_Falla()
        {
            ////AAA

            //// ARANGE - GIVEN
            Chicle chicle1 = new Chicle(1, 5, 10, 1, ENivelesDeElasticidad.SuperElastico, ENivelesDuracionDeSabor.Alta);
            Chicle chicle2 = new Chicle(2, 5, 10, 1, ENivelesDeElasticidad.SuperElastico, ENivelesDuracionDeSabor.Alta);
            //seguir con las demas opciones

            //// ACT - WHEN
            bool rta = chicle1 == chicle2;

            //// ASSERT - THEN - que esperamos?, que me de false
            Assert.IsFalse(rta); // si me da false, me tira un tilde
        }

        [TestMethod]
        public void VerificarCalculoPrecioFinalChicles_SinDescuento()
        {
            // ARRANGE
            Chicle chicle = new Chicle(1, 5, 10, 5); // Cantidad <= 5

            // ACT
            double precioFinal = chicle.CalcularPrecioFinal();

            // ASSERT
            Assert.AreEqual(50, precioFinal); // 10 * 5
        }

        [TestMethod]
        public void VerificarCalculoPrecioFinalChicles_ConDescuento()
        {
            //// ARRANGE
            Chicle chicle = new Chicle(1, 5, 10, 6); // Cantidad > 5

            //// ACT
            double precioFinal = chicle.CalcularPrecioFinal();

            //// ASSERT
            Assert.AreEqual(51, precioFinal); // (10 * 6) * 0.85
        }
    }
}
