using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using HerMajesty.Context;
using HerMajesty.Util;
using HerMajestyDatabase;

namespace HerMajestyTests;

[TestFixture]
public class AttemptGeneratorTests
{
    private PostgresDbContext _context;
    
    [SetUp]
    public void SetUp()
    {
        AppSettings.LoadConfigurationSettings(
            new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build());
        
        var options = new DbContextOptionsBuilder<PostgresDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        _context = new PostgresDbContext(options);
    }

    [Test]
    public async Task GenerateAttemptsInDB_Return100Attempts()
    {
        await AttemptGenerator.GenerateAsync(_context, AppSettings.AttemptCount);
        var attempts = _context.Attempts.ToList();
        attempts.Count.Should().Be(AppSettings.AttemptCount);
    }
}