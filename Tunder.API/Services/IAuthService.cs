using System.Threading.Tasks;
using Data.BusinessObject.Requests;
using Data.Model;

namespace Tunder.API.Services
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(UserRegisterDto userDto);
        Task<User> LoginAsync(string email, string password);
        Task<User> Logout(string email, string password);
        Task<User> ResumeSession(byte[] authToken);
    }
}
