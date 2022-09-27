namespace HerMajesty.strategy;

/// <summary>
/// TODO:
/// </summary>
public interface IStrategy
{
    public Contender? ChooseBestContender(List<Contender> contenders, Friend friend);
}