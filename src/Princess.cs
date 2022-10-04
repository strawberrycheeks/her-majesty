using HerMajesty.strategy;

namespace HerMajesty;
public class Princess
{
    /// <summary>
    /// The strategy the Princess uses to choose the best contender
    /// </summary>
    private IStrategy _strategy;
    
    /// <summary>
    /// The lady-in-waiting who helps the Princess compare the contenders
    /// </summary>
    public LadyInWaiting LadyInWaiting { get; }

    public Princess()
    {
        LadyInWaiting = new LadyInWaiting();
        _strategy = new OptimalStrategy();
    }

    /// <summary>
    /// Selects the best contender according to selected strategy
    /// </summary>
    public Contender? ChoosePrince(List<Contender> contenders)
    {
        return _strategy.ChooseBestContender(contenders, LadyInWaiting);
    }
    
    /// <summary>
    /// Calculates how many happiness points the Princess gets. Princess gets:
    /// a) 10 points if she does not choose any of the contenders,
    /// b) 0 if the score of the chosen contender is less than 51,
    /// c) points are equal to the contender's score (from 51 to 100) otherwise.
    /// </summary>
    /// <param name="chosenPrince"> The prince who was chosen </param>
    /// <returns> Returns Princess's happiness points </returns>
    public static int CalculateHappinessPoints(Contender? chosenPrince)
    {
        if (chosenPrince == null)
        {
            return 10;
        }
        return chosenPrince.Score > 50 ? chosenPrince.Score : 0 ;
    }
}