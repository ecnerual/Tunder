using System;
using System.Threading.Tasks;

namespace Tunder.API.Services
{
    public interface ICachingService
    {
        Task<bool> SetValue(string key, string value, TimeSpan? expireTime);
        Task<long> IncrementValueFromKey(string key);
        Task<long> GetValueFromKey(string key);
    }
}