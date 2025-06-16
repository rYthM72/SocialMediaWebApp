using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMediaWebApp.Data.EntityConfiguration;
using SocialMediaWebApp.Entities;
using SocialMediaWebApp.Entities;
using System.Reflection.Emit;

namespace SocialMediaWebApp.Data
{
    public class ApplicationDbContext:IdentityDbContext<SocialMediaUser>
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostDownVote> PostDownVotes { get; set; }
        public DbSet<PostUpvote> PostUpvotes { get; set; }
        public DbSet<UserCommunity> UserCommunities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            new PostContentConfiguration().Configure(builder.Entity<Post>());
            new PostUpvoteConfiguration().Configure(builder.Entity<PostUpvote>());
            new PostDownVoteConfiguration().Configure(builder.Entity<PostDownVote>());
            new UserCommunityConfiguration().Configure(builder.Entity<UserCommunity>());


            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "SocialMediaUser",
                    NormalizedName = "SOCIALMEDIAUSER"
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
