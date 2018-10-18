using CommonCode.Messages;
using System.Threading.Tasks;

namespace Tunder.API.Services
{
    public interface INotificationService
    {
        Task SendNotification(BaseMessage message);
    }
}