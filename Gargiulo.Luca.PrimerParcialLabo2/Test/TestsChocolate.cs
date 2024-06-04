using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Test
{
    [TestClass]
    public class TestsChocolate
    {
        [TestMethod]
        public void VerificarIgualdadChocolates_ok()
        {
            ////AAA

            //// ARANGE - GIVEN
            Chocolate chocolate1 = new Chocolate(1, 5, 10, 1);
            Chocolate chocolate2 = new Chocolate(1, 5, 10, 1);

            //// ACT - WHEN
            bool rta = chocolate1 == chocolate2;

            //// ASSERT - THEN - que esperamos?, espero que la rta sea true
            Assert.IsTrue(rta); // si no da true, el test tira la cruz
        }

        [TestMethod]
        public void VerificarIgualdadChocolates_Falla()
        {
            ////AAA

            //// ARANGE - GIVEN
            Chocolate chocolate1 = new Chocolate(1, 5, 10, 1);
            Chocolate chocolate2 = new Chocolate(2, 5, 10, 1);

            //// ACT - WHEN
            bool rta = chocolate1 == chocolate2;

            //// ASSERT - THEN - que esperamos?, que me de false
            Assert.IsFalse(rta); // si me da false, me tira un tilde
        }

        [TestMethod]
        public void VerificarIgualdadChocolates_Nulos()
        {
            ////AAA

            //// ARANGE - GIVEN
            Chocolate chocolate1 = new Chocolate(1, 5, 10, 1);
            Chocolate chocolate2 = new Chocolate(1, 5, 10, 1);



            //// ACT - WHEN
            bool rta = chocolate1 == chocolate2;

            //// ASSERT - THEN - que esperamos?
            Assert.IsTrue(rta);
        }


    }
}
