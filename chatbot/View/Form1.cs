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
using log4net;

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
            Response();
        }

        public void Write(string payload, string pUserType)
        {
            MessageBox msg = new MessageBox(payload, pUserType);

            msg.BringToFront();
            msg.Enabled = true;
            msg.Visible = true;
            msg.Top = 0;
            msg.Left = 0;

            flowLayoutPanel1.Controls.Add(msg);
            flowLayoutPanel1.Enabled = true;
            flowLayoutPanel1.Visible = true;

            /*richTextBox1.AppendText(payload);
            richTextBox1.AppendText(Environment.NewLine);*/
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

                    Write(input, "human");

                    ChatMessage msg = new ChatMessage(human, input);

                    bool isKnown = bot.ContainMessage(msg);

                    if (isKnown)
                    {
                        ChatMessage botMsg = bot.listMessages.Find(
                            r => ChatMessage.satanize(msg.content).Equals(ChatMessage.satanize(r.content))
                        );

                        Write(botMsg.responses[0].content, "bot");
                    }
                    else
                    {

                        Write(bot.defaultMessage.content, "bot");
                        newer = true;
                        bot.listMessages.Add(msg);


                    }
                }
            }
            else
            {
                Write("Ecris quelque chose banane !", "bot");
            }
            
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            //richTextBox1.SelectionStart = richTextBox1.Text.Length;
            // scroll it automatically
            //richTextBox1.ScrollToCaret();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            flowLayoutPanel1.VerticalScroll.Value = flowLayoutPanel1.VerticalScroll.Maximum;
        }
    }
}
