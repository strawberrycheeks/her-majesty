using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;

using HerMajesty.Model;
using HerMajesty.Strategy;
using HerMajestyTests.Mock;

namespace HerMajestyTests;

[TestFixture]
public class PrincessTests
{
    /*
     * Naming rules for tests:
     * 
     * [Test]
     * public void Method_Conditions_Returns() { }
     */
    
    // private const int ContendersCount = 100;
    
    private IHall _hall;
    private Princess _princess;
    private IContenderListGenerator _generator;

    [SetUp]
    public void Setup()
    {
        _generator = Substitute.For<IContenderListGenerator>();
        _hall = new Hall(_generator);
        
        IStrategy strategy = new OptimalStrategy(new Friend(), _hall, Substitute.For<ILogger<OptimalStrategy>>());
        _princess = new Princess(strategy);
    }

    [Test]
    public void ChoosePrince_ScoreOfChosenContenderGreaterThan50_ReturnsContender()
    {
        _generator.GenerateContenderList().Returns(MockContenderListGenerator.GenerateMaximalHappinessList());
        _hall.FillContendersList();
        var chosen = _princess.ChoosePrince();
        chosen.Should().NotBeNull();
        chosen?.Score.Should().Be(100);
    }
    
    [Test]
    public void ChoosePrince_ScoreOfChosenContenderLessThan50_ReturnsContender()
    {
        _generator.GenerateContenderList().Returns(MockContenderListGenerator.GenerateAscendingList());
        _hall.FillContendersList();
        var chosen = _princess.ChoosePrince();
        chosen.Should().NotBeNull();
        chosen?.Score.Should().Be(37);
    }
    
    [Test]
    public void ChoosePrince_NoContenderChosen_ReturnsNull()
    {
        _generator.GenerateContenderList().Returns(MockContenderListGenerator.GenerateDescendingList());
        _hall.FillContendersList();
        _princess.ChoosePrince().Should().BeNull();
    }
}