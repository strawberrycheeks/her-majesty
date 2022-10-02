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
}