using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    interface ChatRoom
    {

        void post(String msg, Chatter c);

        void quit(Chatter c);

        void join(Chatter c);

      
    }
}
