using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMediaWebApp.Dtos.Account;
using SocialMediaWebApp.Interfaces;
using SocialMediaWebApp.Models;

namespace SocialMediaWebApp.Controllers
{
    [Route("/api/[Controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly UserManager<SocialMediaUser> _userManager;
        private readonly ITokenService _tokenService;

        private readonly SignInManager<SocialMediaUser> _signInManager;
        public AccountController(UserManager<SocialMediaUser> userManager, SignInManager<SocialMediaUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
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

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName.ToLower());
            if (user == null) return Unauthorized("Invalid UserName!");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized("UserName not found or password incorrect");

            return Ok(
                new NewUserDto
                {
                    Token = _tokenService.CreateToken(user),
                    UserName = user.UserName,
                    Email = user.Email,

                });

        }

    }
}
