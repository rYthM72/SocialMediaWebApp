using System.ComponentModel.DataAnnotations;

namespace SocialMediaWebApp.Entities

{
    public class PostComment
    {
        [Key]
        public int PostId { get; set; }
        [Required]
        public string SocialMediaUserId { get; set; }
        public string CommentContent { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public Post Post { get; set; } = new Post();
        public SocialMediaUser SocialMediaUser { get; set; } = new SocialMediaUser();
    }
}
