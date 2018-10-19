using System.Threading.Tasks;

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