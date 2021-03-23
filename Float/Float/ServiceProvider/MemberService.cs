using Float.Services.IServices;
using System;
using DataAccess.DBHelper;
using System.Net.Http;
using DataAccess;
using System.Threading.Tasks;
using Float.DataModels;
using Newtonsoft.Json;

namespace Float.Services
{
    public class MemberService : IMemberService
    {
        public async Task<string> RegisterUserAsync(SignupDataModel data)
        {
            try
            {
                using (HttpResponseMessage response = await 
                    HttpClientHelper.ApiClient.PostAsJsonAsync(ApiRouteAddress.GetSignupResource(), data))
                {
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        return response.RequestMessage.ToString();
                    }
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return string.Empty;


            //using (MySqlConnection connection = OperateDb.GetConnection())
            //{
            //    connection.Open();
            //    var query = "INSERT INTO logindata (username,password) VALUES (@username, @password)";

            //    var dp = new DynamicParameters();
            //    dp.Add("@username", username);
            //    dp.Add("@password", password);
            //    int result = connection.Execute(query, dp);

            //    if (result > 0)
            //        return true;
            //    else
            //        return false;
            //}
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
