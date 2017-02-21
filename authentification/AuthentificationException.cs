using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Application.Model.Authentification
{
    public class AuthentificationException : Exception
    {

        public AuthentificationException(String _login) {
            this.login = _login;
        }

        String login;
    }
   }
