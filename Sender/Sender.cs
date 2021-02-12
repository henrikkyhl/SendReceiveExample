using System;
using EasyNetQ;
using Messages;

namespace Sender
{
    class Sender
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                var input = "";
                Console.WriteLine("Enter a message. 'Quit' to quit.");
                while ((input = Console.ReadLine()) != "Quit")
                {
                    bus.SendReceive.Send<TextMessage>("myQueue", new TextMessage
                    {
                        Text = input
                    });
                }
            }
        }
    }
}
