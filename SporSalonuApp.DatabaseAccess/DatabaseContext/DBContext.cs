using SporSalonuApp.Models.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SporSalonuApp.DatabaseAccess.DatabaseContext
{
    public class DBContext: IDisposable
    {
        public SqlConnection Connection { get; private set; }

        public DBContext()
        {
            Connection = new SqlConnection(@"Data Source=(local);Initial Catalog=SporSalonuDB;Integrated Security=True"); //config file'a alınabilir!
        }

        #region Connection Operations...
        public void OpenConnection()
        {
            try
            {
                if (Connection.State == ConnectionState.Closed)
                    Connection.Open();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Bağlantı Kapatılamadı", ex);
            }
        }
        #endregion

        #region CreateCommand Methods...
        public SqlCommand CreateCommand(string commandText,
                                        CommandType cmdType = CommandType.StoredProcedure)
        {
            SqlCommand cmd = Connection.CreateCommand();
            cmd.CommandText = commandText;
            cmd.CommandType = cmdType;
            return cmd;
        }

        /// <summary>
        /// Varsayılan CommandType Stored Procedure'dür
        /// </summary>
        /// <param name="commandText">Prosedür Adı</param>
        /// <param name="parameters">Prosedür Parametreleri</param>
        /// <returns></returns>
        public SqlCommand CreateCommand(string commandText,
                                        List<SqlParameter> parameters)
        {
            return CreateCommand(commandText, CommandType.StoredProcedure, parameters);
        }
        public SqlCommand CreateCommand(string commandText,
                                        CommandType cmdType,
                                        List<SqlParameter> parameters)
        {
            SqlCommand cmd = CreateCommand(commandText, cmdType);
            if (parameters != null)
                cmd.Parameters.AddRange((parameters.ToArray()));
            return cmd;
        }

        #endregion

        #region CommandExecute Methods...
        public T GetItem<T>(SqlCommand cmd) where T : IModel //Generic Class - Generic Method - Constrains
        {
            try
            {
                T item = default(T);
                OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows && reader.Read())
                {
                    item = (T)Activator.CreateInstance(typeof(T));
                    item.ReadItem(reader);
                }
                reader.Close();
                CloseConnection();

                return item;
            }
            catch (Exception)
            {
                CloseConnection();
                throw;
            }
        }
        public List<T> ToList<T>(SqlCommand cmd) where T : IModel
        {
            try
            {
                List<T> items = new List<T>();
                OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        T item = (T)Activator.CreateInstance(typeof(T));
                        item.ReadItem(reader);
                        items.Add(item);
                    }
                }
                reader.Close();
                CloseConnection();

                return items;
            }
            catch (Exception)
            {
                CloseConnection();
                throw;
            }
        }

        public int ExecuteNonQuery(SqlCommand cmd)
        {
            try
            {
                OpenConnection();
                int result = cmd.ExecuteNonQuery();
                CloseConnection();

                return result;
            }
            catch (Exception)
            {
                CloseConnection();
                throw;
            }
        }

        public object ExecuteScalar(SqlCommand cmd)
        {
            try
            {
                OpenConnection();
                object result = cmd.ExecuteScalar();
                CloseConnection();
                return result;
            }
            catch (Exception)
            {
                CloseConnection();
                throw;
            }
        }
        #endregion

        public void Dispose()
        {
            if (Connection.State == ConnectionState.Open)
                Connection.Close();

            Connection?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
