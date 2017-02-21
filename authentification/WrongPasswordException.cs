using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Application.Model.Authentification
{
    class WrongPasswordException : Exception
    {
        public WrongPasswordException()
        {
            Console.WriteLine("Wrong password");
        }
    }
}
