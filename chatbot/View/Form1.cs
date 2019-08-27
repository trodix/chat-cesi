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
using chatbot.Controller;

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
            // Activate Keyboard press detection
            KeyPreview = true;
            KeyUp += new KeyEventHandler(TextBox1_KeyUp);
            SessionControler.init();
            //SessionControler.getInstance().getLog().Info(DateTime.Now + " : init OK");

        }

        private void init()
        {
            myChat = new Chat();
            //bite 
            bot = new Bot();

            human = new Human();

            myChat.Users.Add(bot);
            myChat.Users.Add(human);

            //Debug.WriteLine("*** NB MESSAGE : " + bot.listMessages.Count + " ***" );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Response();
        }

        public void write(string payload)
        {
            richTextBox1.AppendText(payload);
            richTextBox1.AppendText(Environment.NewLine);
        }

        private void TextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Console.WriteLine("key enter");
                Response();
                e.SuppressKeyPress = true;
            }
        }

        private void Response()
        {
            string input = textBox1.Text;
            textBox1.Text = "";

            if(ChatMessage.satanize(input) != "")
            {
                if (newer)
                {

                    newer = false;
                    int size = bot.listMessages.Count();
                    ChatMessage message = bot.listMessages[size - 1];
                    message.responses.Add(new ChatMessage(bot, input));
                }
                else
                {
                    write("User: " + input);

                    ChatMessage msg = new ChatMessage(human, input);

                    bool isKnown = bot.ContainMessage(msg);

                    if (isKnown)
                    {
                        ChatMessage botMsg = bot.listMessages.Find(
                            r => ChatMessage.satanize(msg.content).Equals(ChatMessage.satanize(r.content))
                        );

                        write("Bot: " + botMsg.responses[0].content);
                        SessionControler session = SessionControler.getInstance();
                        //session.getLog().Error("bite");
                    }
                    else
                    {
                        write("Bot: " + bot.defaultMessage.content);
                        newer = true;
                        bot.listMessages.Add(msg);
                    }
                }
            }
            else
            {
                write("Bot: Ecris quelque chose banane !");
            }
            
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            // scroll it automatically
            richTextBox1.ScrollToCaret();
        }
    }
}
