using HerMajesty.Util;

namespace HerMajesty.Strategy;

public class OptimalStrategy : IStrategy
{
    private readonly Friend _friend;
    private List<Contender>? _contenderList;
    public OptimalStrategy(Friend friend)
    {
        _friend = friend;
    }

    /// <summary>
    /// Implementation of the cutoff rule. The Princess do not accept any of the
    /// first {cutoff} contenders and then selects the first one that is better
    /// than all the previous ones.
    /// </summary>
    /// <returns> Returns the chosen contender. </returns>
    public Contender? ChooseBestContender()
    {
        if (_contenderList == null)
        {
            return null;
        }
        
        var visited = 0;
        var cutoff = (int) Math.Round(Constants.ContendersCount / Math.E); // will be equal to 37
        foreach (var contender in _contenderList)
        {
            visited += 1;
            _friend.AddVisitedContender(contender);
            
            // Important: current contender must be already visited!
            if (visited >= cutoff
                && _friend.IsBetterThanVisited(contender)) 
            {
                return contender;
            }
        }

        return null;
    }

    public void SetContenderList(List<Contender> contenderList)
    {
        _contenderList = contenderList;
    }
}