namespace Sa.Core.Configurations;

public class AppSettings
{
    public JwtConfiguration Jwt { get; set; }
    public SqlConfiguration Sql { get; set; }
    public RedisConfiguration Redis { get; set; }
}