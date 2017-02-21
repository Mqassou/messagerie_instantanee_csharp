using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Chat_Application.Model
{
    [Serializable]
    class User : ISerializable
    {


        private String name;
        private String password;

        public User()
        {
            this.name = "DefaultName";
            this.password = "DefaultPassword";
        }

        public User(String _name,String _password)
        {
            this.name = _name;
            this.password = _password;
        }

        public String getName()
        {
            return this.name;
        }

        public String getPassword()
        {
            return this.password;
        }


        //Deserialization constructor.
        public User(SerializationInfo info, StreamingContext ctxt)
        {
            name = (String)info.GetValue("name", typeof(String));
            password = (String)info.GetValue("password", typeof(String));
        }

        //Serialization function.
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("name", name);
            info.AddValue("password", password);
        }



    }
}
