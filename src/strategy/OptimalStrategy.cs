using HerMajesty.util;

namespace HerMajesty.strategy;

public class OptimalStrategy : IStrategy
{
    /// <summary>
    /// Implementation of the cutoff rule. The Princess do not accept any of the
    /// first {cutoff} contenders and then selects the first one that is better
    /// than all the previous ones.
    /// </summary>
    /// <param name="contenders"> The list of contenders </param>
    /// <param name="ladyInWaiting"> The lady-in-waiting that helps the Princess compare the contenders </param>
    /// <returns></returns>
    public Contender? ChooseBestContender(List<Contender> contenders, LadyInWaiting ladyInWaiting)
    {
        var visited = 0;
        var cutoff = (int) Math.Round(Constants.ContendersCount / Math.E); // will be equal to 37
        foreach (var contender in contenders)
        {
            visited += 1;
            ladyInWaiting.AddAudiencedContender(contender);
            
            if (visited >= cutoff && 
                ladyInWaiting.IsBetterThanPrevious(contender))
            {
                return contender;
            }
        }

        return null;
    }
}