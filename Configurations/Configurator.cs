namespace Sa.Core.Configurations;

public static class Configurator
{
    public static IConfiguration GetConfiguration(IWebHostEnvironment environment)
    {
        IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(environment.ContentRootPath)
            .AddJsonFile($"appsettings.json")
            .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: false)
            .AddEnvironmentVariables()
            .AddUserSecrets<StartupManager>();

        return builder.Build();
    }
}