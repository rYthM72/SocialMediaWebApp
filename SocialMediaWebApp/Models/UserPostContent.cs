using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMediaWebApp.Models
{
    public class UserPostContent
    {
        [Key]
        public int ContentId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedById { get; set; } 
        public SocialMediaUser SocialMediaUser { get; set; }
        public List<ContentComment> Comments { get; set; } = new List<ContentComment>();
        public List<UserGroup> UserGroups { get; set; } = new List<UserGroup>();
        public List<PostUpvote> Upvotes { get; set; } = new List<PostUpvote>();
        public List<PostDownVote> DownVotes { get; set; } = new List<PostDownVote>();

    }
}
