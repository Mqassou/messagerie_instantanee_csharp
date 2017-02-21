using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1;
using projet_chat_efrei.model.net;
using System.Threading;

namespace projet_chat_efrei.model.client
{
    class ClientGestTopic : TCPClient, TopicsManager
    {
        String _login;

        public bool createUser(String login, String password)
        {
            List<String> data = new List<String>();
            data.Add(login);
            data.Add(password);
            Message message = new Message(Header.CreateAccount, data);
            try
            {
                sendMessage(message);
                message = getMessage();
                if (message.getHead() == Header.AcceptCreation)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;

            }

        }
        public bool authentificationUser(String login, String password)
        {
            List<String> data = new List<String>();
            data.Add(login);
            data.Add(password);
            Message message = new Message(Header.Connect, data);
            try
            {
                sendMessage(message);
               message= getMessage();
                if(message.getHead()==Header.AcceptConnection)
                {
                    _login = login;
                    return true;
                }
                else if(message.getHead() == Header.AcceptConnection)
                {
                    return false;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;

            }

        }
        public void createTopic(String topic)
        {
            Message message = new Message(Header.Create, topic);
            try
            {
                sendMessage(message);
            }
            catch (Exception e)
            {
               Console.WriteLine(e);
                
            }
        }

        
    public ChatRoom joinTopic(String topic)
        {
            Message message = new Message(Header.Join, topic);
            try
            {
                sendMessage(message);
               
                Message answer = getMessage();
                int port = int.Parse(answer.getData()[0]);
                ClientChatRoom chatroom = new ClientChatRoom();
                Console.WriteLine("VALEUR DE ADDRESSE : " + port);
                chatroom.connect(getAdress(), port);
                Thread thread = new Thread((chatroom.run)); 
                thread.Start();
                return chatroom;
            }
            catch (Exception e)
            {
               Console.WriteLine(e);
                return null;
            }
  

        }


    public List<String> listTopics()
        {
            Message message = new Message(Header.List);
            List<String> topics = null;
            try
            {
             
                sendMessage(message);
              
                Message answer = getMessage();
                topics = answer.getData();
                Console.WriteLine("liste des topic : " + topics.ElementAt<string>(0));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }
            return topics;
        }
    }
}
