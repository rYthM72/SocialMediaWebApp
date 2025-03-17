using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SocialMediaWebApp.Models
{
    public class SocialMediaUser : IdentityUser
    {
        public List<UserPostContent> UserPostContents { get; set; } = new List<UserPostContent>();
        public List<UserGroup> UserGroups { get; set; } = new List<UserGroup>();
        public List<PostUpvote> Upvotes { get; set; } = new List<PostUpvote>();
        public List<PostDownVote> DownVotes { get; set; } = new List<PostDownVote>();
    }
}
