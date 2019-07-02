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

        public ChatMessage(IUser pOwner, string pContent)
        {
            Id = Guid.NewGuid();
            owner = pOwner;
            content = pContent;
            score = 0;
            responses = new List<ChatMessage>();
        }

        public static string satanize(string payload)
        {
            string cleanResponse = "";
            var charsToRemove = new string[] {",", ".", ";", "\'", " ", "?", "!" };

            cleanResponse = payload.ToLower();

            foreach (var c in charsToRemove)
            {
                cleanResponse = cleanResponse.Replace(c, string.Empty);
            }

            return payload;
        }
    }
}
