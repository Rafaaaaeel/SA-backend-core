namespace Sa.Core.Configurations;

public static class Configurator
{
    public static IConfiguration GetConfiguration(IWebHostEnvironment environment)
    {
        IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(environment.ContentRootPath)
            .AddJsonFile($"appsettings.json")
            .AddEnvironmentVariables();

        return builder.Build();
    }
}