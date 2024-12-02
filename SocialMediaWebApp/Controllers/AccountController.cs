using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialMediaWebApp.Dtos.Account;
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
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (string.IsNullOrWhiteSpace(registerDto.UserName) ||
                    !registerDto.UserName.All(c => char.IsLetterOrDigit(c)))
                {
                    return BadRequest("Username can only contain letters or digits.");
                }

                var appUser = new SocialMediaUser
                {
                    UserName = registerDto.UserName,
                    Email = registerDto.Email
                };
                 var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);
                Console.WriteLine(appUser);
                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok("User Created");
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }

            }   
            catch (Exception ex) {
                return StatusCode(500, ex);
            }
        }

    }
}
