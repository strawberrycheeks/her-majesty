using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using HerMajesty.Strategy;
using HerMajesty.Model;

namespace HerMajesty;

class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args)
            .Build()
            .Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
            {
                services.AddHostedService<Castle>();
                services.AddScoped<Princess>();
                services.AddScoped<IHall, Hall>();
                services.AddScoped<IFriend, Friend>();
                services.AddScoped<IStrategy, OptimalStrategy>();
            });
    }
}