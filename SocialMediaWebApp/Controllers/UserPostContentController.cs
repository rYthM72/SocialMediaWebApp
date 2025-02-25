using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMediaWebApp.Data;
using SocialMediaWebApp.Dtos.UserPostContent;
using SocialMediaWebApp.Interfaces;
using SocialMediaWebApp.Mappers;
using SocialMediaWebApp.Repository;

namespace SocialMediaWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserPostContentController : Controller
    {
        private readonly IUserPostContentRepository _userPosts;
        private readonly ILogger<UserPostContentController> _logger;
        public UserPostContentController(IUserPostContentRepository userPosts, ILogger<UserPostContentController> logger)
        {
            _userPosts = userPosts;
            _logger = logger;
        }
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _userPosts.GetAllPostsAsync();
            return Ok(posts);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPostById([FromRoute] int id)
        {
            try
            {
                var posts = await _userPosts.GetPostByIdAsync(id);
                return Ok(posts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> PostUserContent([FromBody] CreateUserPostContentDto createUserPost)
        {
            await _userPosts.CreateUserPostContent(createUserPost);
            return Ok("The post has been created");
        }

        [HttpPut]
        [Route("update")]

        public async Task<IActionResult> UpdateUserContent(UpdateUserPostContentDto updateUserPost)
        {
            await _userPosts.UpdateUserPostContent(updateUserPost);
            return Ok("The post has been updated");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteUserContent([FromRoute]int id)
        {
            await _userPosts.DeleteUserPostContent(id);
            return Ok("The post has been updated");
        }
    }
}