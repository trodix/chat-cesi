using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chatbot
{
    public partial class MessageBox : UserControl
    {
        public Image picUser = Image.FromFile("A:/GoogleDrive/2 - CESi/Projet/Chatbot/chat-cesi/chatbot/Assets/user1.png");
        public Image picBot = Image.FromFile("A:/GoogleDrive/2 - CESi/Projet/Chatbot/chat-cesi/chatbot/Assets/bot.png");

        public MessageBox()
        {
            InitializeComponent();
        }

        public MessageBox(string pMessage, string pUserType)
        {
            InitializeComponent();

            if (pUserType == "bot")
            {
                pictureBox1.Image = picBot;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                //pictureBox1.Top = 0;
                pictureBox1.Left = 0;
                //richTextBox1.Top = 0;
                richTextBox1.Left = 100;

                richTextBox1.BackColor = Color.DarkViolet;
            }
            else if (pUserType == "human")
            {
                pictureBox1.Image = picUser;
            }

            richTextBox1.AppendText(pMessage);
            richTextBox1.AppendText(Environment.NewLine);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
