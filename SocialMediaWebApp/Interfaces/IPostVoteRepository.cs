namespace SocialMediaWebApp.Interfaces
{
    public interface IPostVoteRepository
    {
        Task<bool> PostUpvote(int postId);
        Task<int> CountVotes(int postId);
        Task<bool> PostDownVote(int postId);
    }
}

