using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using HappyBridesAPI.Models;
using System.Collections;

namespace HappyBridesAPI.Data
{
    public class DBConnect : DBConfiguration
    {
        public static SqlConnection Connection;
        public string sql { get; set; }
        public Dictionary<string, object> parameters { get; set; }
        public DBConnect() 
        {
            try
            {
                SqlConnectionStringBuilder sqlConnectionString = new SqlConnectionStringBuilder
                {
                    InitialCatalog = Config.Database,
                    DataSource = Config.Server,
                    UserID = Config.Username,
                    Password = Config.Password
                };

                Connection = new SqlConnection(sqlConnectionString.ConnectionString);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int ExecuteWriteSQLCommand()
        {
            SqlCommand command;
            try
            {
                int createdID;
                Connection.Open();
                
                using (command = new SqlCommand(sql, Connection)) 
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value);
                        
                    }
                    createdID = (int)command.ExecuteScalar();
                    command.Dispose();
                }
                Connection.Close();
                return createdID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Dictionary<string,object>> ExecuteReadSQLCommand()
        {
            SqlCommand command;
            SqlDataReader dataReader;

            try
            {
                Connection.Open();
                List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();
                using (command = new SqlCommand(sql, Connection)) 
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    if (parameters.Count > 0) 
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }
                        
                    using (dataReader = command.ExecuteReader()) 
                    {
                        
                        while (dataReader.Read())
                        {
                            Dictionary<string, object> record = new Dictionary<string, object>();
                            
                            for (int i = 0; i < dataReader.FieldCount; i++)
                            {
                                record.Add(dataReader.GetName(i), dataReader.GetValue(i));
                            }

                            result.Add(record);
                        }
                    }
                    dataReader.Close();
                    command.Dispose();
                }
                Connection.Close();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
