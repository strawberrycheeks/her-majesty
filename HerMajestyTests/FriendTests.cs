using HerMajesty.Exception;
using HerMajesty.Model;

namespace HerMajestyTests;

[TestFixture]
public class FriendTests
{
    [Test]
    public void IsBetterThanVisited_ContenderIsBestAndVisited_ReturnsTrue()
    {
        var friend = CreateDefaultFriend();
        var bestContender = CreateBestContender();
        var averageContender = CreateAverageContender();
        
        friend.AddVisitedContender(averageContender);
        friend.AddVisitedContender(bestContender);
        
        Assert.That(friend.IsBetterThanVisited(bestContender), Is.True);
    }

    [Test]
    public void IsBetterThanVisited_ContenderIsNotBestAndVisited_ReturnsFalse()
    {
        var friend = CreateDefaultFriend();
        var bestContender = CreateBestContender();
        var averageContender = CreateAverageContender();
        
        friend.AddVisitedContender(bestContender);
        friend.AddVisitedContender(averageContender);
        
        Assert.That(friend.IsBetterThanVisited(averageContender), Is.False);
    }
    
    [Test]
    public void IsBetterThanVisited_ContenderIsNotVisited_ThrowsUnvisitedContenderComparedException()
    {
        var friend = CreateDefaultFriend();
        var bestContender = CreateBestContender();
        
        Assert.Throws<UnvisitedContenderComparedException>(
            delegate { friend.IsBetterThanVisited(bestContender); } 
            );
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