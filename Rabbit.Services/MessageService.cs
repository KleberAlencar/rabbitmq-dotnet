using Rabbit.Models.Entities;
using Rabbit.Services.Interfaces;
using Rabbit.Repositories.Interfaces;

namespace Rabbit.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _repository;

        public MessageService(IMessageRepository repository)
        {
            _repository = repository;
        }

        public void SendMessage(Message message)
        {
            _repository.SendMessage(message);
        }
    }
}