using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace projet_chat_efrei.model.net
{
    public enum Header
    {   CreateAccount,
        AcceptCreation,//le server accepte la création d'un nouveau compte utilisateur
        AcceptConnection, // Lorsque le client s'authentifie avec son login et son mdp, le server lui renvoie AcceptConnection , si la combinaison est bonne
        DeniedConnection,
        Connect,
        List,
        Create,
        Join,
        Post,
        Quit,
        Receive,
        Joined,
        Left
    };

    [Serializable()]
    class Message : ISerializable
    {
        private Header head;
       private List<String> data=new List<String>();

        public Message()
        {
          
        }

        public Message(Header head, String _data)
        {
            this.head = head;
            this.data.Add(_data);
        }

        public Message(Header head, List<String> _data)
        {
            this.head = head;
            this.data = _data;
        }

        public Message(Header head)
        {
            this.head = head;
        }


        //Deserialization constructor.
        public Message(SerializationInfo info, StreamingContext ctxt)
        {
            head = (Header)info.GetValue("head", typeof(Header));
            data = (List<String>)info.GetValue("data", typeof(List<String>));
        }

       public Header getHead()
        {
            return this.head;
        }

        public List<String> getData()
        {
            return this.data;
        }

    public override String ToString()
        {
            String message="";
            foreach(String m in this.data)
            {
                message = message + "\n" +m;
            }

            return "\nHeader : " + this.head + "\ndata : " + message;
        }

   

        public void addString(String text)
        {
            this.data.Add(text);
        }

        //Serialization.
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("head", head);
            info.AddValue("data", data);
        }

       
    }
}
