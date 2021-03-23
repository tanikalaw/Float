using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public struct ApiRouteAddress
    {
        public static string GetSignupResource()
        {
            return $"api/v1/post/register";
        }
    }
}
