namespace HerMajesty.strategy;

/// <summary>
/// The strategy the Princess uses to choose the best contender
/// </summary>
public interface IStrategy
{
    /// <summary>
    /// Selects the best candidate according to a given strategy
    /// </summary>
    /// <returns> Returns a chosen contender. If no contender was chosen, returns null </returns>
    public Contender? ChooseBestContender(List<Contender> contenderList);
}