using System;
using EasyNetQ;
using Messages;

namespace Receiver
{
    class Receiver
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.SendReceive.Receive<TextMessage>("myQueue", message => HandleOrderReplyMessage(message));
                Console.ReadLine();
            }
        }

        static void HandleOrderReplyMessage(TextMessage message)
        {
            //throw new Exception("Testing invalid message channel");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Received: " + message.Text);
            Console.ResetColor();
        }
    }
}
