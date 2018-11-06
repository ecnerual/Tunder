using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.Repository
{
    public interface IMatchRepository : IModelBaseEntityRepository
    {
        Task<IEnumerable<Match>> GetUserMatches(User user);
        Task<Match> CreateNewMatchAsync(Match match);
    }
}
