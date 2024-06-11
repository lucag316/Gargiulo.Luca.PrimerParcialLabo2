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
            Chocolate chocolate1 = new Chocolate(1, 5, 10, 1);
            Chocolate chocolate2 = new Chocolate(2, 5, 10, 1);
            //seguir con las demas opciones

            //// ACT - WHEN
            bool rta = chocolate1 == chocolate2;

            //// ASSERT - THEN - que esperamos?, que me de false
            Assert.IsFalse(rta); // si me da false, me tira un tilde
        }

        //[TestMethod]
        //public void VerificarChocolates_Nulos()
        //{
        //    Chocolate chocolate1 = null;
        //    Chocolate chocolate2 = null;

        //    bool rta = chocolate1 == chocolate2;

        //    Assert.IsTrue(rta); //espero que 2 nulos sean iguales

        //}

        [TestMethod]
        public void VerificarCalculoPrecioFinalChocolates_SinDescuento()
        {
            // ARRANGE
            Chocolate chocolate = new Chocolate(1, 5, 10, 3); // Cantidad <= 3

            // ACT
            double precioFinal = chocolate.CalcularPrecioFinal();

            // ASSERT
            Assert.AreEqual(30, precioFinal); // 10 * 3
        }

        [TestMethod]
        public void VerificarCalculoPrecioFinalChocolates_ConDescuento()
        {
            //// ARRANGE
            Chocolate chocolate = new Chocolate(1, 5, 10, 4); // Cantidad > 3

            //// ACT
            double precioFinal = chocolate.CalcularPrecioFinal();

            //// ASSERT
            Assert.AreEqual(28, precioFinal); // (10 * 4) * 0.7
        }
    }
}
