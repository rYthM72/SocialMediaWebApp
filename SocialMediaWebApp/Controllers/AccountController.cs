using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialMediaWebApp.Models;

namespace SocialMediaWebApp.Controllers
{
    [Route("/api/[Controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly UserManager<SocialMediaUser> _userManager;
        public AccountController(UserManager<SocialMediaUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {

        }

    }
}
