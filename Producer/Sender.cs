// See https://aka.ms/new-console-template for more information

using System.Text;
using RabbitMQ.Client;

public class Sender
{
    public static void Main(string[] arg)
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost",
        };
        using (var connection = factory.CreateConnection())
        using ( var channel = connection.CreateModel())
        {
            channel.QueueDeclare("BasicTest", false, false, false, null);
            string message = "Hello World!";
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish("", "BasicTest", null, body);
            Console.WriteLine(" [x] Sent {0}", message);
        }    
        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
    }
}