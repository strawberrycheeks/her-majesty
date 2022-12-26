using FluentAssertions;
using HerMajesty.Context;
using HerMajesty.Entity;
using NSubstitute;

using HerMajesty.Model;
using HerMajesty.Repository;
using HerMajestyTests.Mock;
using Microsoft.EntityFrameworkCore;

namespace HerMajestyTests;

[TestFixture]
public class HallTests
{
    private const int TestAttemptNumber = 1; 
    private PostgresDbContext _dbc;
    private IHall _hall;
    
    [SetUp]
    public void SetUp()
    {
        var options = new DbContextOptionsBuilder<PostgresDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        _dbc = new PostgresDbContext(options);
        
        _dbc.Attempts.Add(new AttemptEntity
            {
                AttemptNumber = TestAttemptNumber.ToString(),
                Contenders = MockContenderList.GetAscendingList()
            });
        _dbc.SaveChanges();

        IAttemptRepository repository = new AttemptRepository(_dbc);
        _hall = new Hall(repository);
    }
    
    [Test]
    public void GetNextContender_ContendersListFilled_ReturnsContender()
    {
        _hall.FillContendersList(TestAttemptNumber);
        _hall.GetNextContender().Should().NotBeNull();
    }
    
    [Test]
    public void GetNextContender_ContendersListNotFilled_ReturnsNull()
    {
        _hall.GetNextContender().Should().BeNull();
    }
}