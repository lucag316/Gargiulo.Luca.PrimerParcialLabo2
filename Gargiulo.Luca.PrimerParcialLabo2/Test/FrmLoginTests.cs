using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using Interfaz;

namespace Test
{
    [TestClass]
    public class FrmLoginTests
    {

        [TestMethod]
        public void ObtenerUsuarioNullOrEmpty()
        {
            //AAA

            // ARANGE - GIVEN
            //usuario y contraseña vacias

            // ACT - WHEN
            // intentar logearme

            // ASSERT - THEN
            //deberia tirar la exception
        }


        //[TestMethod]
        /*
        public void ObtenerUsuarioValido()
        {
            //AAA

            // ARANGE - GIVEN
            //usuario y contraseña existentes
            Usuario usuario;
            string correo = "admin@admin.com";
            string clave = "12345678";


            // ACT - WHEN
            // intentar logearme
            usuario = FrmLogin.ObtenerUsuario(correo, clave);


            // ASSERT - THEN - que esperamos?
            //deberia devolver el usuario
            Assert.IsNotNull(usuario);
            Assert.AreEqual(usuario.correo, usuario);


        }*/
    }
}
