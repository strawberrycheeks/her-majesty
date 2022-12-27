using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSubstitute;

using HerMajesty.Context;
using HerMajesty.Entity;
using HerMajesty.Model;
using HerMajesty.Repository;
using HerMajesty.Strategy;
using HerMajestyTests.Mock;

namespace HerMajestyTests;

[TestFixture]
public class CastleTests
{
    private const int CutOffContenderScore = 38; // Equals to {DefaultContenderCount}/ Math.E
    private const int TestAttemptNumber = 1; 
    
    private PostgresDbContext _context;
    private IStrategy _strategy;
    private IHall _hall;
    
    [SetUp]
    public void SetUp()
    {
        var options = new DbContextOptionsBuilder<PostgresDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        _context = new PostgresDbContext(options);

        IAttemptRepository repository = new AttemptRepository(_context);
        _hall = new Hall(repository);
        _strategy = new OptimalStrategy(
            new Friend(), 
            _hall, 
            Substitute.For<ILogger<OptimalStrategy>>());
    }

    [Test]
    public void RunAttempt_ScoreOfChosenPrinceLessThan50_ReturnsBadPrinceChosenScore()
    {
        _context.Attempts.Add(new AttemptEntity
        {
            AttemptNumber = TestAttemptNumber,
            Contenders = MockContenderList.GetAscendingList()
        });
        _context.SaveChanges();
        
        _hall.FillContendersList(TestAttemptNumber);
        var chosen = new Princess(_strategy).ChoosePrince();
        chosen.Should().NotBeNull();
        chosen?.Score.Should().Be(CutOffContenderScore);
    }
    
    [Test]
    public void RunAttempt_NoPrinceChosen_ReturnsNoPrinceChosenScore()
    {
        _context.Attempts.Add(new AttemptEntity
        {
            AttemptNumber = TestAttemptNumber,
            Contenders = MockContenderList.GetDescendingList()
        });
        _context.SaveChanges();

        _hall.FillContendersList(TestAttemptNumber);
        var chosen = new Princess(_strategy).ChoosePrince();
        chosen.Should().BeNull();
    }
}