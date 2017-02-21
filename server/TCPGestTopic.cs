using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1;


namespace projet_chat_efrei.model.server
{
    class TCPGestTopic : TextGestTopics
    {
        private static int nextPort = 1600;
        private Dictionary<String, ServerChatRoom> tcpChatrooms = new Dictionary<String, ServerChatRoom>();




        public void creerTopic(String topic)
        {
            try
            {
                base.createTopic(topic);
                ChatRoom chatroom = base.joinTopic(topic);
                ServerChatRoom serverChatroom = new ServerChatRoom(chatroom);
                tcpChatrooms.Add(topic, serverChatroom);
                bool started = true;
               
                do
                {
                    try
                    {
                        serverChatroom.startServer(nextPort);
                        started = true;
                    }
                    catch (IOException e)
                    {
                        started = false;
                        
                    }
                   nextPort++;
                    //Console.WriteLine("in while");
                } while (!started);
                //Console.WriteLine("off while");
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
                
            }
        }

        public int getTopicPort(String topic)
        {
            ServerChatRoom value;
            if (tcpChatrooms.TryGetValue(topic, out value) == true)
            {
                {
                    return value.getPort();
                }
            }
            else
            {
                return 0;
            }
        }

    }
}
