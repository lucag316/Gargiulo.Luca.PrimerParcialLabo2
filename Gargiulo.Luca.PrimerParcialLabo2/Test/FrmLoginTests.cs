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
        //[DataRow(null, null)] //correo, clave
        //[DataRow("", null)]
        //[DataRow(null, "")]
        //[DataRow("", "")]
        ////[ExpectedException(typeof(ArgumentNullException))]//aca vas a recibir una exception de tal tipo
        //[TestMethod]
        //public void ObtenerUsuarioNullOrEmpty(string correo, string clave)
        //{
        //    //AAA

        //    // ARANGE - GIVEN
        //    //usuario y contraseña vacias

        //    // ACT - WHEN
        //    // intentar logearme
        //    //FrmLogin.ObtenerUsuario(correo, clave);// 1 manera

        //    // ASSERT - THEN
        //    //deberia tirar la exception
        //    Assert.ThrowsException<ArgumentNullException>(() =>
        //    {
        //        FrmLogin.ObtenerUsuario(correo, clave);
        //    }); // otra manera
        //}


        //[TestMethod]
        //public void ObtenerUsuarioValido()
        //{
        //    //AAA

        //    // ARANGE - GIVEN
        //    //usuario y contraseña existentes
        //    Usuario usuario;
        //    string correo = "admin@admin.com";
        //    string clave = "12345678";


        //    // ACT - WHEN
        //    // intentar logearme
        //    usuario = FrmLogin.ObtenerUsuario(correo, clave);


        //    // ASSERT - THEN - que esperamos?
        //    //deberia devolver el usuario
        //    Assert.IsNotNull(usuario);
        //    Assert.AreEqual(usuario.correo.ToLower(), usuario.ToLower());
        //}

        //[DataRow("hola", "123")]
        //[DataRow("hola", "12345678")]
        //[DataRow("admin@admin.com", "123")]
        //[TestMethod]
        //public void ObtenerUsuarioNoValido(string correo, string clave)
        //{
        //    //AAA

        //    // ARANGE - GIVEN
        //    Usuario usuario;

        //    // ACT - WHEN
        //    // intentar logearme
        //    usuario = FrmLogin.ObtenerUsuario(correo, clave);

        //    // ASSERT - THEN - que esperamos?
        //    Assert.IsNull(usuario);
        //}
    }
}
