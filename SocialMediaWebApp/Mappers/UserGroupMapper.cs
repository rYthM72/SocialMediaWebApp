using AutoMapper;
using SocialMediaWebApp.Dtos.UserGroup;
using SocialMediaWebApp.Models;

namespace SocialMediaWebApp.Mappers
{
    public class UserGroupMapper : Profile
    {
        public UserGroupMapper() 
        {
            CreateMap<UserGroup, GroupListDto>();
            CreateMap<GroupCreateDto, UserGroup>();
            CreateMap<GroupUpdateDto, UserGroup>();
        }
    }
}
