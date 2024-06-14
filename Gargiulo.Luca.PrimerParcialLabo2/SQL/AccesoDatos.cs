using Microsoft.Data.SqlClient;
using System.ComponentModel;

namespace SQL
{
    public class AccesoDatos
    {
        #region Atributos

        private static string cadenaConexion;
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        #endregion


        #region Constructores

        static AccesoDatos()
        {
            AccesoDatos.cadenaConexion = Properties.Resources.miConexion; //para los recursos,  voy a propiedades ->recursos
                                        // "Data Source=DESKTOP-SDI3B0J\\SQLEXPRESS;Initial Catalog=DataKiosco;Integrated Security=True;Encrypt=False";
                                        // ES LO MISMO HACER CUALQUIERA DE LAS DOS
        }

        public AccesoDatos()
        {
            // CREO UN OBJETO SQLCONECTION, primero poner probar conexion (no se porque le tengo que poner opcional para que me deje)
            this.conexion = new SqlConnection(AccesoDatos.cadenaConexion);
        }

        #endregion


        #region Metodos

        #endregion
    }
}
