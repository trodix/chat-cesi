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

        public Form1()
        {
            InitializeComponent();
            init();
            // Activate Keyboard press detection
            KeyPreview = true;
            KeyDown += new KeyEventHandler(Form1_KeyDown);
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

            string input = textBox1.Text;

            if (ChatMessage.satanize(input) != "")
            {
                write("User: " + input);
                ChatMessage msg = new ChatMessage(human, input);
                bool isKnown = bot.ContainMessage(msg);

                Debug.WriteLine(isKnown);

                if (isKnown)
                {
                    ChatMessage botMsg = bot.listMessages.Find(
                        r => ChatMessage.satanize(msg.content).Equals(ChatMessage.satanize(r.content))
                    );
                    botMsg.score++;

                    Debug.WriteLine(botMsg.content);

                    //previousMessage.responses.Add(msg);
                    botMsg.responses.Add(previousMessage);

                    Debug.WriteLine(botMsg.content);

                    write("Bot : " + Tools.GetHighterScoreResponse(botMsg.responses).content);
                }
                else
                {
                    ChatMessage Response = Tools.GetHighterScoreResponse(bot.listMessages);
                    write("Bot: " + Response.content);
                    bot.listMessages.Add(msg);
                }

                previousMessage = msg;
                textBox1.Text = "";
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);

                e.SuppressKeyPress = true;
            }
        }

        public void write(string payload)
        {
            richTextBox1.AppendText(payload);
            richTextBox1.AppendText(Environment.NewLine);
        }
    }
}
