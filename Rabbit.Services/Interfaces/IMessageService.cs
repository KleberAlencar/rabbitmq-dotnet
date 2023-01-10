using Rabbit.Models.Entities;

namespace Rabbit.Services.Interfaces
{
    public interface IMessageService
    {
        void SendMessage(Message message);
    }
}