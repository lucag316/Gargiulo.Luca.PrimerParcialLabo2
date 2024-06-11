using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsUnitarios
{

    [TestClass]
    public class TestKiosco
    {
        [TestMethod]
        public void AgreagarGolosinaAlKiosco()
        {
            ////AAA

            //// ARANGE - GIVEN
            Kiosco kiosco = new Kiosco();
            Golosina golosina = new Chicle(1, 10, 5, 1);

            //// ACT - WHEN - ejecuto lo que se este probando
            kiosco += golosina;

            //// ASSERT - THEN - que esperamos?
            Assert.IsTrue(kiosco == golosina); //kiosco.Golosinas.Contains(golosina) // lo mismo creo
        }

        [TestMethod]
        public void EliminarGolosinasDelKiosco()
        {
            ////AAA

            //// ARANGE - GIVEN
            Kiosco kiosco = new Kiosco();
            Golosina golosina = new Chocolate(1, 10, 5, 1);

            //// ACT - WHEN - ejecuto lo que se este probando
            kiosco -= golosina;

            //// ASSERT - THEN - que esperamos?
            Assert.IsFalse(kiosco == golosina);
        }


        [TestMethod]
        public void AgregarListaDeGolosinasAlKiosco()
        {
            ////AAA

            //// ARANGE - GIVEN
            Kiosco kiosco = new Kiosco();
            List<Golosina> listaGolosinas = new List<Golosina>()
            {
                new Chocolate(1, 20, 10, 2, ERellenos.Mani),
                new Chicle(2, 5, 2, 3),
                new Chupetin(3, 3, 1.5, 4)
            };

            //// ACT - WHEN - ejecuto lo que se este probando
            kiosco += listaGolosinas;

            //// ASSERT - THEN - que esperamos?
            CollectionAssert.AreEqual(listaGolosinas, kiosco.Golosinas);
        }

        [TestMethod]
        public void VerificarOrdenarGolosinasPorCodigo()
        {
            // Arrange
            Kiosco kiosco = new Kiosco();
            kiosco += new Chicle(2, 5, 2, 3);
            kiosco += new Chocolate(1, 20, 10, 2, ERellenos.Nuez);
            kiosco += new Chupetin(3, 3, 1.5, 4);

            // Act
            kiosco.OrdenarGolosinasPorCodigo(true);

            // Assert
            Assert.AreEqual(1, kiosco.Golosinas[0].Codigo);
        }

        [TestMethod]
        public void VerificarCalcularPrecioTotalDelKiosco_ok()
        {
            // Arrange
            Kiosco kiosco = new Kiosco();
            kiosco += new Chocolate(1, 20, 10, 4, ERellenos.Nuez);
            kiosco += new Chicle(2, 5, 5, 1);
            kiosco += new Chupetin(3, 3, 5, 1);

            // Act
            double precioTotal = kiosco.CalcularPrecioTotal();

            // Assert
            Assert.AreEqual(38, precioTotal);
        }


        //[TestMethod]
        //public void Kioscoo()
        //{
        //    ////AAA

        //    //// ARANGE - GIVEN
        //    Kiosco kiosco = new Kiosco(3);

        //    //// ACT - WHEN - ejecuto lo que se este probando
        //    List<Golosina> golosinas = kiosco.Golosinas;


        //    //// ASSERT - THEN - que esperamos?
        //    Assert.IsNotNull(golosinas);

        //}
    }
}
