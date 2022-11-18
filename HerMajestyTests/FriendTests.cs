using FluentAssertions;

using HerMajesty.Exception;
using HerMajesty.Model;

namespace HerMajestyTests;

[TestFixture]
public class FriendTests
{
    [Test]
    public void IsBetterThanVisited_ContenderIsBestAndVisited_ReturnsTrue()
    {
        var bestContender = CreateBestContender();
        var averageContender = CreateAverageContender();
        var friend = CreateDefaultFriend();
        
        friend.AddVisitedContender(averageContender);
        friend.AddVisitedContender(bestContender);
        
        friend.IsBetterThanVisited(bestContender).Should().BeTrue();
    }

    [Test]
    public void IsBetterThanVisited_ContenderIsNotBestAndVisited_ReturnsFalse()
    {
        var bestContender = CreateBestContender();
        var averageContender = CreateAverageContender();
        var friend = CreateDefaultFriend();
        
        friend.AddVisitedContender(bestContender);
        friend.AddVisitedContender(averageContender);
        
        friend.IsBetterThanVisited(averageContender).Should().BeFalse();
    }
    
    [Test]
    public void IsBetterThanVisited_ContenderIsNotVisited_ThrowsUnvisitedContenderComparedException()
    {
        var bestContender = CreateBestContender();
        var friend = CreateDefaultFriend();

        var act = () => friend.IsBetterThanVisited(bestContender);
        act.Should().Throw<UnvisitedContenderComparedException>();
    }

    private static IFriend CreateDefaultFriend()
    {
        return new Friend();
    }
    
    private static Contender CreateBestContender()
    {
        const string bestName = "Best";
        const int bestScore = 100;
        return new Contender(bestName, bestScore);
    }

    private static Contender CreateAverageContender()
    {
        const string averageName = "Average";
        const int averageScore = 10;
        return new Contender(averageName, averageScore);
    }
}