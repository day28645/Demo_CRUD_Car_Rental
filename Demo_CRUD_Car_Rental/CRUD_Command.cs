using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Demo_CRUD_Car_Rental
{

    public partial class DBConnect
    {
        private readonly string _connectionstring = $"server=localhost; uid=root; pwd=root1; database=car_demos";
        private MySqlConnection sqlConnection;

        public DBConnect()
        {
            sqlConnection = new MySqlConnection();
            sqlConnection.ConnectionString = _connectionstring;
        }

        protected void DbOpen()
        {
            if (sqlConnection != null)
            {
                sqlConnection.Open();
            }
        }
        protected void DbClose()
        {
            if (sqlConnection != null)
            {
                sqlConnection.Close();
            }
        }

        protected MySqlConnection GetInstant()
        {
            var con = sqlConnection.Clone();
            return sqlConnection;
        }
    }

    // derived class - CRUD command
    public class CRUD_Command : DBConnect
    {
        // read - select
        public DataTable SelectComand(string query)
        {
            try
            {
                DbOpen();
                DataTable dataTable = new DataTable();
                MySqlCommand cmd = new MySqlCommand(query, GetInstant());
                dataTable.Load(cmd.ExecuteReader());
                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DbClose();
            }
        }// end SelectComand

        // create - insert, update, alter, create
        public int Insert_Update_Command(string query)
        {
            try
            {
                DbOpen();
                MySqlCommand cmd = new MySqlCommand(query, GetInstant());
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DbClose();
            }
        }// end Insert_Update_Command

        // execute scalar - get single value
        public object ExecuteScalarCommand(string query)
        {
            try
            {
                DbOpen();
                MySqlCommand cmd = new MySqlCommand(query, GetInstant());
                object result = cmd.ExecuteScalar();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DbClose();
            }
        }// end ExecuteScalarCommand

        public DataTable SelectStoreProcedure(string storedProcName, 
                                              Dictionary<string, object> parameters = null, 
                                              Dictionary<string, MySqlParameter> outParameters = null)
        {
            try
            {
                DbOpen();
                DataTable dataTable = new DataTable();

                using (MySqlCommand cmd = new MySqlCommand(storedProcName, GetInstant()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add IN parameters
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    // Add OUT parameters
                    if (outParameters != null)
                    {
                        foreach (var outParam in outParameters)
                        {
                            outParam.Value.Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(outParam.Value);
                        }
                    }

                    dataTable.Load(cmd.ExecuteReader());

                    // Read OUT parameter values after execution
                    if (outParameters != null)
                    {
                        foreach (var outParam in outParameters)
                        {
                            outParam.Value.Value = cmd.Parameters[outParam.Key].Value;
                        }
                    }
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DbClose();
            }
        }


    }
}