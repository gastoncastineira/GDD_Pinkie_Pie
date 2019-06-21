using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Conexiones
{
    public class Transaccion
    {
        private readonly SqlConnection connection;
        private readonly SqlTransaction transaction;

        public Transaccion(SqlConnection con)
        {
            connection = con;
            transaction = con.BeginTransaction();
        }

        public int Insertar(string tabla, Dictionary<string, object> data)
        {
            try
            {
                string comandoString = "INSERT INTO " + tabla + " (";
                data.Keys.ToList().ForEach(k => comandoString += k + ", ");
                comandoString = comandoString.Substring(0, comandoString.Length - 2) + ") VALUES (";
                data.Keys.ToList().ForEach(k => comandoString += "@" + k + ", ");
                comandoString = comandoString.Substring(0, comandoString.Length - 2) + "); SELECT SCOPE_IDENTITY();";
                PinkieLogger.logInsert(comandoString, data);
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = comandoString;
                    command.Transaction = transaction;
                    foreach (KeyValuePair<string, object> entry in data)
                    {
                        command.Parameters.AddWithValue("@" + entry.Key, entry.Value);
                    }
                    return Convert.ToInt32(command.ExecuteScalar());

                }
            }
            catch (SqlException ex)
            {
                PinkieLogger.logExcepcion(ex);
                transaction.Rollback();
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
                string comandoString = "UPDATE " + tabla + " SET ";
                foreach (KeyValuePair<string, object> entry in data)
                {
                    comandoString += entry.Key + " = @" + entry.Key + ", ";
                }
                comandoString = comandoString.Substring(0, comandoString.Length - 2) + " WHERE id = @id";
                PinkieLogger.logUpdate(comandoString, data);
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = comandoString;
                    command.Transaction = transaction;
                    command.Parameters.AddWithValue("@id", pk);
                    foreach (KeyValuePair<string, object> entry in data)
                    {
                        command.Parameters.AddWithValue("@" + entry.Key, entry.Value);
                    }
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                PinkieLogger.logExcepcion(ex);
                transaction.Rollback();
                return false;
            }
            return true;
        }

        public bool eliminarTablaIntermedia(string tabla, string col1, string col2, int pk1, int pk2)
        {
            string comando = "DELETE FROM " + tabla + " WHERE " + col1 + "= @pk1 AND " + col2 + " = @pk2";
            using (SqlCommand command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandText = comando;
                    command.CommandType = CommandType.Text;
                    command.Transaction = transaction;
                    command.Parameters.AddWithValue("@pk1", pk1);
                    command.Parameters.AddWithValue("@pk2", pk2);

                    command.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    return false;
                }
            }
            return true;
        }


        public bool InsertarTablaIntermedia(string tabla, string col1, string col2, int pk1, int pk2)
        {
            string comando = "INSERT INTO " + tabla + "( " + col1 + ", " + col2 + ") VALUES (@pk1, @pk2)";
            using (SqlCommand command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandText = comando;
                    command.CommandType = CommandType.Text;
                    command.Transaction = transaction;
                    command.Parameters.AddWithValue("@pk1", pk1);
                    command.Parameters.AddWithValue("@pk2", pk2);

                    command.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    return false;
                }
            }
            return true;
        }

        public void Commit()
        {
            transaction.Commit();
            connection.Close();
        }
    }
}
