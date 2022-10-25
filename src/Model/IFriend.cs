namespace HerMajesty.Model;

public interface IFriend
{
    /// <summary>
    /// Adds the contender to the list and updates the best contender's score
    /// taking into account the score of the added contender
    /// </summary>
    public void AddVisitedContender(Contender contender);

    /// <summary>
    /// Compares the score of the contender with the highest visited contender's score
    /// </summary>
    public bool IsBetterThanVisited(Contender contender);
}