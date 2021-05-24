using System;
using System.Collections.Generic;
using System.Text;

namespace UI_for_Project.Controller
{
    class confirmLogin
    {
        private string Username;
        private string Password;

        
        public confirmLogin(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public string confirm_Login()
        {
            if (this.Username.ToString() == "admin" && this.Password.ToString() == "admin")
            {
                return "admin";
            }
            else if (this.Username.ToString() == "user" && this.Password.ToString() == "user")
            {
                return "user";
            }
            else
            {
                return "none";
            }
        }
    }
}
