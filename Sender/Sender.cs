using EasyNetQ;
using Messages;

string connectionStr =
    "host=hare.rmq.cloudamqp.com;virtualHost=npaprqop;username=npaprqop;password=<type your password here>";

using (var bus = RabbitHutch.CreateBus(connectionStr))
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
