using Microsoft.AspNetCore.SignalR;

namespace SocialMediaWebApp.Hubs
{
    public interface NotificationClient
    {
        Task ReceiveNotification(string postTitle);
    }
    public class NotificationHub : Hub<NotificationClient>
    {
        public async Task CommentNotification(string postTitle)
        {
            await this.Clients.All.ReceiveNotification($"A new comment in your post {postTitle}");
        }

    }
}