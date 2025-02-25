using SocialMediaWebApp.Dtos.UserGroup;

namespace SocialMediaWebApp.Interfaces
{
    public interface IUserGroupRepository
    {
        Task<List<GroupListDto>> GetAllGroup();
        Task<GroupListDto> GetById(int id);
        Task CreateGroup(GroupCreateDto groupDto);
        Task UpdateGroup(GroupUpdateDto groupUpdateDto);
        Task DeleteGroup(int id);
    }
}
