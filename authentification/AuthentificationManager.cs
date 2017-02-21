using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Chat_Application.Model.Authentification
{
    interface AuthentificationManager
    {
        void addUser(String login, String password);
        void removeUser(String login);
        bool authentify(String login, String password);
        ContextStaticAttribute AuthentificationManagementLoad(String path);
        void save();
        void load();


    }
}
