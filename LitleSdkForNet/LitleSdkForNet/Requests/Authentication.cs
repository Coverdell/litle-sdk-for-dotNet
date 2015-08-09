using System;
using System.Security;

namespace Litle.Sdk.Requests
{
    public class Authentication
    {
        public string User;
        public string Password;

        public String Serialize()
        {
            return "\r\n<authentication>\r\n<user>" + SecurityElement.Escape(User) + "</user>\r\n<password>" +
                   SecurityElement.Escape(Password) + "</password>\r\n</authentication>";
        }
    }
}