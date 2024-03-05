using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace TravelAggregator.Service.Services;

public class CacheService
{
    private readonly IDistributedCache _redisService;

    public CacheService(IDistributedCache redisService)
    {
        _redisService = redisService;
    }

    /// <summary>
    /// Sets string data to cache
    /// </summary>
    /// <param name="key">database key</param>
    /// <param name="data">data to store</param>
    /// <param name="absoluteExpireTime">absolute expire time</param>
    /// <param name="slidingExpireTime">sliding expire time</param>
    public async Task SetToCacheAsync<T>(string key, T data, TimeSpan? absoluteExpireTime = null, TimeSpan? slidingExpireTime = null)
    {
        var options = new DistributedCacheEntryOptions();

        options.AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromMinutes(10);
        options.SlidingExpiration = slidingExpireTime;

        var stringData = JsonConvert.SerializeObject(data);
        await _redisService.SetStringAsync(key, stringData, options);
    }

    /// <summary>
    /// Obtains data from cache
    /// </summary>
    /// <param name="key">identifier from cache</param>
    public async Task<T> GetFromCacheAsync<T>(string key)
    {
        var stringData = await _redisService.GetStringAsync(key);

        if (string.IsNullOrEmpty(stringData))
        {
            return default;
        }

        return JsonConvert.DeserializeObject<T>(stringData);
    }
}
