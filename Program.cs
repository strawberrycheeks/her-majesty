using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using HerMajesty.Strategy;
using HerMajesty.Model;

namespace HerMajesty;

class Program
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
        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostContext, configuration) =>
            {
                configuration
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true)
                    .Build();
            })
            .ConfigureServices((hostContext, services) =>
            {
                services
                    .AddHostedService<Castle>()
                    .AddScoped<Princess>()
                    .AddScoped<IHall, Hall>()
                    .AddScoped<IFriend, Friend>()
                    .AddScoped<IStrategy, OptimalStrategy>();

                if (hostContext.HostingEnvironment.EnvironmentName.Equals("Development"))
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
