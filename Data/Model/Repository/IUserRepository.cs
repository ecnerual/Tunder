using System.Threading.Tasks;

namespace tunder.Model.Repository
{
    public interface IUserRepository  
    {
        Task<User> GetById(long id);
        Task<bool> UserExists(string email);
        Task<User> CreateUser(User user);
        void Save();
    }
}