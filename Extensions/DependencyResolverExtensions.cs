namespace Sa.Core.Extensions;

public static class DependencyResolverExtensions
{
    public static IServiceCollection AddCustomAuthentication<T>(this IServiceCollection services, T appSettings) where T : AppSettings
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => 
        opt.TokenValidationParameters = new TokenValidationParameters 
        {
            ValidateIssuerSigningKey = appSettings.Jwt.ValidateIssuerSigningKey,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.Jwt.IssuerSigningKey)),
            ValidateIssuer = appSettings.Jwt.ValidateIssuer,
            ValidateAudience = appSettings.Jwt.ValidateAudience
        });

        return services;    
    }

    public static IServiceCollection AddRedisCache<T>(this IServiceCollection services, T appSettings) where T : AppSettings
    {
        services.AddSingleton<ICoreCacheService, CoreCacheService>();

        services.AddStackExchangeRedisCache(opt => {
            opt.Configuration = appSettings.Redis.ConnectionString;
        });

        return services;
    }
}