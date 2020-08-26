using System.Threading.Tasks;

namespace WorkWithRedis
{
    public interface ICacheService
    {
        Task<string> GetCacheValue(string key);
        Task SetCacheValue(string key, string value);
    }
}