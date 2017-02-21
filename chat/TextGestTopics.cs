using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class TextGestTopics : TopicsManager
    {
        private List<String> topics;

        public TextGestTopics()
        {       
            topics = new List<String>();
        }
        

        public void createTopic(String topic)
        {
            topics.Add(topic);
        }

        public ChatRoom joinTopic(String topic)
        {
            TextChatRoom ChatRoom= new TextChatRoom(topic);
            return ChatRoom;
        }

        public List<String> listTopics()
        {
          if(topics.Count!=0)
            {
                return topics;
            }
          else
            {
                List<String> noTopics = new List<String>();
                noTopics.Add("Aucun chat");
                return noTopics;

            }
      
           
        }

    }
}
