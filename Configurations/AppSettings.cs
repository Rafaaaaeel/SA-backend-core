namespace Sa.Core.Configurations;

public class AppSettings
{
    public JwtConfiguration JwtConfiguration { get; set; }
    public SqlConfiguration SqlConfiguration { get; set; }
    public RedisConfiguration RedisConfiguration { get; set; }
    public CacheConfiguration cacheConfiguration { get; set; }
}