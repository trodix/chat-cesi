using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatbot.Model
{
    public class Chat
    {
        public List<IUser> Users { get; set; }

        public Chat()
        {
            this.Users = new List<IUser>();
        }
    }
}
