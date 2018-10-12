using System.Threading.Tasks;

namespace tunder.Model.Repository
{
    public interface IUserRepository  
    {
        Task<User> GetById(long id);
        Task<bool> UserExists(string email);
        void Save();
    }
}