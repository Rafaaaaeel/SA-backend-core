using Microsoft.EntityFrameworkCore.Storage;

namespace Sa.Core.Cache;

public class ClientDistribuitedCache : IClientCache
{
    private readonly ICoreCacheService _cacheService;
    private readonly CacheConfiguration _cacheConfiguration;
    private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions();

    public ClientDistribuitedCache(AppSettings appSettings, ICoreCacheService cacheService)
    {   
        _cacheConfiguration = appSettings.cacheConfiguration;
        _cacheService = cacheService;
    }

    public async Task<T> AsyncGetCachedObject<T>(string key, CancellationToken cancellationToken = default)
    {
        var cachedData = await _cacheService.GetStringAsync(key, cancellationToken) ?? throw new NullReferenceException();

        T? response = System.Text.Json.JsonSerializer.Deserialize<T>(cachedData) ?? throw new NullReferenceException();

        return response;
    }

    public async Task AsyncSetCacheObject<T>(string key, T data, CancellationToken cancellationToken = default)
    {
        DistributedCacheEntryOptions options = new() 
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMilliseconds(_cacheConfiguration.ExpirationTime),
            SlidingExpiration = TimeSpan.FromMilliseconds(_cacheConfiguration.UnusedExpiredTime)
        };

        string jsonData = System.Text.Json.JsonSerializer.Serialize(data);

        await _cacheService.SetStringAsync(key, jsonData, options, cancellationToken);
    }
}