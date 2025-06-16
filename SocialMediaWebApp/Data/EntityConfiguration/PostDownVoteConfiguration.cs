using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMediaWebApp.Entities;

namespace SocialMediaWebApp.Data.EntityConfiguration
{
    public class PostDownVoteConfiguration : IEntityTypeConfiguration<PostDownVote>
    {
        public void Configure(EntityTypeBuilder<PostDownVote> builder)
        {
            builder.
                HasKey(x => new { x.PostId, x.SocialMediaUserId });

            builder.
                HasOne(x => x.SocialMediaUser).
                WithMany(x => x.DownVotes).
                HasForeignKey(x => x.SocialMediaUserId).
                OnDelete(DeleteBehavior.NoAction);

            builder.
                HasOne(x => x.Post).
                WithMany(x => x.DownVotes).
                HasForeignKey(x => x.PostId).
                OnDelete(DeleteBehavior.Cascade);// doesnot delete the downvote row if user gets deleted but removes if the post gets deleted
        }
    }
}
