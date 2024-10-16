namespace lab3;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Database;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Queries.GetVisitByPatientId;
using Services.AppService;

public static class Lab3
{
    public static void Main()
    {
        var services = new ServiceCollection();
        var configurationBuilder = new ConfigurationBuilder();
        
        var configuration = ConfigureConfiguration(configurationBuilder);
        
        ConfigureServices(services, configuration);
        
        var serviceProvider = services.BuildServiceProvider();
        Console.WriteLine(configuration.GetConnectionString("DefaultConnection"));

        var mediator = new Mediator(serviceProvider);
        
        var checkAbilitySendInChannelQuery = new GetVisitByPatientIdQuery
        {
           
        };

        var checkAbilitySendInChannelResult = mediator.Send(checkAbilitySendInChannelQuery).Result;
        Console.WriteLine(checkAbilitySendInChannelResult.ids);
        
        // var app = serviceProvider.GetService<App>();
        // app!.Run();
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