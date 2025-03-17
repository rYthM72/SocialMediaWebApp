namespace SocialMediaWebApp.Models
{
    public class PostDownVote
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int PostId { get; set; }
        public SocialMediaUser User { get; set; }
        public UserPostContent Content { get; set; }
    }
}