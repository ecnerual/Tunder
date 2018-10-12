using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tunder.Model.DbContext;

namespace tunder.Model.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ITunderDbContext _dbContext;

        public UserRepository(ITunderDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        
        public Task<User> GetById(long id)
        {
            return _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public Task<bool> UserExists(string email)
        {
            return _dbContext.Users.AnyAsync(user => user.Email == email);
        }

        public void Save()
        {
        }
    }
}