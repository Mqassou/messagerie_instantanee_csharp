using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    interface TopicsManager
    {
         List<String> listTopics();
        ChatRoom joinTopic(String topic);
        void createTopic(String topic);
    }
       
}
