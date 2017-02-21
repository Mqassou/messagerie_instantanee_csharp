using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace projet_chat_efrei.model.net
{
    interface MessageConnection
    {

        Message getMessage() ;
        void  sendMessage(Message m) ;
    }
}
