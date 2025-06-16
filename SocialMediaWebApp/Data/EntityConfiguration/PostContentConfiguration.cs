using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SocialMediaWebApp.Entities;

namespace SocialMediaWebApp.Data.EntityConfiguration
{
    public class PostContentConfiguration: IEntityTypeConfiguration<Post>
        {
            public void Configure(EntityTypeBuilder<Post> builder)
            {
            builder
            .HasOne(x => x.SocialMediaUser)
            .WithMany(x => x.Posts)
            .HasForeignKey(x => x.SocialMediaUserId)
            .OnDelete(DeleteBehavior.NoAction);
        } 
    } 
}
