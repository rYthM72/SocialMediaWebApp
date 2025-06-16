using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMediaWebApp.Entities;

namespace SocialMediaWebApp.Data.EntityConfiguration
{
    public class UserCommunityConfiguration : IEntityTypeConfiguration<UserCommunity>
    {
        public void Configure(EntityTypeBuilder<UserCommunity> builder)
        {
            builder.
                HasKey(x => new { x.CommunityId, x.SocialMediaUserId });

            builder.
                HasOne(x => x.SocialMediaUser).
                WithMany(x => x.UserCommunities).
                HasForeignKey(x => x.SocialMediaUserId).
                OnDelete(DeleteBehavior.Cascade);

            builder.
                HasOne(x => x.Community).
                WithMany(x => x.UserCommunities).
                HasForeignKey(x => x.CommunityId).
                OnDelete(DeleteBehavior.Cascade);
        }
    }
}
