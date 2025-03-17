using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Mvc;
using SocialMediaWebApp.Hubs;

namespace SocialMediaWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessageController : Controller
    {
        private readonly ChatHub _hub;

        public MessageController(ChatHub hub)
        {
            _hub = hub;
        }

        [Route("send/{userId}")]
        public async Task<IActionResult> SendMessageToUser([FromRoute]string userId, string message)
        {
            await _hub.SendMessage(userId, message);
            return Ok();
        }
    }
}
