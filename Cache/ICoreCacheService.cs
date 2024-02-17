namespace Sa.Core.Cache;

public interface ICoreCacheService 
{
    Task<string> GetStringAsync(string key, CancellationToken cancellationToken = default);
    Task RemoveAsync(string key, CancellationToken cancellationToken = default);
    Task SetStringAsync(string key, string value, DistributedCacheEntryOptions options, CancellationToken cancellationToken = default);
}