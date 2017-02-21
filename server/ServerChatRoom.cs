using projet_chat_efrei.model.net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1;

namespace projet_chat_efrei.model.server
{
    class ServerChatRoom : TCPServer, Chatter
    {
        private String pseudo;
        //private String password;
        private TextChatRoom textChatroom;

        public ServerChatRoom(ChatRoom chatroom)
        {
            this.textChatroom = (TextChatRoom)chatroom;
        }

    public override void gereClient()
        {
            try
            {
                Message inputMessage;
                while ((inputMessage = getMessage()) != null)
                {
                    //Message inputMessage = getMessage();
                    switch (inputMessage.getHead())
                    {
                        case Header.Join:
                            pseudo = inputMessage.getData()[0];
                            textChatroom.join(this);
                           
                            break;
                        case Header.Post:
                            String message = inputMessage.getData()[1];
                            textChatroom.post(message, this);                        
                            break;
                        case Header.Quit:
                            Chatter c = new TextChatter(inputMessage.getData()[0]);
                            textChatroom.quit(c);
                         
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public String getAlias()
        {
            return pseudo;
        }

        public String receiveAMessage(String _message, Chatter c)
        {
            List<String> data = new List<String>(2);
            data.Add(c.getAlias());
            data.Add(_message);
            try
            {
                sendMessage(new Message(Header.Receive, data));
                Console.WriteLine(_message);
            } catch (IOException e)
            {
                Console.WriteLine(e);
            }
            return _message;
        }

        public String joinNotification(Chatter c)
        {
            String _message = "";
            List<String> data = new List<String>(1);
            data.Add(c.getAlias());
            try
            {
                sendMessage(new Message(Header.Joined, data));
            }
            catch (IOException e)
            {
                Console.WriteLine(e);

            }
            return _message;
        }

            public String quitNotification(Chatter c)
        {
            String _message = "";
            List<String> data = new List<String>(1);
            data.Add(c.getAlias());
            try
            {
                sendMessage(new Message(Header.Left, data));
            }
            catch (IOException e)
            {
               Console.WriteLine(e);
               
            }

            return _message;
        }
    }
    }

    

