using SocialMediaWebApp.Dtos.UserPostContent;
using SocialMediaWebApp.Models;

namespace SocialMediaWebApp.Interfaces
{
    public interface IUserPostContentRepository
    {
        Task<List<UserPostContentDto>> GetAllPostsAsync();
        Task<UserPostContentDto> GetPostByIdAsync(int id);
        Task CreateUserPostContent(CreateUserPostContentDto content);
        Task UpdateUserPostContent(UpdateUserPostContentDto content);
        Task DeleteUserPostContent(int id);
    }
}
