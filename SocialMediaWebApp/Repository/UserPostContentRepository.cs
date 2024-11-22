using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SocialMediaWebApp.Data;
using SocialMediaWebApp.Dtos.UserPostContent;
using SocialMediaWebApp.Interfaces;
using SocialMediaWebApp.Mappers;
using SocialMediaWebApp.Models;

namespace SocialMediaWebApp.Repository
{
    public class UserPostContentRepository : IUserPostContentRepository
    {
        private readonly ApplicationDbContext _context;
        public UserPostContentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserPostContentDto>> GetAllPostsAsync()
        {
            var posts = await _context.UserPostContents.OrderByDescending(a => a.CreatedOn).ToListAsync();
            var postDto = posts.Select(s => s.ToUserPostContentDto()).ToList();
            return postDto;
        }

        public async Task<UserPostContentDto> GetPostByIdAsync(int id)
        {
            var posts = await _context.UserPostContents.FirstOrDefaultAsync(a => id == a.ContentId);
            return posts.ToUserPostContentDto();
        }

        public async Task CreateUserPostContent(CreateUserPostContentDto postContent)
        {
            UserPostContent content = new UserPostContent();
            var posts = UserPostContentMapper.ToCreateUserPostContentDto(postContent);
            content.CreatedOn = DateTime.Now;
            await _context.UserPostContents.AddAsync(posts);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserPostContent(UpdateUserPostContentDto content)
        {
            UserPostContent postContent = new UserPostContent();
            var posts = _context.UserPostContents.FirstOrDefault(x => x.ContentId == content.ContentId);
            postContent.Title = content.Title;
            postContent.Content = content.Content;
            postContent.ModifiedOn = DateTime.Now;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserPostContent(int id)
        {
            var posts = _context.UserPostContents.FirstOrDefault(x => x.ContentId == id);
            _context.UserPostContents.Remove(posts);
            await _context.SaveChangesAsync();
        }
    }
}