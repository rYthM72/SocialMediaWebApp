using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMediaWebApp.Data.EntityConfiguration;
using SocialMediaWebApp.Models;
using System.Reflection.Emit;

namespace SocialMediaWebApp.Data
{
    public class ApplicationDbContext:IdentityDbContext<SocialMediaUser>
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<UserPostContent> UserPostContents { get; set; }
        public DbSet<ContentComment> ContentComments { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<PostUpvote> PostUpvotes { get; set; }
        public DbSet<PostDownVote> PostDownVotes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            new UserPostContentConfiguration().Configure(builder.Entity<UserPostContent>());

            builder.Entity<PostUpvote>().HasKey(x => new {x.PostId, x.UserId});
            builder.Entity<PostUpvote>()
                .HasOne(x => x.Content)
                .WithMany(x => x.Upvotes)
                .HasForeignKey(x => x.PostId);
            builder.Entity<PostUpvote>()
                .HasOne(x => x.User)
                .WithMany(x => x.Upvotes)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<PostDownVote>().HasKey(x => new { x.PostId, x.UserId });
            builder.Entity<PostDownVote>()
                .HasOne(x => x.Content)
                .WithMany(x => x.DownVotes)
                .HasForeignKey(x => x.PostId);
            builder.Entity<PostDownVote>()
                .HasOne(x => x.User)
                .WithMany(x => x.DownVotes)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserGroup>().HasKey(x => new { x.PostId, x.UserId });
            builder.Entity<UserGroup>()
                .HasOne(x => x.Content)
                .WithMany(u => u.UserGroups)
                .HasForeignKey(x => x.PostId);
            builder.Entity<UserGroup>()
                .HasOne(x => x.User)
                .WithMany(u => u.UserGroups)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);



            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
