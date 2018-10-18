using System.Threading.Tasks;
using Data.Model;

namespace Data.Model.Repository
{
    public interface IUserRepository  
    {
        Task<User> GetById(long id);
        Task<User> GetByEmail(string email);
        Task<bool> UserExists(string email);
        Task<User> CreateUser(User user);
        void Save();
    }
}