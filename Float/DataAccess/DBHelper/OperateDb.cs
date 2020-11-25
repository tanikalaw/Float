using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using MySql.Data.MySqlClient;

namespace DataAccess.DBHelper
{
    public static class OperateDb
    {
        private const string connectionString = @"server=localhost;uid=root;pwd=1234;database=orderrific";


        public static MySqlConnection GetConnection()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
               return connection;
            }
        }

        //public static void SaveData<T>(string query, T parameter)
        //{
        //    using (MySqlConnection connection = new MySqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        DynamicParameters dp = new DynamicParameters();


        //        connection.Execute(query, dp);
        //    }
        //}


        public static List<T> LoadData<T, U>(string mysql, U parameters)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(mysql, parameters).ToList();
                return rows;
            }
        }

        public static void SaveData<T>(string mysql, T parameters = default)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Execute(mysql, parameters);
            }
        }

        public static bool SaveData(string mysql)
        {
            using (MySqlConnection connection = GetConnection())
            {
               var result = connection.Execute(mysql);

                if (result != null)
                    return true;
                else
                    return false;
            }
        }
    }
}
