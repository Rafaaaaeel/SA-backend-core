namespace Sa.Core.Configurations;

public class CacheConfiguration
{
    public long ExpirationTime { get; set; }
    public long UnusedExpiredTime { get; set; }
}