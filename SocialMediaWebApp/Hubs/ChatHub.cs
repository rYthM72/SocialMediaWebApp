
using Microsoft.AspNetCore.SignalR;

namespace SocialMediaWebApp.Hubs
{
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await this.Clients.All.SendAsync("ReceivedMessage", $"{Context.ConnectionId} has joined");
        }
        public async Task SendMessage(string userId, string message)
        {
            await this.Clients.User(userId).SendAsync("ReceivedMessage", $"{message}");
        }
    }
}