namespace SocialMediaWebApp.Entities
{
    public class PostDownVote
    {
        public string SocialMediaUserId { get; set; }
        public int PostId { get; set; }
        public SocialMediaUser SocialMediaUser { get; set; } = new SocialMediaUser();
        public Post Post { get; set; } = new Post();
    }
}