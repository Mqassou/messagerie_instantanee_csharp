using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projet_chat_efrei.model.net;
using projet_chat_efrei.model.server;
using System.Threading;
using WindowsFormsApplication1;
using System.IO;

namespace projet_chat_efrei.model.client
{
    class ClientChatRoom : TCPClient, ChatRoom
    {
        private List<String>  names=new List<String> ();
        private List<String> messages = new List<String>();
        private Chatter chatter;


        public List<String> getMessages()
        {
          return messages;
        }
        public List<String> getNames()
        {
            return names;
        }

      

       

        public Chatter getChatter()
        {
            return chatter;
        }

        public void join(Chatter c)
        {
            try
            {
                sendMessage(new Message(Header.Join, c.getAlias()));
                chatter = c;
            }
            catch (IOException e)
            {
                Console.WriteLine(e);

            }
        }


        public void post(String msg, Chatter c)
        {
            //System.out.println("nous envoyons un message");
            Message message = new Message(Header.Post);
            message.addString(c.getAlias());
            message.addString(msg);
            try
            {
                //System.out.println("message en cours d'envoie");
                sendMessage(message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e);

            }
        }


        public void quit(Chatter c)
        {
            try
            {
                sendMessage(new Message(Header.Quit, c.getAlias()));
            }
            catch (IOException e)
            {
                Console.WriteLine(e);

            }
        }


        public void run()
        {
           
            try
            {
                bool doRun = true;
                Message message;
                while (doRun)
               {
                    Console.WriteLine("-----WAIT RUN ------- : ");
                    message = getMessage();
                   
                    Console.WriteLine("-----METHODE RUN ------- : " + message.getHead());
                    switch (message.getHead())
                    {
                        case Header.Joined:
                            names.Add(message.getData()[0]);
                            if (chatter != null)
                            {
                                messages.Add(chatter.joinNotification(new TextChatter(message.getData()[0])));
                                
                            }
                            Console.WriteLine(names);
                            break;
                        case Header.Receive:
                            //messages.Add(message);
                            if (chatter != null)
                            {
                                messages.Add(chatter.receiveAMessage(message.getData()[1], new TextChatter(message.getData()[0])));
                            }
                            Console.WriteLine("MESSAGE RECUE" + messages);
                            break;
                        case Header.Left:
                            names.Remove(message.getData()[0]);
                            if (chatter != null)
                            {
                                messages .Add(chatter.quitNotification(new TextChatter(message.getData()[0])));       

                            }
                          
                            break;
                    }
               }
                Console.WriteLine("End of while");
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }
            
        }

    }
}

