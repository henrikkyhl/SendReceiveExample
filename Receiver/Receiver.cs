using EasyNetQ;
using Messages;

string connectionStr =
    "host=hare.rmq.cloudamqp.com;virtualHost=npaprqop;username=npaprqop;password=<type your password here>";

using (var bus = RabbitHutch.CreateBus(connectionStr))
{
    bus.SendReceive.Receive<TextMessage>("myQueue", message => HandleOrderReplyMessage(message));
    Console.ReadLine();
}

void HandleOrderReplyMessage(TextMessage message)
{
    //throw new Exception("Testing invalid message channel");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Received: " + message.Text);
    Console.ResetColor();
}
