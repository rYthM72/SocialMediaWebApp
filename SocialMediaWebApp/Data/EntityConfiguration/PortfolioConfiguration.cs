using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SocialMediaWebApp.Models;

namespace SocialMediaWebApp.Data.EntityConfiguration
{
    public class PortfolioConfiguration: IEntityTypeConfiguration<Portfolio>
        {
            public void Configure(EntityTypeBuilder<Portfolio> builder)
            {
            builder.HasKey(p => new { p.SocialMediaUserId, p.UserPostContentId });

            builder
                .HasOne(x => x.SocialMediaUser)
                .WithMany(u => u.Portfolios)
                .HasForeignKey(x => x.SocialMediaUserId);

            builder
                .HasOne(x => x.UserPostContent)
                .WithMany(u => u.Portfolios)
                .HasForeignKey(x => x.UserPostContentId);
        } 


    } 
}
