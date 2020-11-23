using System;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Mozilla;

namespace DataAccess
{
    public static class SQLConnection
    {
        public static const string connectionString = @"server=localhost;userid=root;password=1234;database=simplecrud";
       
        public static void InitializeDBConnection()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
            }
        }
    }
}
