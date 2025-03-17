namespace SocialMediaWebApp.Dtos.UserPostContent
{
    public class CreateUserPostContentDto
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
    public class UserPostContentDto : CreateUserPostContentDto
    {
        public int ContentId { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    public class UpdateUserPostContentDto : CreateUserPostContentDto
    {
        public int ContentId { get; set; }
    }
}
