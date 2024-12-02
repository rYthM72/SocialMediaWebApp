using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SocialMediaWebApp.Models
{
    public class SocialMediaUser : IdentityUser
    {
        [Key]
        public int UserId { get; set; }
        public override string UserName { get; set; } = string.Empty;
        public override string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
