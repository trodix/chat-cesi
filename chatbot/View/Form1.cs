using chatbot.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chatbot
{
    public partial class Form1 : Form
    {
        public Chat myChat;
        public Bot bot;
        public Human human;
        public ChatMessage previousMessage;
        public static bool newer = false;

        public Form1()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            myChat = new Chat();

            bot = new Bot();

            human = new Human();

            myChat.Users.Add(bot);
            myChat.Users.Add(human);

            //Debug.WriteLine("*** NB MESSAGE : " + bot.listMessages.Count + " ***" );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (newer)
            {
                string input = textBox1.Text;
                textBox1.Text = "";

                write("User: " + input);

                newer = false;
                int size = bot.listMessages.Count();
                ChatMessage message = bot.listMessages[size - 1];
                message.responses.Add(new ChatMessage(bot, input));
            }
            else
            {
                string input = textBox1.Text;
                textBox1.Text = "";

                write("User: " + input);

                ChatMessage msg = new ChatMessage(human, input);

                bool isKnown = bot.ContainMessage(msg);

                if (isKnown)
                {
                    ChatMessage botMsg = bot.listMessages.Find(
                        r => ChatMessage.satanize(msg.content).Equals(ChatMessage.satanize(r.content))
                    );

                    write(botMsg.responses[0].content);
                }
                else
                {
                    
                    write("Bot: " + bot.defaultMessage.content);
                    newer = true;
                    bot.listMessages.Add(msg);
                   
                    
                }
            }
            
        }

        public void write(string payload)
        {
            richTextBox1.AppendText(payload);
            richTextBox1.AppendText(Environment.NewLine);
        }
    }
}
