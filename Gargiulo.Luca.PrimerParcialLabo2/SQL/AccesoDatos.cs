using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data; // esta no se si hay que poner, lo puse para no estar escribiendolo
using Entidades;

namespace SQL
{
    public class AccesoDatos
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

        #region Metodos

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
                this.comando.CommandText = "SELECT codigo, precio, peso, cantidad, relleno, tipoDeCacao, esVegano, elasticidad, duracionSabor, blanqueadorDental, formaChupetin, dureza, envolturaTransparente FROM DatosGolosinas";   //para ejecutar una consulta
                this.comando.Connection = this.conexion; // le paso el objeto conection que se va a utilizar 

                this.conexion.Open(); // abro la conexion

                this.lector = comando.ExecuteReader(); // tiene distintos metodos de ejecucion, segun la cosulta (fijarme en la ppt)

                if (!lector.HasRows)
                {
                    Console.WriteLine("No se encontraron filas.");
                }

                while (lector.Read()) // lee por fila
                {
                    Golosina golosina = null;

                    //// ACCEDO POR NOMBRE, POR INDICE O POR GETTER (SEGUN TIPO DE DATO)
                    //item.Codigo = (int)lector["codigo"]; // recupero por nombre de columna
                    //item.Precio = Convert.ToSingle(this.lector.GetDouble(1));
                    //item.Peso = Convert.ToSingle(this.lector.GetDouble(2));
                    ////item.Cantidad = lector.GetInt32(3); 
                    ////item.Cantidad = lector[3].ToString(); //recupero por posicion de columna
                    ////item.Cantidad = int.Parse(lector[3].ToString());
                    //item.Cantidad = (int)lector["cantidad"];

                    if (!this.lector.IsDBNull(4)) // verifico si el campo TipoDeCacao no es nulo (es un Chocolate)
                    {
                        Chocolate chocolate = new Chocolate();

                        chocolate.Codigo = this.lector.GetInt32(0); // Código
                        chocolate.Precio = this.lector.GetFloat(1); // Precio
                        chocolate.Peso = this.lector.GetFloat(2); // Peso
                        chocolate.Cantidad = this.lector.GetInt32(3); // Cantidad
                        //--------
                        chocolate.TipoDeCacao = (ETiposDeCacao)Enum.Parse(typeof(ETiposDeCacao), this.lector.GetString(4)); // TipoDeCacao (enum)
                        chocolate.Relleno = (ERellenos)Enum.Parse(typeof(ERellenos), this.lector.GetString(5)); // Relleno
                        chocolate.EsVegano = this.lector.GetBoolean(6); // esVegano (bool)

                        golosina = chocolate;
                    }
                    else if (!this.lector.IsDBNull(7)) // Elasticidad no es nulo (es un chicle)
                    {
                        Chicle chicle = new Chicle();

                        chicle.Codigo = this.lector.GetInt32(0); // Código
                        chicle.Precio = this.lector.GetFloat(1); // Precio
                        chicle.Peso = this.lector.GetFloat(2); // Peso
                        chicle.Cantidad = this.lector.GetInt32(3); // Cantidad
                        //---------
                        chicle.Elasticidad = (ENivelesDeElasticidad)Enum.Parse(typeof(ENivelesDeElasticidad), this.lector.GetString(7)); // Elasticidad
                        chicle.DuracionSabor = (ENivelesDuracionDeSabor)Enum.Parse(typeof(ENivelesDuracionDeSabor), this.lector.GetString(8)); // DuracionSabor
                        chicle.BlanqueadorDental = this.lector.GetBoolean(9); // BlanqueadorDental (bool)

                        golosina = chicle;
                    }
                    else if (!this.lector.IsDBNull(10)) // FormaDeChupetin no es nulo (es un chupetin)
                    {
                        Chupetin chupetin = new Chupetin();

                        chupetin.Codigo = this.lector.GetInt32(0); // Código
                        chupetin.Precio = this.lector.GetFloat(1); // Precio
                        chupetin.Peso = this.lector.GetFloat(2); // Peso
                        chupetin.Cantidad = this.lector.GetInt32(3); // Cantidad
                        //---------------
                        chupetin.FormaChupetin = (EFormasDeChupetin)Enum.Parse(typeof(EFormasDeChupetin), this.lector.GetString(10)); // FormaDeChupetin (enum)
                        chupetin.Dureza = (ENivelesDeDureza)Enum.Parse(typeof(ENivelesDeDureza), this.lector.GetString(11)); // Dureza
                        chupetin.EnvolturaTransparente = this.lector.GetBoolean(12); // EnvolturaTransparente (bool)

                        golosina = chupetin;
                    }

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

        #region Insert
        public bool AgregarGolosina(Golosina golosina)
        {
            bool rta = true;

            try
            {
                // primero preparo la consulta
                string sql = "INSERT INTO DatosGolosinas (codigo, precio, peso, cantidad, relleno, tipoDeCacao, esVegano, elasticidad, duracionSabor, blanqueadorDental, formaChupetin, dureza, envolturaTransparente) " +
                            "VALUES (@codigo, @precio, @peso, @cantidad, @tipoDeCacao, @relleno, @esVegano, @elasticidad, @duracionSabor, @blanqueadorDental, @formaChupetin, @dureza, @envolturaTransparente)"; // le paso la consulta que es un insert
                
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.comando.Parameters.AddWithValue("@codigo", golosina.Codigo);
                this.comando.Parameters.AddWithValue("@precio", golosina.Precio);
                this.comando.Parameters.AddWithValue("@peso", golosina.Peso);
                this.comando.Parameters.AddWithValue("@cantidad", golosina.Cantidad);

                if (golosina is Chocolate)
                {
                    Chocolate chocolate = (Chocolate)golosina;
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
                else if (golosina is Chicle)
                {
                    Chicle chicle = (Chicle)golosina;
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
                else if (golosina is Chupetin)
                {
                    Chupetin chupetin = (Chupetin)golosina;
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
                this.comando = new SqlCommand();

                string sql = "UPDATE DatosGolosinas ";
                sql += "SET precio = @precio, peso = @peso, cantidad = @cantidad ";
                sql += "tipoDeCacao = @tipoDeCacao, relleno = @relleno, esVegano = @esVegano, ";
                sql += "elasticidad = @elasticidad, duracionSabor = @duracionSabor, blanqueadorDental = @blanqueadorDental, ";
                sql += "formaChupetin = @formaChupetin, dureza = @dureza, envolturaTransparente = @envolturaTransparente ";
                sql += "WHERE codigo = @codigo"; // no se si estan al reves

                // le agrego parametros //el @es para identificar el campo
                this.comando.Parameters.AddWithValue("@codigo", golosina.Codigo);
                this.comando.Parameters.AddWithValue("@precio", golosina.Precio);
                this.comando.Parameters.AddWithValue("@peso", golosina.Peso);
                this.comando.Parameters.AddWithValue("@cantidad", golosina.Cantidad);

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                if (golosina is Chocolate)
                {
                    Chocolate chocolate = (Chocolate)golosina;
                    this.comando.Parameters.AddWithValue("@tipoDeCacao", chocolate.TipoDeCacao);
                    this.comando.Parameters.AddWithValue("@relleno", chocolate.Relleno);
                    this.comando.Parameters.AddWithValue("@esVegano", chocolate.EsVegano);
                    this.comando.Parameters.AddWithValue("@elasticidad", DBNull.Value);
                    this.comando.Parameters.AddWithValue("@duracionSabor", DBNull.Value);
                    this.comando.Parameters.AddWithValue("@blanqueadorDental", DBNull.Value);
                    this.comando.Parameters.AddWithValue("@formaChupetin", DBNull.Value);
                    this.comando.Parameters.AddWithValue("@dureza", DBNull.Value);
                    this.comando.Parameters.AddWithValue("@envolturaTransparente", DBNull.Value);
                }
                else if (golosina is Chicle)
                {
                    Chicle chicle = (Chicle)golosina;
                    this.comando.Parameters.AddWithValue("@tipoDeCacao", DBNull.Value);
                    this.comando.Parameters.AddWithValue("@relleno", DBNull.Value);
                    this.comando.Parameters.AddWithValue("@esVegano", DBNull.Value);
                    this.comando.Parameters.AddWithValue("@elasticidad", chicle.Elasticidad);
                    this.comando.Parameters.AddWithValue("@duracionSabor", chicle.DuracionSabor);
                    this.comando.Parameters.AddWithValue("@blanqueadorDental", chicle.BlanqueadorDental);
                    this.comando.Parameters.AddWithValue("@formaChupetin", DBNull.Value);
                    this.comando.Parameters.AddWithValue("@dureza", DBNull.Value);
                    this.comando.Parameters.AddWithValue("@envolturaTransparente", DBNull.Value);
                }
                else if (golosina is Chupetin)
                {
                    Chupetin chupetin = (Chupetin)golosina;
                    this.comando.Parameters.AddWithValue("@tipoDeCacao", DBNull.Value);
                    this.comando.Parameters.AddWithValue("@relleno", DBNull.Value);
                    this.comando.Parameters.AddWithValue("@esVegano", DBNull.Value);
                    this.comando.Parameters.AddWithValue("@elasticidad", DBNull.Value);
                    this.comando.Parameters.AddWithValue("@duracionSabor", DBNull.Value);
                    this.comando.Parameters.AddWithValue("@blanqueadorDental", DBNull.Value);
                    this.comando.Parameters.AddWithValue("@formaChupetin", chupetin.FormaChupetin);
                    this.comando.Parameters.AddWithValue("@dureza", chupetin.Dureza);
                    this.comando.Parameters.AddWithValue("@envolturaTransparente", chupetin.EnvolturaTransparente);
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

                this.comando.Parameters.AddWithValue("@codigo", codigo);

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

        #endregion
    }
}



//using Microsoft.Data.SqlClient;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data; // esta no se si hay que poner, lo puse para no estar escribiendolo
//using Entidades;

//namespace SQL
//{
//    public class AccesoDatos
//    {
//        #region Atributos

//        private static string cadenaConexion;
//        private SqlConnection conexion;
//        private SqlCommand? comando; // me permite ejecutar insertc, select, etc
//        private SqlDataReader? lector; // se guarda internamente...

//        #endregion


//        #region Constructores

//        static AccesoDatos() //recupera una cadena de conexion
//        {
//            AccesoDatos.cadenaConexion = Properties.Resources.miConexion; //para los recursos,  voy a propiedades ->recursos
//                                                                          // Data Source=DESKTOP-SDI3B0J\SQLEXPRESS;Initial Catalog=Kiosco;Integrated Security=True;Trust Server Certificate=True
//                                                                          // ES LO MISMO HACER CUALQUIERA DE LAS DOS
//        }

//        public AccesoDatos()
//        {
//            // CREO UN OBJETO SQLCONECTION, primero poner probar conexion (no se porque le tengo que poner opcional para que me deje)
//            this.conexion = new SqlConnection(AccesoDatos.cadenaConexion);
//        }

//        #endregion


//        #region Metodos

//        public bool ProbarConexion()
//        {
//            bool rta = true;

//            try
//            {
//                this.conexion.Open();   // lo itento enlazar con el motor de la base de datos
//            }
//            catch (Exception ex)
//            {
//                rta = false;
//            }
//            finally
//            {
//                //siempre y cuando este abierta, cierro la conexion
//                //si me la intenta cerrar y nunca se abrio, me lanza excepcion, por eso pongo el if
//                if (this.conexion.State == ConnectionState.Open)
//                {
//                    this.conexion.Close();
//                }
//            }
//            return rta;
//        }

//        public List<Golosina> ObtenerListaDato() //para obtener el listado que tengo en la base de datos
//        {
//            List<Golosina> lista = new List<Golosina>();

//            try //todo lo que sea base de datos, si o si tiene que tener un bloque try catch
//            {
//                this.comando = new SqlCommand();
//                //siempre configurar estas tres propiedades
//                this.comando.CommandType = CommandType.Text; //me indica como se tiene que interpretar el commanText
//                this.comando.CommandText = "SELECT codigo, precio, peso, cantidad FROM DatosGolosinas";   //para ejecutar una consulta
//                this.comando.Connection = this.conexion; // le paso el objeto conection que se va a utilizar 

//                this.conexion.Open(); // abro la conexion

//                this.lector = comando.ExecuteReader(); // tiene distintos metodos de ejecucion, segun la cosulta (fijarme en la ppt)

//                if (!lector.HasRows)
//                {
//                    Console.WriteLine("No se encontraron filas.");
//                }

//                while (lector.Read()) // lee por fila
//                {
//                    Golosina item = new Chocolate();

//                    // ACCEDO POR NOMBRE, POR INDICE O POR GETTER (SEGUN TIPO DE DATO)
//                    item.Codigo = (int)lector["codigo"]; // recupero por nombre de columna
//                    item.Precio = Convert.ToSingle(this.lector.GetDouble(1));
//                    item.Peso = Convert.ToSingle(this.lector.GetDouble(2));
//                    //item.Cantidad = lector.GetInt32(3); 
//                    //item.Cantidad = lector[3].ToString(); //recupero por posicion de columna
//                    //item.Cantidad = int.Parse(lector[3].ToString());
//                    item.Cantidad = (int)lector["cantidad"];

//                    lista.Add(item);
//                }
//                lector.Close();
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.ToString());
//            }
//            finally
//            {
//                if (this.conexion.State == ConnectionState.Open) // si la conexion esta abierta, la cierra
//                {
//                    this.conexion.Close();
//                }
//            }
//            return lista;

//        }

//        #region Insert

//        public bool AgregarGolosina(Golosina param)
//        {
//            bool rta = true;

//            try
//            {
//                // primero preparo la consulta
//                string sql = "INSERT INTO DatosGolosinas (codigo, precio, peso, cantidad) VALUES("; // le paso la consulta que es un insert
//                sql = sql + "" + param.Codigo.ToString() + "," + param.Precio.ToString() + "," + param.Peso.ToString() + "," + param.Cantidad.ToString() + ")";

//                this.comando = new SqlCommand();

//                this.comando.CommandType = CommandType.Text;
//                this.comando.CommandText = sql; 
//                this.comando.Connection = this.conexion;

//                this.conexion.Open();

//                int filasAfectadas = this.comando.ExecuteNonQuery(); // lo ejecuto con ese metodo porque no me retorna registro, solo las filas afectadas

//                if (filasAfectadas == 0)
//                {
//                    rta = false;
//                }

//            }
//            catch (Exception e)
//            {
//                rta = false;
//            }
//            finally
//            {
//                if (this.conexion.State == ConnectionState.Open)
//                {
//                    this.conexion.Close();
//                }
//            }
//            return rta;
//        }

//        #endregion

//        #region Update

//        public bool ModificarGolosina(Golosina param)
//        {
//            bool rta = true;

//            try
//            {
//                this.comando = new SqlCommand();
//                // le agrego parametros //el @es para identificar el campo
//                this.comando.Parameters.AddWithValue("@codigo", param.Codigo);
//                this.comando.Parameters.AddWithValue("@precio", param.Precio);
//                this.comando.Parameters.AddWithValue("@peso", param.Peso);
//                this.comando.Parameters.AddWithValue("@cantidad", param.Cantidad);

//                string sql = "UPDATE DatosGolosinas ";
//                sql += "SET precio = @precio, peso = @peso, cantidad = @cantidad ";
//                sql += "WHERE codigo = @codigo"; // no se si estan al reves

//                this.comando.CommandType = CommandType.Text;
//                this.comando.CommandText = sql;
//                this.comando.Connection = this.conexion;

//                this.conexion.Open();

//                int filasAfectadas = this.comando.ExecuteNonQuery(); // lo ejecuto con ese metodo porque no me retorna registro, solo las filas afectadas

//                if (filasAfectadas == 0)
//                {
//                    rta = false;
//                }

//            }
//            catch (Exception)
//            {
//                rta = false;
//            }
//            finally
//            {
//                if (this.conexion.State == ConnectionState.Open)
//                {
//                    this.conexion.Close();
//                }
//            }

//            return rta;
//        }

//        #endregion


//        #region Delete

//        public bool EliminarGolosina(int codigo)
//        {
//            bool rta = true;

//            try
//            {
//                this.comando = new SqlCommand();

//                this.comando.Parameters.AddWithValue("@codigo", codigo);

//                string sql = "DELETE FROM DatosGolosinas ";// el delete no necesita de campos, porque se borra todo completo, por eso si o si mando where
//                sql += "WHERE codigo = @codigo"; // no se si estan al reves

//                this.comando.CommandType = CommandType.Text;
//                this.comando.CommandText = sql;
//                this.comando.Connection = this.conexion;

//                this.conexion.Open();

//                int filasAfectadas = this.comando.ExecuteNonQuery(); // lo ejecuto con ese metodo porque no me retorna registro, solo las filas afectadas

//                if (filasAfectadas == 0)
//                {
//                    rta = false;
//                }

//            }
//            catch (Exception)
//            {
//                rta = false;
//            }
//            finally
//            {
//                if (this.conexion.State == ConnectionState.Open)
//                {
//                    this.conexion.Close();
//                }
//            }

//            return rta;
//        }


//        #endregion


//        #endregion
//    }
//}
