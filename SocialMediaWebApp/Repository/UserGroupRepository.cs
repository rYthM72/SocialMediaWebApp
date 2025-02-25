using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SocialMediaWebApp.Data;
using SocialMediaWebApp.Dtos.UserGroup;
using SocialMediaWebApp.Interfaces;
using SocialMediaWebApp.Models;

namespace SocialMediaWebApp.Repository
{
    public class UserGroupRepository : IUserGroupRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UserGroupRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateGroup(GroupCreateDto groupDto)
        {
            UserGroup group = _mapper.Map<UserGroup>(groupDto);
            await _context.UserGroups.AddAsync(group);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGroup(int id)
        {
            UserGroup? group = await _context.UserGroups.FirstOrDefaultAsync(g => g.Id == id);
            if (group == null)
            {
                throw new KeyNotFoundException("The group doesnot exist");
            }
            _context.UserGroups.Remove(group);
            await _context.SaveChangesAsync();
        }

        public async Task<List<GroupListDto>> GetAllGroup()
        {
            List<UserGroup> groupList = await _context.UserGroups.ToListAsync();
            List<GroupListDto> groupListDto = _mapper.Map<List<GroupListDto>>(groupList);
            return groupListDto;
        }

        public async Task<GroupListDto> GetById(int id)
        {
            UserGroup? group = await _context.UserGroups.FirstOrDefaultAsync(x => x.Id == id);
            if (group == null)
            {
                throw new KeyNotFoundException("The group doesnot exist");
            }
            GroupListDto groupDto = _mapper.Map<GroupListDto>(group);
            return groupDto;
        }

        public async Task UpdateGroup(GroupUpdateDto groupUpdateDto)
        {
            UserGroup? group = await _context.UserGroups.FirstOrDefaultAsync(x => x.Id == groupUpdateDto.Id);
            if (group == null)
            {
                throw new KeyNotFoundException("The group doesnot exist");
            }
            group.Name = groupUpdateDto.Name;
            group.Description = groupUpdateDto.Description;
            await _context.SaveChangesAsync();
        }
    }
}
