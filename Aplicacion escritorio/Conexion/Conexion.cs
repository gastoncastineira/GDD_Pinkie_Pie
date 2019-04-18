using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ConsoleApp2.Conexion
{
    public class Conexion
    {
        private static Conexion instance = null;
        private const string comandoInsert = "INSERT INTO ";
        private const string comandoUpdate = "UPDATE ";
        private const string comandoSelect = "SELECT ";
        private static string conectionString; //= ConfigurationHelper.ConnectionString

        private string PonerFiltros(string comando, List<Filtro> filtros)
        {
            comando += " WHERE ";
            filtros.ForEach(filtro => comando += filtro.Columna + " " + filtro.Condicion + " AND ");
            comando = comando.Substring(0, comando.Length - 4);
            return comando;
        }


        //Recibe el nombre de la tabla sacada de Conexion.Tabla, y un diccionario con el par 
        //("nombre de columna en BD", dato a insertar)
        //retorna true si se pudo realizar, false si fallo
        public int Insertar(string tabla, Dictionary<string, object> data)
        {
            try
            {
                string comandoString = string.Copy(comandoInsert) + tabla + " (";
                data.Keys.ToList().ForEach(k => comandoString += k + ", ");
                comandoString = comandoString.Substring(0, comandoString.Length - 2) + ") VALUES (";
                data.Keys.ToList().ForEach(k => comandoString += "@" + k + ", ");
                comandoString = comandoString.Substring(0, comandoString.Length - 2) + "); SELECT SCOPE_IDENTITY();";
                using (SqlConnection sqlConnection = new SqlConnection(conectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = sqlConnection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = comandoString;
                        foreach (KeyValuePair<string, object> entry in data)
                        {
                            command.Parameters.AddWithValue("@" + entry.Key, entry.Value);
                        }
                        return Convert.ToInt32(command.ExecuteScalar());

                    }
                }
            }
            catch (SqlException)
            {
                return -1;
            }

        }

        //Recibe el id de la fila, nombre de la tabla sacada de Conexion.Tabla, y 
        //un diccionario con el par ("nombre de columna en BD", dato a insertar
        //retorna true si se pudo realizar, false si fallo
        public bool Modificar(int pk, string tabla, Dictionary<string, object> data)
        {
            try
            {
                string comandoString = string.Copy(comandoUpdate) + tabla + " SET ";
                foreach (KeyValuePair<string, object> entry in data)
                {
                    comandoString += entry.Key + " = @" + entry.Key + ", ";
                }
                comandoString = comandoString.Substring(0, comandoString.Length - 2) + " WHERE id = @id";
                using (SqlConnection sqlConnection = new SqlConnection(conectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = sqlConnection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = comandoString;
                        command.Parameters.AddWithValue("@id", pk);
                        foreach (KeyValuePair<string, object> entry in data)
                        {
                            command.Parameters.AddWithValue("@" + entry.Key, entry.Value);
                        }
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException)
            {
                return false;
            }
            return true;
        }

        //Recibe el nombre de la tabla de Conexion.Tabla, el dataGrid POR REFERENCIA, y los filtros de busqueda sacados 
        //de Conexion.Filtro 
        public void LlenarDataGridView(string tabla, ref DataGridView dataGrid, List<Filtro> filtros)
        {
            dataGrid.DataSource = ConseguirTabla(tabla, filtros);
        }

        public DataTable ConseguirTabla(string tabla, List<Filtro> filtros)
        {
            string comandoString = string.Copy(comandoSelect) + " * FROM " + tabla;
            if (filtros != null && filtros.Count > 0)
                comandoString = PonerFiltros(comandoString, filtros);
            using (SqlConnection sqlConnection = new SqlConnection(conectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.Connection = sqlConnection;
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = comandoString;
                    SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

                    DataTable dtRecord = new DataTable();
                    sqlDataAdap.Fill(dtRecord);

                    return dtRecord;
                }
            }
        }

        public bool ValidarLogin(string usuario, string contraseña, ref bool contraseñaAutogenerada)
        {
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "[ESKHERE].existe_usuario";
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameter1 = new SqlParameter("@Usuario", SqlDbType.NVarChar);
                    parameter1.Direction = ParameterDirection.Input;
                    parameter1.Value = usuario;
                    SqlParameter parameter2 = new SqlParameter("@Contrasenia", SqlDbType.NVarChar);
                    parameter2.Direction = ParameterDirection.Input;
                    parameter2.Value = contraseña;
                    SqlParameter parameter3 = new SqlParameter("@resultado", SqlDbType.Bit);
                    parameter3.Direction = ParameterDirection.Output;
                    SqlParameter parameter4 = new SqlParameter("@autogenerada", SqlDbType.Bit);
                    parameter4.Direction = ParameterDirection.Output;

                    command.Parameters.Add(parameter1);
                    command.Parameters.Add(parameter2);
                    command.Parameters.Add(parameter3);
                    command.Parameters.Add(parameter4);

                    command.ExecuteNonQuery();

                    bool resultado = Convert.ToBoolean(command.Parameters["@resultado"].Value);
                    if (resultado)
                        contraseñaAutogenerada = Convert.ToBoolean(command.Parameters["@autogenerada"].Value);
                    return resultado;
                }
            }
        }

        public int InsertarUsuario(string usuario, string contraseña, string rol)
        {
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "[ESKHERE].insertar_usuario";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter parameter1 = new SqlParameter("@usuario", SqlDbType.NVarChar);
                        parameter1.Direction = ParameterDirection.Input;
                        parameter1.Value = usuario;
                        SqlParameter parameter2 = new SqlParameter("@contrasenia", SqlDbType.NVarChar);
                        parameter2.Direction = ParameterDirection.Input;
                        parameter2.Value = contraseña;
                        SqlParameter parameter3 = new SqlParameter("@nombreTipo", SqlDbType.NVarChar);
                        parameter3.Direction = ParameterDirection.Input;
                        parameter3.Value = rol;
                        SqlParameter retorno = new SqlParameter("@ReturnVal", SqlDbType.Int);
                        retorno.Direction = ParameterDirection.ReturnValue;

                        command.Parameters.Add(parameter1);
                        command.Parameters.Add(parameter2);
                        command.Parameters.Add(parameter3);
                        command.Parameters.Add(retorno);

                        command.ExecuteNonQuery();
                        return Convert.ToInt32(retorno.Value);
                    }
                    catch (SqlException)
                    {
                        return -1;
                    }

                }
            }
        }

        public int GenerarUsuarioAleatorio(string documento, string rol, ref string usuario, ref string contraseña)
        {
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "[ESKHERE].crear_usuario_aleatorio";
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameter1 = new SqlParameter("@Usuario", SqlDbType.NVarChar);
                    parameter1.Direction = ParameterDirection.Output;
                    parameter1.Size = 20;
                    SqlParameter parameter2 = new SqlParameter("@Contrasenia", SqlDbType.NVarChar);
                    parameter2.Direction = ParameterDirection.Output;
                    parameter2.Size = 5;
                    SqlParameter parameter3 = new SqlParameter("@id", SqlDbType.Int);
                    parameter3.Direction = ParameterDirection.Output;
                    SqlParameter parameter4 = new SqlParameter("@documento", SqlDbType.NVarChar);
                    parameter4.Direction = ParameterDirection.Input;
                    parameter4.Value = documento;
                    SqlParameter parameter5 = new SqlParameter("@NombreTipo", SqlDbType.NVarChar);
                    parameter5.Direction = ParameterDirection.Input;
                    parameter5.Value = rol;

                    command.Parameters.Add(parameter1);
                    command.Parameters.Add(parameter2);
                    command.Parameters.Add(parameter3);
                    command.Parameters.Add(parameter4);
                    command.Parameters.Add(parameter5);

                    command.ExecuteNonQuery();

                    usuario = Convert.ToString(command.Parameters["@Usuario"].Value);
                    contraseña = Convert.ToString(command.Parameters["@Contrasenia"].Value);
                    return Convert.ToInt32(command.Parameters["@id"].Value);
                }
            }
        }

        public bool ActualizarContraseña(string contraseña, string usuario)
        {
            string comandoString = string.Copy(comandoUpdate) + Tabla.Usuario + " SET contrasenia = HASHBYTES('SHA2_256', @contrasenia), contrasena_autogenerada = 0 WHERE usuario = @usuario";
            try
            {
                using (SqlConnection connection = new SqlConnection(conectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = comandoString;
                        command.Parameters.AddWithValue("@contrasenia", contraseña);
                        command.Parameters.AddWithValue("@usuario", usuario);

                        command.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public bool ExisteRegistro(string tabla, List<string> columnas, List<Filtro> filtros)
        {
            var datos = ConsultaPlana(tabla, columnas, filtros);
            return (datos[columnas[0]].Count > 0);
        }

        private void CambiarHabilitacion(string tabla, int id, string cambio)
        {
            string comandoString = string.Copy(comandoUpdate) + tabla + " SET habilitado = " + cambio + " WHERE id = @id";
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = comandoString;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void deshabilitar(string tabla, int id)
        {
            CambiarHabilitacion(tabla, id, "0");
        }

        public void habilitar(string tabla, int id)
        {
            CambiarHabilitacion(tabla, id, "1");
        }

        private Dictionary<string, List<object>> HacerDictinary(List<string> colum)
        {
            Dictionary<string, List<object>> retorno = new Dictionary<string, List<object>>();
            colum.ForEach(c => retorno.Add(c.Split(' ').Last(), new List<object>()));
            return retorno;
        }


        //Recibe el nombre de la tabla sacado de Conexion.Tabla, una lista de strings con los nombres de las columnas a buscar
        //y un diccionario con el par ("nombre de columna", valor) como filtro. Si no se quiere filtrar, se pasa null.
        //Retorna un diccionario con el par ("nombre de columna", lista de valores retornados)
        public Dictionary<string, List<object>> ConsultaPlana(string tabla, List<string> columnas, List<Filtro> filtros)
        {
            Dictionary<string, List<object>> retorno = HacerDictinary(columnas);

            string comandoString = string.Copy(comandoSelect);

            columnas.ForEach(c => comandoString += c + ", ");
            comandoString = comandoString.Substring(0, comandoString.Length - 2);

            comandoString += " FROM " + tabla;
            if (filtros != null && filtros.Count > 0)
                comandoString = PonerFiltros(comandoString, filtros);

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = comandoString;
                    command.CommandType = CommandType.Text;

                    command.Connection = connection;

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                        columnas.ForEach(c => retorno[c.Split(' ').Last()].Add(reader[c.Split(' ').Last()]));
                }
            }
            return retorno;
        }

        public Transaccion IniciarTransaccion()
        {
            SqlConnection con = new SqlConnection(conectionString);
            con.Open();
            return new Transaccion(con);
        }
    }
}