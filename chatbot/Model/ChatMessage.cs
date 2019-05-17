using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatbot.Model
{
    public class ChatMessage
    {
        public Guid Id { get; set; }
        public IUser owner { get; set; }
        public string content { get; set; }
        public int score { get; set; }
        public List<ChatMessage> responses { get; set; }

        public ChatMessage(IUser owner, string content)
        {
            this.Id = Guid.NewGuid();
            this.owner = owner;
            this.content = content;
            this.score = 0;
            this.responses = new List<ChatMessage>();
        }
    }
}
