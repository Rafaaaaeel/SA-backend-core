namespace Sa.Core.Managers;

public class StartupManager
{
    private readonly IWebHostEnvironment _environment;
    private readonly IConfiguration _configuration;

    public StartupManager(IWebHostEnvironment env)
    {
        _environment = env;
        _configuration = Configurator.GetConfiguration(env);
    }

    public void Configure(IApplicationBuilder app, AppSettings appSettings)
    {
        if (_environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseEndpoints(endpoints => 
        {
            endpoints.MapControllers();
        });
    }

    public async Task<AppSettings> GetSettings() 
    {
        return await GetSettings<AppSettings>();
    }

    public async Task<T> GetSettings<T>() where T : AppSettings, new()
    {
        T defaultConfiguration = new();
        
        _configuration.GetSection("DefaultConfiguration").Bind(defaultConfiguration);

        return await new ValueTask<T>(defaultConfiguration);;
    }

}