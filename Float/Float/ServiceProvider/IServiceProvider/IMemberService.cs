using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleCRUD.Services.IServices
{
    public interface IMemberService
    {
        bool AddMember(string username, string password);
        bool SearchMember(string username, string password);
    }
}
