using HerMajesty.strategy;

namespace HerMajesty;
public class Princess
{
    /// <summary>
    /// The strategy the Princess uses to choose the best contender
    /// </summary>
    private readonly IStrategy _strategy;

    public Princess(IStrategy strategy)
    {
        _strategy = strategy;
    }

    /// <summary>
    /// Selects the best contender according to selected strategy
    /// </summary>
    public Contender? ChoosePrince(List<Contender> contenders)
    {
        return _strategy.ChooseBestContender(contenders);
    }
    
    /// <summary>
    /// Calculates how many happiness points the Princess gets. Princess gets:
    /// a) 10 points if she does not choose any of the contenders,
    /// b) 0 if the score of the chosen contender is less than 51,
    /// c) points are equal to the contender's score (from 51 to 100) otherwise.
    /// </summary>
    /// <param name="prince"> The prince who was chosen </param>
    /// <returns> Returns Princess's happiness points </returns>
    public static int CalculateHappinessPoints(Contender? prince)
    {
        if (prince == null)
        {
            return 10;
        }
        return prince.Score > 50 ? prince.Score : 0 ;
    }
}