using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

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
            .ConfigureAppConfiguration((_, configuration) =>
            {
                configuration
                    .AddJsonFile("appsettings.json")
                    .Build();
            })
            .ConfigureServices((_, services) =>
            {
                services
                    .AddHostedService<Castle>()
                    .AddScoped<Princess>()
                    .AddScoped<IHall, Hall>()
                    .AddScoped<IFriend, Friend>()
                    .AddScoped<IStrategy, OptimalStrategy>();
                
                services
                    .AddLogging(loggingBuilder =>
                    {
                        loggingBuilder.ClearProviders();
                        loggingBuilder.AddConsole();
                    });
                
            });
    }
}