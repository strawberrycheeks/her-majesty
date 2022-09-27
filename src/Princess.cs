namespace HerMajesty;

public class Princess
{
    public IStrategy Strategy { get; }
    public Friend Friend { get; }

    public Princess()
    {
        Friend = new Friend();
        Strategy = new OptimalStrategy();
    }

    public Contender? ChoosePrince(List<Contender> contenders)
    {
        return Strategy.ChooseBestContender(contenders, Friend);
    }
}