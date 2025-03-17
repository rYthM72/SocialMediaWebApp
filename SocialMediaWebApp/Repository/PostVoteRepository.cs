using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialMediaWebApp.Data;
using SocialMediaWebApp.Interfaces;
using SocialMediaWebApp.Models;
using SocialMediaWebApp.Utilities;

namespace SocialMediaWebApp.Repository
{
    public class PostVoteRepository : IPostVoteRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<SocialMediaUser> _userManager;
        public PostVoteRepository(ApplicationDbContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        public async Task<int> CountVotes(int postId)
        {
            int upVotes = await _context.PostUpvotes.CountAsync(u => u.PostId == postId);
            int downVotes = await _context.PostDownVotes.CountAsync(u => u.PostId == postId);
            int countVotes = upVotes - downVotes;
            return countVotes;
        }

        public async Task<bool> PostDownVote(int postId)
        {
            var loggedInUser = GeneralUtility.GetUsernameFromClaim(_httpContext);
            var user = await _userManager.FindByNameAsync(loggedInUser);
            var exists = await _context.PostDownVotes.AnyAsync(x => x.PostId == postId && x.UserId == user.Id);
            if (!exists)
            {
                var downvote = new PostDownVote
                {
                    PostId = postId,
                    UserId = loggedInUser
                };
                await _context.PostDownVotes.AddAsync(downvote);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> PostUpvote(int postId)
        {
            var loggedInUser = GeneralUtility.GetUsernameFromClaim(_httpContext);
            var user = await _userManager.FindByNameAsync(loggedInUser);
            var exists = await _context.PostUpvotes.AnyAsync(x => x.PostId == postId && x.UserId == user.Id);
            if (!exists) { 
            var upvote = new PostUpvote
            {
                PostId = postId,
                UserId = GeneralUtility.GetUsernameFromClaim(_httpContext)
            };
            await _context.PostUpvotes.AddAsync(upvote);
            await _context.SaveChangesAsync();
                return true;
        }
            else { return false; }
        }
    }
}
