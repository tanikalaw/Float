using Float.Services.IServices;
using System;
using MySql.Data.MySqlClient;
using Dapper;
using DataAccess.DBHelper;

namespace Float.Services
{
    public class MemberService : IMemberService
    {
        public bool AddMember(string username, string password)
        {
            using (MySqlConnection connection = OperateDb.GetConnection())
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
            bool result = OperateDb.SaveData(query);

            if (result)
                return true;
            else
                return false;
        }
    }
}
