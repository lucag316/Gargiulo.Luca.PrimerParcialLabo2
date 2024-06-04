using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class TestKiosco
    {
        [TestMethod]
        public void Kioscoo()
        {
            ////AAA

            //// ARANGE - GIVEN
            Kiosco kiosco = new Kiosco(3);

            //// ACT - WHEN - ejecuto lo que se este probando
            List<Golosina> golosinas = kiosco.Golosinas;


            //// ASSERT - THEN - que esperamos?
            Assert.IsNotNull(golosinas);

        }
    }
}
