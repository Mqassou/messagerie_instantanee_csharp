using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;

namespace projet_chat_efrei.model.net
{
    class TCPClient : MessageConnection
    {

      TcpClient client;
       private String adr;
       private int port;

        public TCPClient()
        {

        }

        public bool connect(String addr, int port)
        {
            bool connection = false;
            try
            {
                client = new TcpClient(addr, port);
                connection = true;
                Console.WriteLine("====== CLIENT ======>>>>>>  connexion au server...");
                NetworkStream n = client.GetStream();
                Console.WriteLine("====== CLIENT ======>>>>>> connexion acceptée ! ");
                return connection;
            }
            catch(SocketException e )
            {
                return connection;
            }
          
   
         

        }

        public void setServer(String _adr, int _port)
        {
            this.adr = _adr;
            this.port = _port;
        }
            

        public void disconnect()
        {
            client.Close();
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
           
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(client.GetStream(), m);
            Console.WriteLine("====== CLIENT ======>>>>>> Message envoyé !");
            //  client.Close();
            // Console.ReadKey();

        }

        public String getAdress()
        {
            return this.adr;
        }

        public int getPort()
        {
            return this.port;
        }




    }
}
