using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    interface Chatter
    {
        String receiveAMessage(String msg, Chatter C);
        String getAlias();
        String joinNotification(Chatter c);
        String quitNotification(Chatter c);

    }
}

