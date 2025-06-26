using System.ComponentModel.DataAnnotations;

namespace SocialMediaWebApp.Dtos.Account
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required] 
        public string Password { get; set; }
    }
}
