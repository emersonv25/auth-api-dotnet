using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAuth.Models.Object
{
    public class ViewUser
    {
        public ViewUser(string username, string fullName, string email, string token)
        {
            this.User = new ViewUserData { Username = username, FullName = fullName, Email = email };
            this.Token = token;
        }

        public ViewUserData User { get; set; }
        public string Token { get; set; }
    }
    public class ViewUserData
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
