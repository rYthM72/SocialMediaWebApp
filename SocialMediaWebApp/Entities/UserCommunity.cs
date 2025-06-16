using System.ComponentModel.DataAnnotations;

namespace SocialMediaWebApp.Entities
{
    public class UserCommunity
    {
        public string SocialMediaUserId { get; set; }
        public int CommunityId { get; set; }
        public SocialMediaUser SocialMediaUser { get; set; } = new SocialMediaUser();
        public Community Community { get; set; } = new Community();
    }
}
