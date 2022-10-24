using HerMajesty.Strategy;

namespace HerMajesty.Model;
public class Princess
{
    /// If score of the chosen prince is lower than this value, prince is bad 
    private const int HappinessBoundary = 50;
    
    /// <summary>
    /// Number of points the Princess gets if no prince was chosen
    /// </summary>
    public const int NoPrinceChosenScore = 10;
    
    /// <summary>
    /// Number of points the Princess gets if a bad prince was chosen
    /// </summary>
    public const int BadPrinceChosenScore = 0;
    
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
    public Contender? ChoosePrince()
    {
        return _strategy.ChooseBestContender();
    }
    
    /// <summary>
    /// Calculates how many happiness points the Princess gets. Princess gets:
    /// a) 10 points if she does not choose any of the contenders,
    /// b) 0 if the score of the chosen contender is less than 51,
    /// c) points are equal to the contender's score (from 51 to 100) otherwise.
    /// </summary>
    /// <param name="chosenPrinceScore"> Score of the chosen prince </param>
    /// <returns> Returns Princess's happiness points </returns>
    public static int CalculateHappinessPoints(int? chosenPrinceScore)
    {
        if (chosenPrinceScore.HasValue)
        {
            return chosenPrinceScore.Value > HappinessBoundary 
                ? chosenPrinceScore.Value 
                : BadPrinceChosenScore;
        }
        return NoPrinceChosenScore;
    }
}