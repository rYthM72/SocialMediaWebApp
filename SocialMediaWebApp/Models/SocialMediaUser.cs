using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SocialMediaWebApp.Models
{
    public class SocialMediaUser : IdentityUser
    {
        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
        public List<UserGroup> UserGroups { get; set; } = new List<UserGroup>();

    }
}
