using System.Threading.Tasks;

namespace Data.Model.Repository
{
    public interface IUserRepository : IModelBaseEntityRepository
    {
        Task<User> GetByEmail(string email);
        Task<bool> UserExists(string email);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task Save();
    }
}