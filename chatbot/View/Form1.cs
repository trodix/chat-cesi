﻿using chatbot.Model;
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
        public ChatMessage PreviousMessage;

        public Form1()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            this.myChat = new Chat();
            this.bot = new Bot();
            this.human = new Human();

            myChat.Users.Add(bot);
            myChat.Users.Add(human);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string input = textBox1.Text;
            write("User: " + input);
            ChatMessage msg = new ChatMessage(human, input);
            bool isKnown = bot.ContainMessage(msg);
            Debug.WriteLine(isKnown);
            if (isKnown)
            {
                msg.score++;
                ChatMessage InDatabaseMsg = bot.listMessages.Find(
                    r => msg.content == r.content
                );
                Debug.WriteLine(InDatabaseMsg.content);
                if (InDatabaseMsg.responses.Count > 0)
                {
                    ChatMessage Response = InDatabaseMsg.responses[0];
                    Debug.WriteLine(Response.content);
                    write("Bot: " + Response.content);
                } else
                {
                    PreviousMessage.responses.Add(msg);
                }

            } else
            {
                bot.listMessages.Add(msg);
            }

            PreviousMessage = msg;
        }

        public void write(string payload)
        {
            richTextBox1.AppendText(payload);
            richTextBox1.AppendText(Environment.NewLine);
        }
    }
}
