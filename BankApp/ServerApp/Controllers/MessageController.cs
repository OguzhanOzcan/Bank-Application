using ServerApp.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ServerApp.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ServerApp.Controllers
{
    [ApiController]
    [Route("api/contact")]
    [Authorize]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository _messageRepositry;
        public MessageController(IMessageRepository messageRepository)
        {
            _messageRepositry = messageRepository;
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] Message message)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized();

            message.MessageSender = int.Parse(userIdClaim.Value);
            message.CreatedAt = System.DateTime.UtcNow;

            await _messageRepositry.AddMessageAsync(message);
            return Ok(new { succes = true, message = "Mesajınız başarıyla gönderildi." });
        }
        [HttpGet]
        public async Task<ActionResult<List<Message>>> GetMyMessages()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
                return Unauthorized();

            int userId = int.Parse(userIdClaim.Value);
            var message = await _messageRepositry.GetMessagesByCustomerIdAsync(userId);
            return Ok(message);
        }
    }
}
