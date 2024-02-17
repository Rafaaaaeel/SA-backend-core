
using Microsoft.Identity.Client.Kerberos;
using Sa.Core.Helpers;

namespace Sa.Core.Cache;

public class CoreCacheService : ICoreCacheService
{
    public readonly IDistributedCache _redis;

    public CoreCacheService(IDistributedCache redis)
    {
        _redis = redis;
    }

    public async Task<string> GetStringAsync(string key, CancellationToken cancellationToken = default)
    {
        string? getRedisResult = await _redis.GetStringAsync(key, token: cancellationToken);

        if (getRedisResult is null) throw new NullReferenceException();

        string? decompressedResult = CompactString.Decompress(getRedisResult);

        if (decompressedResult is null && getRedisResult is not null) 
        {
            await RemoveAsync(key, cancellationToken);
        }

        return decompressedResult ?? string.Empty;
    }

    public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        await _redis.RemoveAsync(key, cancellationToken);
    }

    public async Task SetStringAsync(string key, string value, DistributedCacheEntryOptions options, CancellationToken cancellationToken = default)
    {
        string comppressedPayload = CompactString.Compress(value);

        await _redis.SetStringAsync(key, comppressedPayload, options, cancellationToken);
    }
}