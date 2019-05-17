using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatbot.Model
{
    public class ChatMessage
    {
        public IUser owner { get; set; }
        public string content { get; set; }

        public ChatMessage(IUser owner, string content)
        {
            this.owner = owner;
            this.content = content;
        }
    }
}
