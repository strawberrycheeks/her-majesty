using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;

using HerMajesty.Model;
using HerMajesty.Strategy;
using HerMajesty.Util;
using HerMajestyTests.Mock;

namespace HerMajestyTests;

[TestFixture]
public class OptimalStrategyTests
{
    private const int MaxContenderScore = AppSettings.DefaultContenderCount;
    private const int CutOffContenderScore = 38; // Equals to {DefaultContenderCount}/ Math.E

    private IStrategy _strategy;
    private IHall _hall;

    private readonly IContenderListGenerator _mockedGenerator = Substitute.For<IContenderListGenerator>();
    
    [SetUp]
    public void SetupStrategy()
    {
        _hall = new Hall(_mockedGenerator);
        _strategy = new OptimalStrategy(
            new Friend(), 
            _hall, 
            Substitute.For<ILogger<OptimalStrategy>>());
    }
    
    [Test]
    public void ChooseBestContender_ScoreOfChosenContenderGreaterThan50_ReturnsContender()
    {
        _mockedGenerator.GenerateContenderList().Returns(
            MockContenderListGenerator.GenerateMaximalHappinessList()
            );
        _hall.FillContendersList();

        var chosen = _strategy.ChooseBestContender();
        chosen.Should().NotBeNull();
        chosen?.Score.Should().Be(MaxContenderScore);
    }
    
    [Test]
    public void ChooseBestContender_ScoreOfChosenContenderLessThan50_ReturnsContender()
    {
        _mockedGenerator.GenerateContenderList().Returns(
            MockContenderListGenerator.GenerateAscendingList()
            );
        _hall.FillContendersList();
    
        var chosen = _strategy.ChooseBestContender();
        chosen.Should().NotBeNull();
        chosen?.Score.Should().Be(CutOffContenderScore);
    }
    
    [Test]
    public void ChooseBestContender_NoContenderChosen_ReturnsNull()
    {
        _mockedGenerator.GenerateContenderList().Returns(
            MockContenderListGenerator.GenerateDescendingList()
            );
        _hall.FillContendersList();
        _strategy.ChooseBestContender().Should().BeNull();
    }
}