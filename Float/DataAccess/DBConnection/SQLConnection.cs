using System;
using MySql.Data.MySqlClient;

namespace DataAccess
{
    public static class SQLConnection
    {
        public const string connectionString = @"server=localhost;userid=root;password=1234;database=simplecrud";
       
        public static void InitializeDBConnection()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
            }
        }
    }
}
