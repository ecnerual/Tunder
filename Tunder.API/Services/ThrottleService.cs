using System.Threading.Tasks;
using Data.Model;

namespace Tunder.API.Services
{
    public class ThrottleService : IThrottleService
    {
        public void LogFailLoginAttempt(User user)
        {
            //TODO log by email / ip ?  distributed cache !
        }

        public Task<int> GetFailLoginFailAttempt(User user)
        {
            return new Task<int>(() => 1);
        }
    }
}