using Microsoft.AspNetCore.Mvc;
using SimpleChat.Business;

namespace SimpleChat.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : Controller
    {
        private readonly ISendMessage sendMessage;

        public MessageController(ISendMessage sendMessage)
        {
            this.sendMessage = sendMessage;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost("{username}/send-message")]
        public IActionResult SendMessage([FromRoute] string username, [FromBody]string message)
        {
            sendMessage.SendAsync(username, message);
            return Ok();
        }
    }
}
