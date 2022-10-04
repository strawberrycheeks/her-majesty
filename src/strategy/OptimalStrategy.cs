using HerMajesty.util;

namespace HerMajesty.strategy;

public class OptimalStrategy : IStrategy
{
    private readonly LadyInWaiting _ladyInWaiting;
    public OptimalStrategy(LadyInWaiting ladyInWaiting)
    {
        _ladyInWaiting = ladyInWaiting;
    }
    
    /// <summary>
    /// Implementation of the cutoff rule. The Princess do not accept any of the
    /// first {cutoff} contenders and then selects the first one that is better
    /// than all the previous ones.
    /// </summary>
    /// <returns> Returns the chosen contender. </returns>
    public Contender? ChooseBestContender(List<Contender> contenders)
    {
        var visited = 0;
        var cutoff = (int) Math.Round(Constants.ContendersCount / Math.E); // will be equal to 37
        foreach (var contender in contenders)
        {
            visited += 1;
            _ladyInWaiting.AddAudiencedContender(contender);
            
            if (visited >= cutoff && 
                _ladyInWaiting.IsBetterThanPrevious(contender))
            {
                return contender;
            }
        }

        return null;
    }
}