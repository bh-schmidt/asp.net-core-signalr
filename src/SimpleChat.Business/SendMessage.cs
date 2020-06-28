using SimpleChat.Business.Notifiers;
using System.Threading.Tasks;

namespace SimpleChat.Business
{
    public class SendMessage : ISendMessage
    {
        private readonly IMessageNotifier messageNotifier;

        public SendMessage(
            IMessageNotifier messageNotifier)
        {
            this.messageNotifier = messageNotifier;
        }

        public async Task SendAsync(string username, string message)
        {
            await messageNotifier.SendMessageAsync(username, message);
        }
    }
}
