using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace chatbot.Model
{
    [DataContract]
    class MessageJSON
    {
        public void ConvertForWrite(List<ChatMessage> pListMessages)
        {
            listMessages = new List<ChatMessage>();

            foreach (ChatMessage message in pListMessages)
            {
                listMessages.Add(message);
            }
        }

        public void ConvertForRead(ref List<ChatMessage> pListMessages)
        {

        }

        [DataMember]
        public List<ChatMessage> listMessages;
    }
}
