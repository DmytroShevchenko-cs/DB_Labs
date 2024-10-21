namespace lab3;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Database;
using Microsoft.Extensions.Configuration;
using Services.AppService;

public static class Lab3
{
    public static async Task Main()
    {
        var services = new ServiceCollection();
        var configurationBuilder = new ConfigurationBuilder();
        
        var configuration = ConfigureConfiguration(configurationBuilder);
        
        ConfigureServices(services, configuration);
        
        var serviceProvider = services.BuildServiceProvider();
        
        using (var scope = serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<HospitalDbContext>();
            await dbContext.Database.MigrateAsync();
        }
        
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var app = serviceProvider.GetService<App>();
        await app!.Run();
    }

    private static IConfiguration ConfigureConfiguration(IConfigurationBuilder configurationBuilder)
    {
        return configurationBuilder
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
    }
    
    private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<HospitalDbContext>(options =>
            options.UseNpgsql(connectionString));
        
        services.AddMediatR(serviceConfiguration =>
        {
            serviceConfiguration.RegisterServicesFromAssembly(typeof(HospitalDbContext).Assembly);
        });
        
        // Добавляем другие сервисы
        services.AddTransient<App>();
    }
}