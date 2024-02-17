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

    public static IServiceCollection AddDefaultServices<T>(this IServiceCollection services, T appSettings) where T : AppSettings 
    {
        
        services.AddControllers()
            .AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; 
            options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore; 
        });

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        if (appSettings.Redis is not null)
        {
            services.AddRedisCache(appSettings);
        }

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