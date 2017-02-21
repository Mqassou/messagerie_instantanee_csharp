using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class TextChatRoom : ChatRoom
    {
        private String topic;
        private List<Chatter> listChatter;

        public TextChatRoom()
        {
            topic = "DefaultTopic";
            listChatter = new List<Chatter> (); 
        }

        public TextChatRoom(String topic)
        {
            this.topic = topic;
            listChatter = listChatter = new List<Chatter>();
        }

        public TextChatRoom(String topic, Chatter c)
        {
            this.topic = topic;
            listChatter.Add(c);
        }

     

        public void join(Chatter c)
        {

            if (!listChatter.Contains(c))
            {
                listChatter.Add(c);
               Console.WriteLine("(Message from Chatroom : " + topic + ") " + c.getAlias() + " has join the room.");
                for (int i = 0; i < listChatter.Count; i++)
                {
                    listChatter[i].joinNotification(c);
                }
            }


            /*
            System.Console.WriteLine(" Le pseudo : " +c.getAlias() + " vient de joindre le topic : "+this.topic);
            listChatter.Add(c); */

        }

        public void post(string msg, Chatter c)
        {

            if (listChatter.Contains(c))
            {
                for (int i = 0; i < listChatter.Count; i++)
                {
                  listChatter[i].receiveAMessage(msg, c);
                   
                }
            }
            else
            {
               Console.WriteLine("ERROR : message \"" + msg + "\" could not be sent. Sender " + c.getAlias() + " not in the chatroom");
            }

            //System.Console.WriteLine(c.getAlias() + " : " + msg);
        }

        public void quit(Chatter c)
        {

            if (!listChatter.Contains(c))
            {
                listChatter.Remove(c);
               
                Console.WriteLine("(Message from Chatroom : " + topic + ") " + c.getAlias() + " has join the room.");
                for (int i = 0; i < listChatter.Count; i++)
                {
                    listChatter[i].quitNotification(c);
                }
            }

        }
    }
}
