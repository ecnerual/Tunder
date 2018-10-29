using System.Threading.Tasks;
using Data.Migrations;

namespace Data.Model.Repository
{
    public interface IMatchActionRepository
    {
        Task<MatchAction> CreateMatchActionAsync(MatchAction matchAction);
        Task<bool> IsFullMatchAsync(MatchAction matchAction);
        Task<bool> SaveAsync();
    }
}