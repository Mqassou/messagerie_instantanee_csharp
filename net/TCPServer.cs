using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using projet_chat_efrei.model.net;
using System.Runtime.Serialization.Formatters.Binary;

namespace projet_chat_efrei
{
    abstract class TCPServer : MessageConnection
    {
        TcpListener listen;
        TcpClient client;

        public TCPServer()
        {

        }

        public void startServer(int port)
        {
         /* System.Net.IPAddress ipaddress = System.Net.IPAddress.Parse("192.168.0.8");  
            listen = new TcpListener(ipaddress, port);*/
           listen = new TcpListener(IPAddress.Any, port);
            Console.WriteLine("======SERVER======>>>>>>  En attente d'un client ...");
            listen.Start();
            new Thread(new ThreadStart(run)).Start();
        }
        public void stopServer()
        {
            listen.Stop();
        }


         void run()
        {
            while (true)
            {
                client = listen.AcceptTcpClient();
                Console.WriteLine("======SERVER======>>>>>>  Client connecté ");
                // NetworkStream stream = client.GetStream();
                TCPServer Clone = (TCPServer) this.MemberwiseClone();
                new Thread(new ThreadStart((Clone.gereClient))).Start();


                
            }
          



        }

        public Message getMessage()
        {
      
            BinaryFormatter bformatter = new BinaryFormatter();
           
            projet_chat_efrei.model.net.Message mess = new projet_chat_efrei.model.net.Message();
            mess = (projet_chat_efrei.model.net.Message)bformatter.Deserialize(client.GetStream());

            return mess;
        }

        public void sendMessage(Message m)
        {
           
            Console.WriteLine("-----Fonction sendMessage classe TCPServer---- \n\n");
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(client.GetStream(), m);
            Console.WriteLine("Message envoyé !");
            // client.Close();
            //Console.ReadKey();


        }

        public int getPort()
        {
            IPEndPoint local = (IPEndPoint) listen.LocalEndpoint;
            int port = local.Port;
            return port;
        }


        abstract public void gereClient();
    }
}
