using System.Threading.Tasks;
using Data.Model;

namespace Tunder.API.Services
{
    public interface IThrottleService
    {
        void LogFailLoginAttempt(User user);
        Task<int> GetFailLoginFailAttempt(User user);
    }
}