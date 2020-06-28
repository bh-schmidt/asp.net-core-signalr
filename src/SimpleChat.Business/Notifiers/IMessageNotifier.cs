using System.Threading.Tasks;

namespace SimpleChat.Business.Notifiers
{
    public interface IMessageNotifier
    {
        Task SendMessageAsync(string username, string message);
    }
}
