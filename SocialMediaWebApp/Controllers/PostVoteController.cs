using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaWebApp.Interfaces;

namespace SocialMediaWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostVoteController : Controller
    {
        private readonly IPostVoteRepository _postVoteRepository;
        public PostVoteController(IPostVoteRepository postVoteRepository)
        {
            _postVoteRepository = postVoteRepository;
        }
        [HttpGet]
        [Route("votecount")]
        public async Task<IActionResult> GetVote(int postId)
        {
            var voteCount = await _postVoteRepository.CountVotes(postId);
            return Ok(voteCount);
        }
        [HttpPost]
        [Route("upvote")]
        public async Task<IActionResult> Upvote(int postId)
        {
            bool upvote = await _postVoteRepository.PostUpvote(postId);
            if (upvote)
            {
                return Ok($"Upvote has been registered for the post {postId}");
            }
            return Ok("There is already an upvote registered for the post from the user");
        }
        [HttpPost]
        [Route("downvote")]
        public async Task<IActionResult> Downvote(int postId)
        {
            bool downvote = await _postVoteRepository.PostDownVote(postId);
            if (downvote)
            {
                return Ok($"Downvote has been registered for the post {postId}");
            }
            return Ok("There is already an downvote registered for the post from the user");
        }
    }
}