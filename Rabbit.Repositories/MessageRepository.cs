using System.Text;
using RabbitMQ.Client;
using System.Text.Json;
using Rabbit.Models.Entities;
using Rabbit.Repositories.Interfaces;

namespace Rabbit.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        public void SendMessage(Message message)
        {
            var factory = new ConnectionFactory() 
            {
                HostName = "localhost",
                UserName =  "user",
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

                string messageJson = JsonSerializer.Serialize(message);
                var body = Encoding.UTF8.GetBytes(messageJson);

                channel.BasicPublish(exchange: "", 
                                     routingKey: "messagesQueue", 
                                     basicProperties: null, 
                                     body: body);
            }
        }
    }
}