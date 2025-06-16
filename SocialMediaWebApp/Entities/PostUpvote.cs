namespace SocialMediaWebApp.Entities
{
    public class PostUpvote
    {
        public int Id { get; set; }
        public string SocialMediaUserId { get; set; }
        public int PostId { get; set; }
        public SocialMediaUser SocialMediaUser { get; set; } = new SocialMediaUser();
        public Post Post { get; set; } = new Post();
    }
}