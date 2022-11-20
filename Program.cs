using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using HerMajesty.Strategy;
using HerMajesty.Model;
using HerMajesty.Util;

namespace HerMajesty;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
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
                .AddScoped<IStrategy, OptimalStrategy>();

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
                        fileLoggerOpts.FormatLogFileName = fName => {
                            return String.Format(fName, DateTime.Now);
                        };
                    });
            });
        });
    }
}
