namespace Sa.Core.Cache;

public interface IClientCache
{
    Task<T> AsyncGetCachedObject<T>(string key, CancellationToken cancellationToken = default);
    Task AsyncSetCacheObject<T>(string key, T data, CancellationToken cancellationToken = default);
}