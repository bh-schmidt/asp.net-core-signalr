using System.Threading.Tasks;

namespace SimpleChat.Business
{
    public interface ISendMessage
    {
        Task SendAsync(string username, string message);
    }
}
