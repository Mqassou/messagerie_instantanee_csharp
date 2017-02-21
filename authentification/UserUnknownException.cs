using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Application.Model.Authentification
{
    class UserUnknownException : Exception
    {
        public UserUnknownException(String login)
        {
            Console.WriteLine("User "+login+" doesn't exists");
        }
    }
}
