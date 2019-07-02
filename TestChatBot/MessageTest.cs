using System;
using chatbot.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class MessageTest
    {
        
        [TestMethod]
        public void testSatanize()
        {
            string msg = "coucou... !'";
            string result = ChatMessage.satanize(msg);
            Assert.IsFalse(msg.Equals(result));
        }

        [TestMethod]
        public void testIsKnownBot()
        {
            Bot bot1 = new Bot();
            ChatMessage myMessage = new ChatMessage(bot1, "msg1");

            bool isKnown = bot1.ContainMessage(myMessage);
            Assert.IsFalse(isKnown);

            bot1.listMessages.Add(myMessage);

            isKnown = bot1.ContainMessage(myMessage);
            Assert.IsFalse(isKnown);
        }

        [TestMethod]
        public void testIsKnownHuman()
        {
            Bot bot1 = new Bot();
            Human human1 = new Human();
            ChatMessage myMessage = new ChatMessage(human1, "msg1");

            bool isKnown = bot1.ContainMessage(myMessage);
            Assert.IsFalse(isKnown);

            bot1.listMessages.Add(myMessage);

            isKnown = bot1.ContainMessage(myMessage);
            Assert.IsTrue(isKnown);
        }
    }
}
