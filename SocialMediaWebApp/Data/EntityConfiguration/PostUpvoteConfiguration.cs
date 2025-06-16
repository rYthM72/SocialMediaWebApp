using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMediaWebApp.Entities;

namespace SocialMediaWebApp.Data.EntityConfiguration
{
    public class PostUpvoteConfiguration : IEntityTypeConfiguration<PostUpvote>
    {
        public void Configure(EntityTypeBuilder<PostUpvote> builder)
        {
            builder.
                HasKey(x => new { x.PostId, x.SocialMediaUserId });

            builder.
                HasOne(x => x.SocialMediaUser).
                WithMany(x => x.Upvotes).
                HasForeignKey(x => x.SocialMediaUserId).
                OnDelete(DeleteBehavior.NoAction);

            builder.
                HasOne(x => x.Post).
                WithMany(x => x.Upvotes).
                HasForeignKey(x => x.PostId).
                OnDelete(DeleteBehavior.Cascade);// doesnot delete the upvote row if user gets deleted but removes if the post gets deleted
        }
    }
}
