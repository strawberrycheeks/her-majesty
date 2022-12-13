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

    [Test]
    public void ChoosePrince_ScoreOfChosenContenderGreaterThan50_ReturnsContender()
    {
        var contenders = MockContenderListGenerator.GenerateMaximalHappinessList();
        var princess = SetupPrincessForTest(contenders);
        
        var chosen = princess.ChoosePrince();
        chosen.Should().NotBeNull();
        chosen.Score.Should().Be(100);
    }
    
    [Test]
    public void ChoosePrince_ScoreOfChosenContenderLessThan50_ReturnsContender()
    {
        var contenders = MockContenderListGenerator.GenerateAscendingList();
        var princess = SetupPrincessForTest(contenders);

        var chosen = princess.ChoosePrince();
        chosen.Should().NotBeNull();
        chosen.Score.Should().Be(37);
    }
    
    [Test]
    public void ChoosePrince_NoContenderChosen_ReturnsNull()
    {
        var contenders = MockContenderListGenerator.GenerateDescendingList();
        var princess = SetupPrincessForTest(contenders);
        princess.ChoosePrince().Should().BeNull();
    }
    
    private static Princess SetupPrincessForTest(List<Contender> contenders)
    {
        IFriend friend = new Friend();
        IHall hall = new Hall(contenders);
        var logger = Substitute.For<ILogger<OptimalStrategy>>();

        IStrategy strategy = new OptimalStrategy(friend, hall, logger);
        return new Princess(strategy);
    }
}