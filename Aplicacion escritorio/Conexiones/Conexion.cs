using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using FrbaCrucero.AbmCrucero;

namespace Conexiones
{
    public class Conexion
    {
        private const string comandoInsert = "INSERT INTO ";
        private const string comandoUpdate = "UPDATE ";
        private const string comandoSelect = "SELECT ";
        private static string conectionString = FrbaCrucero.ConfigurationHelper.ConnectionString;

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
        public void LlenarComboBox(string tabla, ref ComboBox comboBox, List<Filtro> filtros)
        {
            comboBox.DataSource = ConseguirTabla(tabla, filtros);
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

        public bool ValidarLogin(string usuario, string contraseña)
        {
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "PINKIE_PIE.existe_usuario";
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameter1 = new SqlParameter("@Usuario", SqlDbType.NVarChar);
                    parameter1.Direction = ParameterDirection.Input;
                    parameter1.Value = usuario;
                    SqlParameter parameter2 = new SqlParameter("@Contrasenia", SqlDbType.NVarChar);
                    parameter2.Direction = ParameterDirection.Input;
                    parameter2.Value = contraseña;
                    SqlParameter parameter3 = new SqlParameter("@resultado", SqlDbType.Bit);
                    parameter3.Direction = ParameterDirection.Output;

                    command.Parameters.Add(parameter1);
                    command.Parameters.Add(parameter2);
                    command.Parameters.Add(parameter3);

                    command.ExecuteNonQuery();

                    return Convert.ToBoolean(command.Parameters["@resultado"].Value);
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

        public bool eliminarTablaIntermedia(string tabla, string col1, string col2, int pk1, int pk2)
        {
            string comando = "DELETE FROM " + tabla + " WHERE " + col1 + "= @pk1 AND " + col2 + " = @pk2";
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = comando;
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@pk1", pk1);
                        command.Parameters.AddWithValue("@pk2", pk2);

                        command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        public bool InsertarTablaIntermedia(string tabla, string col1, string col2, int pk1, int pk2)
        {
            string comando = "INSERT INTO " + tabla + "( " + col1 + ", " + col2 + ") VALUES (@pk1, @pk2)";
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = comando;
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("@pk1", pk1);
                        command.Parameters.AddWithValue("@pk2", pk2);

                        command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        return false;
                    }
                }
            }
            return true;
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
                    {
                        columnas.ForEach(c => retorno[c.Split(' ').Last()].Add(reader[c.Split(' ').Last()]));
                    }
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

        public DataTable TraerLitadoEstadistico(string nombreView, DateTime fechaInicio, DateTime fechaFin)
        {
            string condicion = " WHERE fecha_inicio BETWEEN '" + fechaInicio.ToString("yyyy-MM-dd") + "' AND '" + fechaFin.ToString("yyyy-MM-dd") + "' AND fecha_fin BETWEEN '" + fechaInicio.ToString("yyyy-MM-dd") + "' AND '" + fechaFin.ToString("yyyy-MM-dd") + "'";
            string comandoString = null;
            switch (nombreView)
            {
                case "PINKIE_PIE.top_5_recorridos":
                    comandoString = "SELECT TOP 5 codigo_recorrido, puerto_origen, puerto_destino, SUM(cant_pasaje) as cant FROM PINKIE_PIE.top_5_recorridos " +
                        condicion + " GROUP BY codigo_recorrido, puerto_origen, puerto_destino ORDER BY cant DESC";
                    break;
                case "PINKIE_PIE.top_5_clientes_puntos":
                    return ConseguirTabla(nombreView, null);
                case "PINKIE_PIE.top_5_viajes_cabinas_vacias":
                    comandoString = "SELECT TOP 5 viaje_id, cod_recorrido, SUM(cant_cabinas) as cant FROM " + nombreView + condicion
                       + " GROUP BY viaje_id, cod_recorrido ORDER BY cant DESC";
                    break;
                case "PINKIE_PIE.top_5_dias_crucero_fuera_servicio":
                    comandoString = "SELECT TOP 5 identificador, fabricante, modelo, SUM(cant_dias) as cant FROM PINKIE_PIE.top_5_dias_crucero_fuera_servicio"
                        + condicion + " GROUP BY identificador, fabricante, modelo ORDER BY cant DESC";
                    break;
            }
            DataTable dtRecord = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(conectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.Connection = sqlConnection;
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = comandoString;
                    SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);

                    sqlDataAdap.Fill(dtRecord);

                    
                }
            }
            return dtRecord;
        }

        public void LlenarCheckedListConTramosDescriptos(ref CheckedListBox list, string origenObligatorio)
        {
            string comandoString =
                        "SELECT Po.descripcion AS PUERTO_ORIGEN, pd.descripcion AS PUERTO_DESTINO " +
                        "FROM PINKIE_PIE.Tramo_X_Recorrido TR    JOIN PINKIE_PIE.Tramo T ON T.ID = TR.ID_Tramo " +
                                                                "JOIN PINKIE_PIE.Puerto Po ON Po.ID = T.puerto_origen_id " +
                                                                "JOIN PINKIE_PIE.Puerto Pd ON Pd.ID = T.puerto_destino_id ";
            if (origenObligatorio != null){
                comandoString = comandoString + "WHERE Po.descripcion = '" + origenObligatorio.Trim() +"' ";
            }
            using (SqlConnection sqlConnection = new SqlConnection(conectionString))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = comandoString;
                    command.CommandType = CommandType.Text;
                    command.Connection = sqlConnection;

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Items.Add("Desde: " + reader[0].ToString() + ". Hasta: " + reader[1].ToString(), false);
                    }
                }
            }
        }

        public void LlenarComboFabricantes(ref ComboBox combo)
        {

            string comandoString = "SELECT DISTINCT fabricante FROM " + Tabla.Crucero;

            using (SqlConnection sqlConnection = new SqlConnection(conectionString))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = comandoString;
                    command.CommandType = CommandType.Text;
                    command.Connection = sqlConnection;

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        combo.Items.Add(reader[0].ToString().ToUpper());
                    }
                }
            }

        }

        public void LlenarComboTipoPisos(ref DataGridViewComboBoxColumn combo)
        {

            string comandoString = "SELECT tipo FROM " + Tabla.Tipo;

            using (SqlConnection sqlConnection = new SqlConnection(conectionString))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = comandoString;
                    command.CommandType = CommandType.Text;
                    command.Connection = sqlConnection;

                    SqlDataReader reader = command.ExecuteReader();

                    List<string> items = new List<string>();

                    while (reader.Read())
                    {
                        items.Add(reader[0].ToString());
                    }

                    combo.DataSource = items;

                }
            }

        }


        public void CancelarPasajes(int id, DateTime fecha)
        {
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "PINKIE_PIE.CancelarPasajes";
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameter1 = new SqlParameter("@idCrucero", SqlDbType.Int);
                    parameter1.Direction = ParameterDirection.Input;
                    parameter1.Value = id;

                    SqlParameter parameter2 = new SqlParameter("@fecha", SqlDbType.DateTime2);
                    parameter2.Direction = ParameterDirection.Input;
                    parameter2.Value = fecha;

                    command.Parameters.Add(parameter1);
                    command.Parameters.Add(parameter2);

                    command.ExecuteNonQuery();

                }
            }
        }


    }
}