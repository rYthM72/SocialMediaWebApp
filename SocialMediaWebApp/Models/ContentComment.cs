using System.ComponentModel.DataAnnotations;

namespace SocialMediaWebApp.Models
{
    public class ContentComment
    {
        [Key]
        public int ContentId { get; set; }
        public int MyProperty { get; set; }
        public string CommentContent { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
