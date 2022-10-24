using HerMajesty.Model;

namespace HerMajesty.Strategy;

/// <summary>
/// The strategy the Princess uses to choose the best contender
/// </summary>
public interface IStrategy
{
    /// <summary>
    /// Sets the list of contenders from which the Prince will be selected
    /// </summary>
    /// <param name="contenderList"> List to be set </param>
    public void SetContenderList(List<Contender> contenderList);
    
    /// <summary>
    /// Selects the best candidate according to a given strategy
    /// </summary>
    /// <returns> Returns a chosen contender. If no contender was chosen, returns null </returns>
    public Contender? ChooseBestContender();
}