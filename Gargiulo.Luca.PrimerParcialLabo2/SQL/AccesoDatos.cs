using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data; // esta no se si hay que poner, lo puse para no estar escribiendolo
using Entidades;
using System.Reflection.PortableExecutable;
using Entidades.Interfaces;
using System.Text;

namespace SQL
{
    public class AccesoDatos : IAccesibleDatos<Golosina> 
    {
        #region Atributos
        private static string cadenaConexion;
        private SqlConnection conexion;
        private SqlCommand? comando; // me permite ejecutar insertc, select, etc
        private SqlDataReader? lector; // se guarda internamente...
        #endregion

        #region Constructores
        static AccesoDatos() //recupera una cadena de conexion
        {
            AccesoDatos.cadenaConexion = Properties.Resources.miConexion; //para los recursos,  voy a propiedades ->recursos
                                                                          // Data Source=DESKTOP-SDI3B0J\SQLEXPRESS;Initial Catalog=Kiosco;Integrated Security=True;Trust Server Certificate=True
                                                                          // ES LO MISMO HACER CUALQUIERA DE LAS DOS
        }

        public AccesoDatos()
        {
            // CREO UN OBJETO SQLCONECTION, primero poner probar conexion (no se porque le tengo que poner opcional para que me deje)
            this.conexion = new SqlConnection(AccesoDatos.cadenaConexion);
        }
        #endregion

        public bool ProbarConexion()
        {
            bool rta = true;

            try
            {
                this.conexion.Open();   // lo itento enlazar con el motor de la base de datos
            }
            catch (Exception ex)
            {
                rta = false;
            }
            finally
            {
                //siempre y cuando este abierta, cierro la conexion
                //si me la intenta cerrar y nunca se abrio, me lanza excepcion, por eso pongo el if
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            return rta;
        }
        public List<Golosina> ObtenerListaDato() //para obtener el listado que tengo en la base de datos
        {
            List<Golosina> lista = new List<Golosina>();

            try //todo lo que sea base de datos, si o si tiene que tener un bloque try catch
            {
                this.comando = new SqlCommand();
                //siempre configurar estas tres propiedades
                this.comando.CommandType = CommandType.Text; //me indica como se tiene que interpretar el commanText
                this.comando.CommandText = "SELECT tipoDeGolosina, codigo, precio, peso, cantidad, relleno, tipoDeCacao, esVegano, elasticidad, duracionSabor, blanqueadorDental, formaChupetin, dureza, envolturaTransparente FROM DatosGolosinas";   //para ejecutar una consulta
                this.comando.Connection = this.conexion; // le paso el objeto conection que se va a utilizar 

                this.conexion.Open(); // abro la conexion

                this.lector = comando.ExecuteReader(); // tiene distintos metodos de ejecucion, segun la cosulta (fijarme en la ppt)

                if (!this.lector.HasRows)
                {
                    Console.WriteLine("No se encontraron filas.");
                }

                while (this.lector.Read()) // lee por fila
                {
                    Golosina golosina = CrearGolosinaDesdeDataReader();
                    if (golosina != null)
                    {
                        lista.Add(golosina);
                    }
                }
                lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open) // si la conexion esta abierta, la cierra
                {
                    this.conexion.Close();
                }
            }
            return lista;

        }

        #region Metodos Interfaz
        public List<Golosina> ObtenerLista()
        {
            return ObtenerListaDato();
        }

        public bool Agregar(Golosina entidad)
        {
            return AgregarGolosina(entidad);
        }

        public bool Modificar(Golosina entidad)
        {
            return ModificarGolosina(entidad);
        }

        public bool Eliminar(int codigo)
        {
            return EliminarGolosina(codigo);
        }

        #endregion

