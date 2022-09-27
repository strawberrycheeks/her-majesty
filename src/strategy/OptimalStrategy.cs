using HerMajesty.util;

namespace HerMajesty.strategy;

public class OptimalStrategy : IStrategy
{
    /// <summary>
    /// TODO:
    /// </summary>
    public Contender? ChooseBestContender(List<Contender> contenders, Friend friend)
    {
        var visited = 0;
        var cutoff = (int) Math.Round(Constants.ContendersCount / Math.E);
        foreach (var contender in contenders)
        {
            visited += 1;
            friend.AddAudiencedContender(contender);
            
            if (visited >= cutoff && 
                friend.IsBetterThanPrevious(contender))
            {
                return contender;
            }
        }

        return null;
    }
}