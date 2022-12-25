using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HerMajesty.Context;

/// <summary>
/// Class for generating migrations.
/// </summary>
public class PostgresDbContextFactory : IDesignTimeDbContextFactory<PostgresDbContext>
{
    public PostgresDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
        var options = new DbContextOptionsBuilder<PostgresDbContext>()
            .UseNpgsql(configuration.GetValue<string>("ConnectionStrings:DefaultConnection"))
            .Options;

        return new PostgresDbContext(options);
    }
}