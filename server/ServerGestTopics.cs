using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using projet_chat_efrei.model.net;
using Chat_Application.Model.Authentification;
using System.Runtime.Serialization.Formatters.Binary;

namespace projet_chat_efrei.model.server
{
    class ServerGestTopics : TCPServer
    {

        private TCPGestTopic tcpGestTopic = new TCPGestTopic();
        private Authentification auth = new Authentification();

        public ServerGestTopics()
        {

        }


        public override void gereClient()
        {
            //Console.WriteLine("Got Message"); 
            Message inputMessage;
            while ((inputMessage = getMessage()) != null)
            {
                //Console.WriteLine("Got Message2" + inputMessage.head);

                switch (inputMessage.getHead())
                {
                    case Header.List:

                        List<String> topics = tcpGestTopic.listTopics();
                        Message outputMessage1 = new Message(Header.List, topics);
                        sendMessage(outputMessage1);
                       

                        break;
                    case Header.Create:
                        //Console.WriteLine("Got Message 3");
                        tcpGestTopic.creerTopic(inputMessage.getData()[0]);
                        break;
                    case Header.Join:
                        Console.WriteLine("Classe ServerGestopics - methode gereClient() - case join \n\n");
                        String topicToJoin = inputMessage.getData()[0];
                        Message outputMessage3 = new Message(Header.Join, Convert.ToString(tcpGestTopic.getTopicPort(topicToJoin)));
                        sendMessage(outputMessage3);
                        break;

                   case Header.Connect:

                        if (auth.authentify(inputMessage.getData().ElementAt<string>(0), inputMessage.getData().ElementAt<string>(1)))
                        {
                            Message outputMessage4 = new Message(Header.AcceptConnection);
                            sendMessage(outputMessage4);
                        }
                        else
                        {
                            Message outputMessage4 = new Message(Header.DeniedConnection);
                            sendMessage(outputMessage4);
                        }
                        break;
                    case Header.CreateAccount:

                        auth.addUser(inputMessage.getData().ElementAt<string>(0), inputMessage.getData().ElementAt<string>(1));
                            Message outputMessage5 = new Message(Header.AcceptCreation);
                            sendMessage(outputMessage5);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
