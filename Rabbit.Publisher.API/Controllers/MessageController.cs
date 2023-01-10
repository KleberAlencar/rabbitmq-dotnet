using Rabbit.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Rabbit.Services.Interfaces;

namespace Rabbit.Publisher.API.Controllers;

[ApiController]
[Route("[controller]")]
public class MessageController : ControllerBase
{
    private readonly IMessageService _service;
    private readonly ILogger<MessageController> _logger;

    public MessageController(
        IMessageService service, 
        ILogger<MessageController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpPost]
    public void AddMessage(Message message)
    {
        _service.SendMessage(message);
    }
}
