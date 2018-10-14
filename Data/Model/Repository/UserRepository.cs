using System;
using System.Linq;
using System.Threading.Tasks;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using tunder.Model.DbContext;

namespace tunder.Model.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TunderDbContext _dbContext;

        public UserRepository(TunderDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        
        public async Task<User> GetById(long id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Email == email);
        }

        public Task<bool> UserExists(string email)
        {
            return _dbContext.Users.AnyAsync(user => user.Email == email);
        }

        public async Task<User> CreateUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public void Save()
        {
            _dbContext.SaveChangesAsync();
        }
    }
}