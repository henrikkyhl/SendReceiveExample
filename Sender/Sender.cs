using EasyNetQ;
using Messages;

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
