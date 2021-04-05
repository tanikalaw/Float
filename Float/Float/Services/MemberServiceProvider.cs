using Float.Services.IServices;
using System;
using DataAccess.DBHelper;
using System.Net.Http;
using DataAccess;
using System.Threading.Tasks;
using Float.DataModels;
using Newtonsoft.Json;
using System.Collections;
using System.Windows;
using System.Threading;
using Float.Model;
using Float.ViewModelMediator;
using Float.GenericMessages;
using Float.BaseModel;

namespace Float.Services
{
    public class MemberServiceProvider : BaseViewModel, IMemberService
    {
        public async Task<SignupDataModel> RegisterUserAsync(SignupModel request, CancellationToken cancellationToken)
        {
            SignupDataModel signupDataModel = new SignupDataModel();
            ResponseModel responseModel = new ResponseModel();

            using (HttpResponseMessage response = await HttpClientHelper.ApiClient.PostAsJsonAsync(ApiRouteAddress.GetSignupResource(), request))
            {
                if (response.IsSuccessStatusCode)
                {
                    var httpStatusCode = response.StatusCode;

                    signupDataModel = JsonConvert.DeserializeObject<SignupDataModel>(response.Content.ReadAsStringAsync().Result);

                    return signupDataModel;
                }
                else
                {
                    var httpStatusCode = response.StatusCode;

                    responseModel = JsonConvert.DeserializeObject<ResponseModel>(response.Content.ReadAsStringAsync().Result);

                    ShowGenericMessage(responseModel.Message);

                 

                    return signupDataModel;
                }
            }
        }

        public async Task<UserAccountDataModel> AuthenticateUserAsync(UserAccountModel request, CancellationToken cancellationToken)
        {
            UserAccountDataModel signupDataModel = new UserAccountDataModel();
            _ = new ResponseModel();

            using (HttpResponseMessage response = await HttpClientHelper.ApiClient.PostAsJsonAsync(ApiRouteAddress.GetSignupResource(), request))
            {
                if (response.IsSuccessStatusCode)
                {
                    var httpStatusCode = response.StatusCode;

                    signupDataModel = JsonConvert.DeserializeObject<UserAccountDataModel>(response.Content.ReadAsStringAsync().Result);

                    return signupDataModel;
                }
                else
                {
                    var httpStatusCode = response.StatusCode;

                    ResponseModel responseModel = JsonConvert.DeserializeObject<ResponseModel>(response.Content.ReadAsStringAsync().Result);

                    ShowGenericMessage(responseModel.Message);

                    return signupDataModel;
                }
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
