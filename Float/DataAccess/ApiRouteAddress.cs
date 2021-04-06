using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public struct ApiRouteAddress
    {
        public static string SignupUserResource()
        {
            return $"api/v1/user/register";
        }

        public static string AuthenticateUserResource()
        {
            return $"/api/v1/user/authenticate";
        }
    }
}
