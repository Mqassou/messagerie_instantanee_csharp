using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class TextChatter : Chatter
    {

        private String pseudo;
        public TextChatter()
            {
            pseudo = "DefautChatter";
            }

        public TextChatter(String pseudo)
        {
            this.pseudo = pseudo;
        }

        public string getAlias()
        {
            return pseudo;
        }

        public String receiveAMessage(string msg, Chatter c)
        {
            return c.getAlias() + " : " +msg;
        }

        public String joinNotification(Chatter c)
        {
            return c.getAlias() + " Joined";
        }

        
    public String quitNotification(Chatter c)
        {
            return c.getAlias() + " Disconnected";
        }

    }
}
