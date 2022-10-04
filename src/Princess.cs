using HerMajesty.strategy;
using HerMajesty.util;

namespace HerMajesty;
public class Princess
{
    /// If score of the chosen prince is lower than this value, prince is bad 
    private const int HappinessBoundary = 50;
    
    /// <summary>
    /// Number of points the Princess gets if no prince was chosen
    /// </summary>
    private const int NoPrinceChosenScore = 10;
    
    /// <summary>
    /// Number of points the Princess gets if a bad prince was chosen
    /// </summary>
    private const int BadPrinceChosenScore = 0;
    
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
    public Contender? ChoosePrince(List<Contender> contenderList)
    {
        return _strategy.ChooseBestContender(contenderList);
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
            return NoPrinceChosenScore;
        }
        return prince.Score > HappinessBoundary ? prince.Score : BadPrinceChosenScore;
    }
}