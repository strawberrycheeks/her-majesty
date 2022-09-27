using HerMajesty.strategy;

namespace HerMajesty;
public class Princess
{
    /// <summary>
    /// TODO:
    /// </summary>
    public IStrategy Strategy { get; }
    
    /// <summary>
    /// TODO:
    /// </summary>
    public Friend Friend { get; }

    public Princess()
    {
        Friend = new Friend();
        Strategy = new OptimalStrategy();
    }

    /// <summary>
    /// TODO:
    /// </summary>
    public Contender? ChoosePrince(List<Contender> contenders)
    {
        return Strategy.ChooseBestContender(contenders, Friend);
    }
}