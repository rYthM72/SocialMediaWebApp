using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SocialMediaWebApp.Dtos.Account;
using SocialMediaWebApp.Entities;
using SocialMediaWebApp.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SocialMediaWebApp.Repository
{
    public interface IAuthRepository
    {
        Task RegisterUser(RegisterModel registerModel);
        Task<SocialMediaUser?> GetUserByUsername(string username);
        Task<bool> Login(string username, string password);
        Task<ClaimData> GetClaimData(string username);
        string GenerateToken(ClaimData claimData);

    }
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<SocialMediaUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<SocialMediaUser> _signInManager;
        public AuthRepository(UserManager<SocialMediaUser> userManager, IConfiguration configuration, SignInManager<SocialMediaUser> signInManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
        }

        public async Task RegisterUser(RegisterModel registerModel)
        {
            if (registerModel.ConfirmPassword != registerModel.Password)
            {
                throw new Exception("Password and Confirm Password donot match");
            }
            var user = await GetUserByUsername(registerModel.Username);
            if (user is null)
            {
                throw new Exception("Another user with this username already exists");
            }
            SocialMediaUser createUser = new SocialMediaUser
            {
                Name = registerModel.Name,
                UserName = registerModel.EmailAddress,
                Email = registerModel.EmailAddress,
                EmailConfirmed = true,
                NormalizedEmail = registerModel.EmailAddress.ToUpper(),
                NormalizedUserName = registerModel.EmailAddress.ToUpper(),
                TwoFactorEnabled = false,
            };
            try
            {
                IdentityResult result = await _userManager.CreateAsync(createUser, registerModel.Password);
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors?.FirstOrDefault()?.Description ?? "Error creating user");
                }
                IdentityResult addUserTORoleResult = await _userManager.AddToRoleAsync(createUser, "SocialMediaUser");
                if (!addUserTORoleResult.Succeeded)
                {
                    throw new Exception(addUserTORoleResult.Errors?.FirstOrDefault()?.Description ?? "Error adding user to role");
                }
            }
            catch
            {
                throw;
            }
        }
        public async Task<ClaimData> GetClaimData(string username)
        {
            var user = await GetUserByUsername(username) ?? throw new Exception("Invalid Username");
            var userClaimData = new ClaimData
            {
                Username = username,
                UserId = user.Id
            };
            return userClaimData;
        }
        public async Task<SocialMediaUser?> GetUserByUsername(string username)
        {
            SocialMediaUser? user = await _userManager.FindByNameAsync(username);
            return user;
        }

        public async Task<bool> Login(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, true, false);
            return result.Succeeded;
        }
        public string GenerateToken(ClaimData claimData)
        {
            var claims = new List<Claim>
        {
            new(ClaimTypes.Email, !string.IsNullOrEmpty(claimData.Username) ? claimData.Username : ""),
            new("UserId", claimData.UserId.ToString()),
        };
            var jwtKey = _configuration["JwtKey"] ?? throw new Exception("Unable to load JWT KEY!");
            var jwtExpireDays = _configuration["JwtExpireDays"] ?? throw new Exception("Unable to load JWT Expire day!");
            var jwtIssuer = _configuration["Issuer"] ?? throw new Exception("Unable to load JWT Issuer!");
            var jwtAudience = _configuration["Audience"] ?? throw new Exception("Unable to load JWT Audience!");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creeds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.Now.AddDays(Convert.ToDouble(jwtExpireDays));

            var token = new JwtSecurityToken(
                jwtIssuer,
                jwtAudience,
                claims,
                expires: expires,
                signingCredentials: creeds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
