using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Model.DbContext;

namespace Data.Model.Repository
{
    public class MatchRepository : IMatchRepository
    {
        private readonly TunderDbContext _tunderDbContext;

        public MatchRepository(TunderDbContext tunderDbContext)
        {
            _tunderDbContext = tunderDbContext;
        }

        public Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByGuidAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Match>> GetUserMatches(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<Match> CreateNewMatchAsync(Match match)
        {
            await _tunderDbContext.Matches.AddAsync(match);
            return match;
        }
    }
}
