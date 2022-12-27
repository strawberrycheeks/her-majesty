using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using HerMajesty.Context;
using HerMajesty.Model;
using HerMajesty.Repository;
using HerMajesty.Strategy;
using HerMajesty.Util;

namespace HerMajesty;

public static class Program
{
    public static void Main(string[] args)
    {
        try
        {
            if (!ParseAttemptNumber(args)) return;
            
            CreateHostBuilder(args)
                .Build()
                .Run();
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"{ex.GetType()}: {ex.Message}");
        }
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args);
        ConfigureAppConfiguration(builder);
        ConfigureServices(builder);
        return builder;
    }

    private static void ConfigureAppConfiguration(IHostBuilder builder)
    {
        builder.ConfigureAppConfiguration((hostContext, configurationBuilder) =>
        {
            IConfiguration configuration = configurationBuilder
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true)
                .Build();
            AppSettings.LoadConfigurationSettings(configuration);
        });
    }
    
    private static void ConfigureServices(IHostBuilder builder)
    {
        builder.ConfigureServices((hostContext, services) =>
        {
            services
                .AddHostedService<Castle>()
                .AddScoped<Princess>()
                .AddScoped<IHall, Hall>()
                .AddScoped<IFriend, Friend>()
                .AddScoped<IStrategy, OptimalStrategy>()
                .AddScoped<IContenderListGenerator, ContenderListGenerator>();

            services
                .AddDbContext<PostgresDbContext>(
                    o => o.UseNpgsql(AppSettings.DbConnection))
                .AddScoped<IAttemptRepository, AttemptRepository>();

            if (hostContext.HostingEnvironment.EnvironmentName.Equals("Production"))
            {
                AddLogging(services);
            }
        });
    }
    
    private static void AddLogging(IServiceCollection services)
    {
        services.AddLogging(builder =>
        {
            builder.ClearProviders();
            services.AddLogging(loggingBuilder => {
                loggingBuilder.AddFile("../../../logs/app-{0:yyyy}-{0:MM}-{0:dd}-{0:HH}-{0:mm}-{0:ss}.log", 
                    fileLoggerOpts => {
                        fileLoggerOpts.FormatLogFileName = fName => string.Format(fName, DateTime.Now);
                    });
            });
        });
    }

    private static bool ParseAttemptNumber(IReadOnlyList<string> args)
    {
        if (args.Count == 0) return true; // Then should run all attempts
        if (string.IsNullOrEmpty(args[0])) return false;
        
        if (int.TryParse(args[0], out var parsed))
        {
            AppSettings.AttemptNumber = parsed;
            return true;
        }
        
        Console.WriteLine("Expected argument: <attempt-id> should be an integer");
        return false;
    }
}
