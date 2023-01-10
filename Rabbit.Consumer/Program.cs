using System.Text;
using RabbitMQ.Client;
using System.Text.Json;
using RabbitMQ.Client.Events;
using Rabbit.Models.Entities;

var factory = new ConnectionFactory() {
    HostName = "localhost",
    UserName = "user",
    Password = "mypass"
};

using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "messagesQueue", 
                         durable: false, 
                         exclusive: false, 
                         autoDelete: false, 
                         arguments: null);

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) => {
        var body = ea.Body.ToArray();
        var messageJson = Encoding.UTF8.GetString(body);
      
        Message message = JsonSerializer.Deserialize<Message>(messageJson);

        System.Threading.Thread.Sleep(1000);

        Console.WriteLine($"Id: {message.Id}, Title: {message.Title}, Text: {message.Text}");
    };         

    channel.BasicConsume(queue: "messagesQueue", 
                         autoAck: true, 
                         consumer: consumer);
                         
    Console.WriteLine(" Press [Enter] to exit");
    Console.ReadLine();           
}