        #region Insert
        public bool AgregarGolosina(Golosina golosina)
        {
            bool rta = true;

            try
            {
                // primero preparo la consulta
                string sql = "INSERT INTO DatosGolosinas (tipoDeGolosina, codigo, precio, peso, cantidad, relleno, tipoDeCacao, esVegano, elasticidad, duracionSabor, blanqueadorDental, formaChupetin, dureza, envolturaTransparente) " +
                            "VALUES (@tipoDeGolosina, @codigo, @precio, @peso, @cantidad, @tipoDeCacao, @relleno, @esVegano, @elasticidad, @duracionSabor, @blanqueadorDental, @formaChupetin, @dureza, @envolturaTransparente)"; // le paso la consulta que es un insert

                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.comando.Parameters.AddWithValue("@tipoDeGolosina", golosina.GetType().Name);
                this.comando.Parameters.AddWithValue("@codigo", golosina.Codigo);
                this.comando.Parameters.AddWithValue("@precio", golosina.Precio);
                this.comando.Parameters.AddWithValue("@peso", golosina.Peso);
                this.comando.Parameters.AddWithValue("@cantidad", golosina.Cantidad);

                if (golosina is Chocolate)//golosina.GetType().Name == typeof(Chocolate).Name)
                {
                    Chocolate chocolate = (Chocolate)golosina;
                    AsignarParametrosChocolate(chocolate);
                }
                else if (golosina is Chicle)//golosina.GetType().Name == typeof(Chicle).Name)
                {
                    Chicle chicle = (Chicle)golosina;
                    AsignarParametrosChicle(chicle);
                }
                else if (golosina is Chupetin)//golosina.GetType().Name == typeof(Chupetin).Name)
                {
                    Chupetin chupetin = (Chupetin)golosina;
                    AsignarParametrosChupetin(chupetin);
                }

                int filasAfectadas = this.comando.ExecuteNonQuery(); // lo ejecuto con ese metodo porque no me retorna registro, solo las filas afectadas

                if (filasAfectadas == 0)
                {
                    rta = false;
                }

            }
            catch (Exception e)
            {
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            return rta;
        }

        #endregion

        #region Update

        public bool ModificarGolosina(Golosina golosina)
        {
            bool rta = true;

            try
            {

                string sql = "UPDATE DatosGolosinas ";
                sql += "SET tipoDeGolosina = @tipoDeGolosina, precio = @precio, peso = @peso, cantidad = @cantidad ";
                sql += "tipoDeCacao = @tipoDeCacao, relleno = @relleno, esVegano = @esVegano, ";
                sql += "elasticidad = @elasticidad, duracionSabor = @duracionSabor, blanqueadorDental = @blanqueadorDental, ";
                sql += "formaChupetin = @formaChupetin, dureza = @dureza, envolturaTransparente = @envolturaTransparente ";
                sql += "WHERE codigo = @codigo"; // no se si estan al reves

                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                // le agrego parametros //el @es para identificar el campo
                this.comando.Parameters.AddWithValue("@tipoDeGolosina", golosina.GetType().Name); // Obtiene el tipo de golosina
                this.comando.Parameters.AddWithValue("@codigo", golosina.Codigo);
                this.comando.Parameters.AddWithValue("@precio", golosina.Precio);
                this.comando.Parameters.AddWithValue("@peso", golosina.Peso);
                this.comando.Parameters.AddWithValue("@cantidad", golosina.Cantidad);


                if (golosina is Chocolate)
                {
                    Chocolate chocolate = (Chocolate)golosina;
                    AsignarParametrosChocolate(chocolate);
                }
                else if (golosina is Chicle)
                {
                    Chicle chicle = (Chicle)golosina;
                    AsignarParametrosChicle(chicle);
                }
                else if (golosina is Chupetin)
                {
                    Chupetin chupetin = (Chupetin)golosina;
                    AsignarParametrosChupetin(chupetin);
                }

                int filasAfectadas = this.comando.ExecuteNonQuery(); // lo ejecuto con ese metodo porque no me retorna registro, solo las filas afectadas

                if (filasAfectadas == 0)
                {
                    rta = false;
                }

            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }

        #endregion

        #region Delete

        public bool EliminarGolosina(int codigo)
        {
            bool rta = true;

            try
            {
                this.comando = new SqlCommand();

                string sql = "DELETE FROM DatosGolosinas ";// el delete no necesita de campos, porque se borra todo completo, por eso si o si mando where
                sql += "WHERE codigo = @codigo"; // no se si estan al reves

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.comando.Parameters.AddWithValue("@codigo", codigo);

                int filasAfectadas = this.comando.ExecuteNonQuery(); // lo ejecuto con ese metodo porque no me retorna registro, solo las filas afectadas

                if (filasAfectadas == 0)
                {
                    rta = false;
                }

            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }
        #endregion

        #region Metodos Asignaciones depende la golosina
        private void AsignarParametrosChocolate(Chocolate chocolate)
        {
            this.comando.Parameters.AddWithValue("@tipoDeCacao", chocolate.TipoDeCacao.ToString());
            this.comando.Parameters.AddWithValue("@relleno", chocolate.Relleno.ToString());
            this.comando.Parameters.AddWithValue("@esVegano", chocolate.EsVegano);
            this.comando.Parameters.AddWithValue("@elasticidad", DBNull.Value);
            this.comando.Parameters.AddWithValue("@duracionSabor", DBNull.Value);
            this.comando.Parameters.AddWithValue("@blanqueadorDental", DBNull.Value);
            this.comando.Parameters.AddWithValue("@formaChupetin", DBNull.Value);
            this.comando.Parameters.AddWithValue("@dureza", DBNull.Value);
            this.comando.Parameters.AddWithValue("@envolturaTransparente", DBNull.Value);
        }

        private void AsignarParametrosChicle(Chicle chicle)
        {
            this.comando.Parameters.AddWithValue("@tipoDeCacao", DBNull.Value);
            this.comando.Parameters.AddWithValue("@relleno", DBNull.Value);
            this.comando.Parameters.AddWithValue("@esVegano", DBNull.Value);
            this.comando.Parameters.AddWithValue("@elasticidad", chicle.Elasticidad.ToString());
            this.comando.Parameters.AddWithValue("@duracionSabor", chicle.DuracionSabor.ToString());
            this.comando.Parameters.AddWithValue("@blanqueadorDental", chicle.BlanqueadorDental);
            this.comando.Parameters.AddWithValue("@formaChupetin", DBNull.Value);
            this.comando.Parameters.AddWithValue("@dureza", DBNull.Value);
            this.comando.Parameters.AddWithValue("@envolturaTransparente", DBNull.Value);
        }

        private void AsignarParametrosChupetin(Chupetin chupetin)
        {
            this.comando.Parameters.AddWithValue("@tipoDeCacao", DBNull.Value);
            this.comando.Parameters.AddWithValue("@relleno", DBNull.Value);
            this.comando.Parameters.AddWithValue("@esVegano", DBNull.Value);
            this.comando.Parameters.AddWithValue("@elasticidad", DBNull.Value);
            this.comando.Parameters.AddWithValue("@duracionSabor", DBNull.Value);
            this.comando.Parameters.AddWithValue("@blanqueadorDental", DBNull.Value);
            this.comando.Parameters.AddWithValue("@formaChupetin", chupetin.FormaChupetin.ToString());
            this.comando.Parameters.AddWithValue("@dureza", chupetin.Dureza.ToString());
            this.comando.Parameters.AddWithValue("@envolturaTransparente", chupetin.EnvolturaTransparente);
        }

        #endregion

        private Golosina CrearGolosinaDesdeDataReader()
        {
            Golosina golosina = null;
            string tipoDeGolosina = this.lector.GetString(0);

            int codigo = this.lector.GetInt32(1); // Código
            float precio = (float)this.lector.GetDouble(2); // Precio
            float peso = (float)this.lector.GetDouble(3); // Peso
            int cantidad = this.lector.GetInt32(4); // Cantidad

            switch (tipoDeGolosina)
            {
                case "Chocolate":
                    Chocolate chocolate = new Chocolate();
                    chocolate.Codigo = codigo;
                    chocolate.Precio = precio;
                    chocolate.Peso = peso;
                    chocolate.Cantidad = cantidad;
                    chocolate.TipoDeCacao = (ETiposDeCacao)Enum.Parse(typeof(ETiposDeCacao), this.lector.GetString(5)); // TipoDeCacao (enum)
                    chocolate.Relleno = (ERellenos)Enum.Parse(typeof(ERellenos), this.lector.GetString(6)); // Relleno
                    chocolate.EsVegano = this.lector.GetBoolean(7); // esVegano (bool)

                    golosina = chocolate;
                    break;
                case "Chicle":
                    Chicle chicle = new Chicle();

                    chicle.Codigo = codigo;
                    chicle.Precio = precio;
                    chicle.Peso = peso;
                    chicle.Cantidad = cantidad;
                    chicle.Elasticidad = (ENivelesDeElasticidad)Enum.Parse(typeof(ENivelesDeElasticidad), this.lector.GetString(8)); // Elasticidad
                    chicle.DuracionSabor = (ENivelesDuracionDeSabor)Enum.Parse(typeof(ENivelesDuracionDeSabor), this.lector.GetString(9)); // DuracionSabor
                    chicle.BlanqueadorDental = this.lector.GetBoolean(10); // BlanqueadorDental (bool)

                    golosina = chicle;
                    break;
                case "Chupetin":
                    Chupetin chupetin = new Chupetin();

                    chupetin.Codigo = codigo;
                    chupetin.Precio = precio;
                    chupetin.Peso = peso;
                    chupetin.Cantidad = cantidad;
                    chupetin.FormaChupetin = (EFormasDeChupetin)Enum.Parse(typeof(EFormasDeChupetin), this.lector.GetString(11)); // FormaChupetin (enum)
                    chupetin.Dureza = (ENivelesDeDureza)Enum.Parse(typeof(ENivelesDeDureza), this.lector.GetString(12)); // Dureza
                    chupetin.EnvolturaTransparente = this.lector.GetBoolean(13); // EnvolturaTransparente (bool)

                    golosina = chupetin;
                    break;
            }
            return golosina;
        }
        public bool BorrarTodasLasGolosinas()
        {
            bool exito = false;
            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "DELETE FROM DatosGolosinas"; // Query para eliminar todas las golosinas
                this.comando.Connection = this.conexion;

                this.conexion.Open();
                int filasAfectadas = this.comando.ExecuteNonQuery();
                exito = filasAfectadas > 0; // Si se eliminaron filas, éxito es verdadero
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al borrar golosinas de la base de datos: " + ex.Message);
                exito = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            return exito;
        }
    }
}

