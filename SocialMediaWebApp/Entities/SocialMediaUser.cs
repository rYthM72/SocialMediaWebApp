using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SocialMediaWebApp.Entities
{
    public class SocialMediaUser : IdentityUser
    {
        public string Name { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Community> Communities { get; set; } = new List<Community>();
        public List<PostUpvote> Upvotes { get; set; } = new List<PostUpvote>();
        public List<PostDownVote> DownVotes { get; set; } = new List<PostDownVote>();
        public List<UserCommunity> UserCommunities { get; set; } = new List<UserCommunity>();
    }
}
