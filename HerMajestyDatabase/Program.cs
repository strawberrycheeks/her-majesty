using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

using HerMajesty.Context;
using HerMajesty.Util;

namespace HerMajestyDatabase;

public static class Program
{
    public static async Task Main(string[] args)
    {
        try
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            AppSettings.LoadConfigurationSettings(configuration);

            var optionsBuilder = new DbContextOptionsBuilder<PostgresDbContext>().UseNpgsql(AppSettings.DbConnection);

            await using var dbc = new PostgresDbContext(optionsBuilder.Options);
            await AttemptGenerator.GenerateAsync(dbc, AppSettings.AttemptCount);
        } catch (Exception ex)
        {
            Console.WriteLine($"{ex.GetType()}: {ex.Message}");
        }
    }
}