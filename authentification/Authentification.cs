using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat_Application.Model;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Chat_Application.Model.Authentification
{
    [Serializable]
    class Authentification : AuthentificationManager
    {

        private List<User> users = new List<User>();
        String path_file="list_user";

        public Authentification()
        {

            if (File.Exists(path_file))
            {
                load();
            }

            else
            {
                save();
            }
        }



        public void addUser(string login, string password) 
        {
            load();
           
            if (users.Contains(new User(login, password)))
            {
                throw new UserExistsException(login);
            }
            else
            {
                users.Add(new User(login, password));
                Console.WriteLine(login + " has been added ! ");
                save();
            }
            
        }

        public void removeUser(string login)
        {
          
            bool found = false;
            foreach (User u in users.ToArray())
            {
                if (u.getName().Equals(login))
                {
                    this.users.Remove(u);
                    found = true;
                }
            }
            if (found == true)
            {
                Console.WriteLine(login + " has been removed ! ");
            }
            else
            {
                throw new UserUnknownException(login);
            }

        }

        public ContextStaticAttribute AuthentificationManagementLoad(string path) 
        {
            throw new NotImplementedException();
        }

        public bool authentify(string login, string password)
        {
         
            bool test = false;
            foreach (User u in users.ToArray())
            {
                
                if ((u.getName().Equals(login)) && (u.getPassword().Equals(password)))
                {
                    test = true;
                    return test;
                }
                else if((u.getName().Equals(login)) && !(u.getPassword().Equals(password)))
                {
                   // throw new WrongPasswordException();
                }

            }
            
      
            return test;
        }

       

        public void save()
        {
            Stream stream = File.Open(path_file, FileMode.Create);
            MemoryStream memorystream = new MemoryStream();
            BinaryFormatter bformatter = new BinaryFormatter();
            
            Console.WriteLine("Writing users Information");
            bformatter.Serialize(stream, users);
           
            stream.Close();


        }


        public void load()
        {
            Stream stream = File.Open(path_file, FileMode.Open);
            MemoryStream memorystream = new MemoryStream();
            BinaryFormatter bformatter = new BinaryFormatter();
            Console.WriteLine("Reading users Information");
            users = (List<User>)bformatter.Deserialize(stream);
            stream.Close();
        }
    }
}
