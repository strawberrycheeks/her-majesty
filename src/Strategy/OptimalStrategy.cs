using HerMajesty.Model;
using HerMajesty.Util;

namespace HerMajesty.Strategy;

public class OptimalStrategy : IStrategy
{
    private readonly Friend _friend;
    private readonly Hall _hall;
    public OptimalStrategy(Friend friend, Hall hall)
    {
        _friend = friend;
        _hall = hall;
    }

    /// <summary>
    /// Implementation of the cutoff rule. The Princess do not accept any of the
    /// first {cutoff} contenders and then selects the first one that is better
    /// than all the previous ones.
    /// </summary>
    /// <returns> Returns the chosen contender. </returns>
    public Contender? ChooseBestContender()
    {
        var visited = 0;
        var cutoff = (int) Math.Round(Constants.ContendersCount / Math.E); // will be equal to 37

        while (_hall.GetNextContender() is { } contender)
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
}