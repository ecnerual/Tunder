using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Data.Model.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Data.Model.Repository
{
    public class MatchActionRepository : IMatchActionRepository
    {
        private readonly TunderDbContext _tunderDbContext;

        public MatchActionRepository(TunderDbContext tunderDbContext)
        {
            _tunderDbContext = tunderDbContext;
        }

        public async Task<MatchAction> CreateMatchActionAsync(MatchAction matchAction)
        {
            await _tunderDbContext.MatchActions.AddAsync(matchAction);
            return matchAction;
        }

        public async Task<bool> IsFullMatchAsync(MatchAction matchAction)
        {
            var userIds = new[] {matchAction.LikedID, matchAction.LikerID};
            return await _tunderDbContext.MatchActions.AnyAsync(m =>
                userIds.Contains(m.LikedID) && userIds.Contains(m.LikerID));
        }

        public async Task<bool> SaveAsync()
        {
            return await _tunderDbContext.SaveChangesAsync() > 0;
        }
    }
}