using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;

namespace SimpleChat.SignalR.Hubs
{
    public class MessageHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            var success = Context.GetHttpContext()
                .Request
                .Query
                .TryGetValue("access_token", out StringValues token);

            if (success)
                await SendMessageAsync("System", $"A user connected to the chat. User token: '{token}'.");

            await base.OnConnectedAsync();
        }

        public async Task SendMessageAsync(string username, string message)
        {
            await Clients.All.SendAsync("SendMessage", username, message);
        }
    }
}
