using Rabbit.Models.Entities;

namespace Rabbit.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        void SendMessage(Message message);
    }
}