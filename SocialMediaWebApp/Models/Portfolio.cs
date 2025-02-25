namespace SocialMediaWebApp.Models
{
    public class Portfolio
    {
        public string SocialMediaUserId { get; set; }
        public int UserPostContentId { get; set; }
        public virtual SocialMediaUser SocialMediaUser { get; set; }
        public virtual UserPostContent UserPostContent { get; set; }
    }
}
