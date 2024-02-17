namespace Sa.Core.Extensions;

public static class DependencyResolverExtensions
{
    public static IServiceCollection AddCustomAuthentication<T>(this IServiceCollection services, T appSettings) where T : AppSettings
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => 
        opt.TokenValidationParameters = new TokenValidationParameters 
        {
            ValidateIssuerSigningKey = appSettings.JwtConfiguration.ValidateIssuerSigningKey,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.JwtConfiguration.IssuerSigningKey)),
            ValidateIssuer = appSettings.JwtConfiguration.ValidateIssuer,
            ValidateAudience = appSettings.JwtConfiguration.ValidateAudience
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

        if (appSettings.RedisConfiguration is not null)
        {
            services.AddRedisCache(appSettings);
        }

        return services;
    }
    
    public static IServiceCollection AddRedisCache<T>(this IServiceCollection services, T appSettings) where T : AppSettings
    {
        services.AddSingleton<ICoreCacheService, CoreCacheService>();
        services.AddSingleton<IClientCache, ClientDistribuitedCache>();
        services.AddStackExchangeRedisCache(opt => {
            opt.Configuration = appSettings.RedisConfiguration.ConnectionString;
        });

        return services;
    }

    public static IServiceCollection AddDefaultDependencies<T>(this IServiceCollection services, T appSettings) where T : AppSettings
    {
        services.AddSingleton<AppSettings>(x => appSettings);
        return services;
    }
}