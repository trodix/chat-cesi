using System;
using chatbot.Model;
using NUnit.Framework;

[TestFixture]
public class TestChatMessage
{
	public TestChatMessage()
	{
        Bot bot1 = new Bot();
        string myMessage = "Message de test 1";
        ChatMessage chatMessage1 = new ChatMessage(bot1, myMessage);
	}

    [Test]
    public void testSatanize()
    {
        string msg = "coucou... !'";
        string msgExpected = "coucou... !'";
        Assert.IsFalse(msg == msgExpected);
    }
}
