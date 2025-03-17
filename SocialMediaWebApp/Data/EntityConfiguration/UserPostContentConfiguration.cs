using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SocialMediaWebApp.Models;

namespace SocialMediaWebApp.Data.EntityConfiguration
{
    public class UserPostContentConfiguration: IEntityTypeConfiguration<UserPostContent>
        {
            public void Configure(EntityTypeBuilder<UserPostContent> builder)
            {
            builder
            .HasOne(x => x.SocialMediaUser)
            .WithMany(x => x.UserPostContents)
            .HasForeignKey(x => x.CreatedById)
            .OnDelete(DeleteBehavior.NoAction);
        } 
    } 
}
