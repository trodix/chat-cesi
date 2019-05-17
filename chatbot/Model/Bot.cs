using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatbot.Model
{
    public class Bot : IUser
    {
        public List<ChatMessage> listMessages { get; set; }
        public ChatMessage defaultMessage { get; set; }

        public Bot()
        {
            listMessages = new List<ChatMessage>();
            defaultMessage = new ChatMessage(this, "Entre une reponse au message precedent");
            listMessages.Add(defaultMessage);
        }

        public bool ContainMessage(ChatMessage msg)
        {

            foreach (ChatMessage message in listMessages)
            {
                if(message.content.Contains(msg.content))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
