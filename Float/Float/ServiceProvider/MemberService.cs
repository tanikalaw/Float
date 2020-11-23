using simpleCRUD.Services.IServices;
using System;
using MySql.Data.MySqlClient;

namespace simpleCRUD.Services
{
    public class MemberService : IMemberService
    {
        public bool AddMember(string username, string password)
        {
            //using (MySqlConnection connection = DataAccess.GetConnection())
            //{
            //    connection.Open();
            //    var query = "INSERT INTO logindata (username,password) VALUES (@username, @password)";

            //    var dp = new DynamicParameters();
            //    dp.Add("@username", username);
            //    dp.Add("@password", password);
            //    int result = connection.Execute(query, dp);

            if (true)
                return true;
            else
                return false;
            //}
        }

        public bool SearchMember(string username, string password)
        {
            //var query = $"SELECT * FROM logindata WHERE username = '{username}'";
            //bool result = DataAccess.SaveData(query);

            if (true)
                return true;
            else
                return false;
        }
    }
}
