using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaWebApp.Data;
using SocialMediaWebApp.Dtos.UserGroup;
using SocialMediaWebApp.Interfaces;

namespace SocialMediaWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserGroupController : Controller
    {
        private readonly IUserGroupRepository _userGroupRepository;
        public UserGroupController(IUserGroupRepository userGroupRepository)
        {
            _userGroupRepository = userGroupRepository;
        }
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _userGroupRepository.GetAllGroup();
            return Ok(list);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var group = await _userGroupRepository.GetById(id);
            return Ok(group);
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] GroupCreateDto groupDetailsDto)
        {
             await _userGroupRepository.CreateGroup(groupDetailsDto);
            return Ok();
        }
        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> Update([FromBody] GroupUpdateDto groupDetailsDto)
        {
            await _userGroupRepository.UpdateGroup(groupDetailsDto);
            return Ok();
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _userGroupRepository.DeleteGroup(id);
            return Ok();

        }
    }
}
