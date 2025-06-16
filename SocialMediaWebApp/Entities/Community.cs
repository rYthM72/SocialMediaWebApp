using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMediaWebApp.Entities
{
    public class Community
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } 
        public string? Description { get; set; }
        public int? PostId { get; set; }
        public Post Content { get; set; }

        public string? SocialMediaUserId { get; set; }
        public SocialMediaUser? SocialMediaUser { get; set; }

        public List<UserCommunity> UserCommunities { get; set; } = new List<UserCommunity>();
    }
}