using CommonCode.Messages;
using System.Threading.Tasks;
using Data.Model;

namespace Tunder.API.Services
{
    public interface INotificationService
    {
        Task SendWelcomeMessage(User user);
    }
}