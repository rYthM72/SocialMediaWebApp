using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMediaWebApp.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string SocialMediaUserId { get; set; } 
        public SocialMediaUser SocialMediaUser { get; set; } = new SocialMediaUser();
        public List<PostComment> PostComments { get; set; } = new List<PostComment>();
        public List<Community> Communities { get; set; } = new List<Community>();
        public List<PostUpvote> Upvotes { get; set; } = new List<PostUpvote>();
        public List<PostDownVote> DownVotes { get; set; } = new List<PostDownVote>();

    }
}
