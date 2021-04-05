using Float.DataModels;
using Float.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Float.Services.IServices
{
    public interface IMemberService
    {
        Task<SignupDataModel> RegisterUserAsync(SignupModel request, CancellationToken cancellationToken);
        Task<UserAccountDataModel> AuthenticateUserAsync(UserAccountModel request, CancellationToken cancellationToken);
    }
}
