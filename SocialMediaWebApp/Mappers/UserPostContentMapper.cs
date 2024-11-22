using SocialMediaWebApp.Dtos.UserPostContent;
using SocialMediaWebApp.Models;

namespace SocialMediaWebApp.Mappers
{
    public static class UserPostContentMapper
    {
        public static UserPostContentDto ToUserPostContentDto(this UserPostContent postContent)
        {
            return new UserPostContentDto
            {
                ContentId = postContent.ContentId,
                Title = postContent.Title,
                Content = postContent.Content,
                CreatedOn = postContent.CreatedOn,
                ModifiedOn = postContent.ModifiedOn,
            };
        }
        public static UserPostContent ToCreateUserPostContentDto(this CreateUserPostContentDto postContentDto)
        {
            return new UserPostContent
            {
                Title = postContentDto.Title,
                Content = postContentDto.Content,
            };
        }
    }
}