using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSubstitute;

using HerMajesty.Context;
using HerMajesty.Entity;
using HerMajesty.Model;
using HerMajesty.Repository;
using HerMajesty.Strategy;
using HerMajesty.Util;
using HerMajestyTests.Mock;

namespace HerMajestyTests;

[TestFixture]
public class OptimalStrategyTests
{
    private const int MaxContenderScore = AppSettings.DefaultContenderCount;
    private const int CutOffContenderScore = 38; // Equals to {DefaultContenderCount}/ Math.E
    private const int TestAttemptNumber = 1; 
    
    private PostgresDbContext _dbc;
    private IStrategy _strategy;
    private IHall _hall;
    
    [SetUp]
    public void SetupStrategy()
    {
        var options = new DbContextOptionsBuilder<PostgresDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        _dbc = new PostgresDbContext(options);

        IAttemptRepository repository = new AttemptRepository(_dbc);
        _hall = new Hall(repository);
        _strategy = new OptimalStrategy(
            new Friend(), 
            _hall, 
            Substitute.For<ILogger<OptimalStrategy>>());
    }
    
    [Test]
    public void ChooseBestContender_ScoreOfChosenContenderGreaterThan50_ReturnsContender()
    {
        _dbc.Attempts.Add(new AttemptEntity
        {
            AttemptNumber = TestAttemptNumber.ToString(),
            Contenders = MockContenderList.GetMaximalHappinessList()
        });
        _dbc.SaveChanges();
        
        _hall.FillContendersList(TestAttemptNumber);

        var chosen = _strategy.ChooseBestContender();
        chosen.Should().NotBeNull();
        chosen?.Score.Should().Be(MaxContenderScore);
    }
    
    [Test]
    public void ChooseBestContender_ScoreOfChosenContenderLessThan50_ReturnsContender()
    {
        _dbc.Attempts.Add(new AttemptEntity
        {
            AttemptNumber = TestAttemptNumber.ToString(),
            Contenders = MockContenderList.GetAscendingList()
        });
        _dbc.SaveChanges();
        
        _hall.FillContendersList(TestAttemptNumber);
    
        var chosen = _strategy.ChooseBestContender();
        chosen.Should().NotBeNull();
        chosen?.Score.Should().Be(CutOffContenderScore);
    }
    
    [Test]
    public void ChooseBestContender_NoContenderChosen_ReturnsNull()
    {
        _dbc.Attempts.Add(new AttemptEntity
        {
            AttemptNumber = TestAttemptNumber.ToString(),
            Contenders = MockContenderList.GetDescendingList()
        });
        _dbc.SaveChanges();
        
        _hall.FillContendersList(TestAttemptNumber);
        _strategy.ChooseBestContender().Should().BeNull();
    }
}