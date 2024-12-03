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
        public UserPostContentController(IUserPostContentRepository userPosts)
        {
            _userPosts = userPosts;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _userPosts.GetAllPostsAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById([FromRoute] int id)
        {
            var posts = await _userPosts.GetPostByIdAsync(id);
            return Ok(posts);
        }

        [HttpPost]
        public async Task<IActionResult> PostUserContent([FromBody] CreateUserPostContentDto createUserPost)
        {
            await _userPosts.CreateUserPostContent(createUserPost);
            return Ok("The post has been created");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserContent(UpdateUserPostContentDto updateUserPost)
        {
            await _userPosts.UpdateUserPostContent(updateUserPost);
            return Ok("The post has been updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserContent([FromRoute]int id)
        {
            await _userPosts.DeleteUserPostContent(id);
            return Ok("The post has been updated");
        }
    }
}