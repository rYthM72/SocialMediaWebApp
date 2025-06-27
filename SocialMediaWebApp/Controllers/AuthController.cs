using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaWebApp.Dtos.Account;
using SocialMediaWebApp.Model;
using SocialMediaWebApp.Repository;
using System.Security.Claims;

namespace SocialMediaWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;
        public AuthController(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }
        [HttpPost, Route("user-register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser(RegisterModel registerModel)
        {
            await _authRepository.RegisterUser(registerModel);
            return Ok("USer has been created.");
        }
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
                throw new Exception("Username or password cannot be null.");
            ClaimsIdentity claimsIdentity = new();
            var claimType = "username";
            var principal = User;
            if (!principal.HasClaim(claim => claim.Type == claimType))
            {
                claimsIdentity.AddClaim(new Claim("username", model.Username));
            }
            principal.AddIdentity(claimsIdentity);
            await _authRepository.Login(model.Username, model.Password);
            var claimData = await _authRepository.GetClaimData(model.Username);
            var tempToken = _authRepository.GenerateToken(claimData);
            return Ok(new
            {
                AccessToken = tempToken.ToString(),
                ExpiresIn = Convert.ToInt32(_configuration["JwtExpireDays"]) * 24 * 60
            });
        }
    }
}
