using Float.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Float.Services.IServices
{
    public interface IMemberService
    {
        Task<string> RegisterUserAsync(SignupDataModel data);
        bool SearchMember(string username, string password);
    }
}
