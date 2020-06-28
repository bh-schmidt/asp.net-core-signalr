using Microsoft.AspNetCore.SignalR;
using SimpleChat.Business.Notifiers;
using SimpleChat.SignalR.Hubs;
using System.Threading.Tasks;

namespace SimpleChat.Api.Notifiers
{
    public class MessageNotifier : IMessageNotifier
    {
        private readonly IHubContext<MessageHub> hubContext;

        public MessageNotifier(IHubContext<MessageHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        public async Task SendMessageAsync(string username, string message)
        {
            await hubContext.Clients.All.SendAsync("SendMessage", username, message);
        }
    }
}
