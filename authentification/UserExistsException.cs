using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Application.Model.Authentification
{
    class UserExistsException : Exception{
        public UserExistsException(String login)
        {
            Console.WriteLine("User "+login+" already exist");
        }
    }
}
