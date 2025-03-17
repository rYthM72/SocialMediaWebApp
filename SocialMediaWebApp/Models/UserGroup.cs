using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMediaWebApp.Models
{
    public class UserGroup
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } 
        public string? Description { get; set; }
        public int? PostId { get; set; }
        public UserPostContent Content { get; set; }

        public string? UserId { get; set; }
        public SocialMediaUser? User { get; set; }
    }
}