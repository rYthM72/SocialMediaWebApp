using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMediaWebApp.Models;

namespace SocialMediaWebApp.Data
{
    public class ApplicationDbContext:IdentityDbContext<SocialMediaUser>
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<UserPostContent> UserPostContents { get; set; }
        public DbSet<ContentComment> ContentComments { get; set; }
    }
}
