using Microsoft.Extensions.Logging;

using HerMajesty.Model;
using HerMajesty.Util;
using Microsoft.Extensions.Configuration;

namespace HerMajesty.Strategy;

public class OptimalStrategy : IStrategy
{
    private readonly IFriend _friend;
    private readonly IHall _hall;

    private readonly ILogger<OptimalStrategy> _logger;
    public OptimalStrategy(IFriend friend, IHall hall, ILogger<OptimalStrategy> logger)
    {
        _friend = friend;
        _hall = hall;
        _logger = logger;
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
        var cutoff = (int) Math.Round(Constants.ContenderCount / Math.E); // will be equal to 37

        while (_hall.GetNextContender() is { } contender)
        {
            visited += 1;
            _friend.AddVisitedContender(contender);
            _logger.LogDebug($"{visited} cont. visited. Current is {contender.Name}: ({contender.Score})");
            
            using var writer = new StreamWriter(Constants.ResultPath, true);
            writer.WriteLine($"{contender.Name} ({contender.Score})");
            
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