namespace HerMajesty.strategy;

/// <summary>
/// The strategy the Princess uses to choose the best contender
/// </summary>
public interface IStrategy
{
    /// <summary>
    /// TODO:
    /// </summary>
    /// <returns></returns>
    public Contender? ChooseBestContender(List<Contender> contenders);
}