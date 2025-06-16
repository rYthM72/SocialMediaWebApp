using Microsoft.AspNetCore.Mvc;
using SocialMediaWebApp.Dtos.Account;

namespace SocialMediaWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        public AuthController()
        {
            
        }
        [HttpPost, Route("user-register")]
        public async Task<IActionResult> RegisterUser(RegisterDto registerDto)
        {
            
        }
    }
}
