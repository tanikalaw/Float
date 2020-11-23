using simpleCRUD.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Helper;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using DataLibrary.DB;
using simpleCRUD.Components.Login;
using System.Net.Http.Headers;

namespace simpleCRUD.Services
{
    public class MemberService : IMemberService
    {
        public bool AddMember(string username, string password)
        {
            using (MySqlConnection connection = DataAccess.GetConnection())
            {
                connection.Open();
                var query = "INSERT INTO logindata (username,password) VALUES (@username, @password)";

                var dp = new DynamicParameters();
                dp.Add("@username", username);
                dp.Add("@password", password);
                int result = connection.Execute(query, dp);

                if (result > 0)
                    return true;
                else
                    return false;
            }
        }

        public bool SearchMember(string username, string password)
        {
            var query = $"SELECT * FROM logindata WHERE username = '{username}'";
            bool result = DataAccess.SaveData(query);

            if (result)
                return true;
            else
                return false;
        }
    }
}
