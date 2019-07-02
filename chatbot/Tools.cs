using chatbot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatbot
{
    class Tools
    {

        public static ChatMessage GetHighterScoreResponse(List<ChatMessage> responses)
        {
            ChatMessage highter = responses[0];
            int scoreHighter = 0;

            foreach (ChatMessage res in responses)
            {
                if (res.score > scoreHighter)
                {
                    scoreHighter = res.score;
                    highter = res;
                }
            }
            return highter;
        }

    }
}
