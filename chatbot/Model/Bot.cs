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
                string satanized = ChatMessage.satanize(message.content);
                //Console.WriteLine("owner : " + message.owner.GetType().Name);
                if (satanized.Contains(ChatMessage.satanize(msg.content)) & message.owner.GetType().Name == "Human")
                {
                    
                    return true;
                }
            }

            return false;
        }

        public List<ChatMessage> ContainResponse(ChatMessage msg)
        {

            foreach (ChatMessage message in listMessages)
            {
                foreach(ChatMessage resp in message.responses)
                {
                    string satanized = ChatMessage.satanize(resp.content);
                    //Console.WriteLine("owner : " + message.owner.GetType().Name);
                    if (satanized.Contains(ChatMessage.satanize(msg.content)) & message.owner.GetType().Name == "Bot")
                    {
                        List<ChatMessage> list = new List<ChatMessage>();
                        list.Add(message);
                        list.Add(resp);

                        return list;
                    }
                }
                
            }

            return null;
        }
    }
}
