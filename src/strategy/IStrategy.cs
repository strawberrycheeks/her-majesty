namespace HerMajesty.strategy;

/// <summary>
/// The strategy the Princess uses to choose the best contender
/// </summary>
public interface IStrategy
{
    public Contender? ChooseBestContender(List<Contender> contenders, LadyInWaiting ladyInWaiting);
}