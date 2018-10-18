using System.Threading.Tasks;
using Data.BusinessObject.Requests;
using Data.Model;

namespace Tunder.API.Services
{
    public interface IAuthService
    {
        Task<User> Register(UserRegisterDto userDto);
        Task<User> Login(string email, string password);
        Task<User> Logout(string email, string password);
        Task<User> ResumeSession(byte[] authToken);
    }
}
