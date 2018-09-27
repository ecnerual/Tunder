using System;
using System.Linq;
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

        public User GetById(long id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}