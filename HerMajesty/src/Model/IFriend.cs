namespace HerMajesty.Model;

public interface IFriend
{
    /// <summary>
    /// Adds the contender to the list and updates the best contender's score
    /// taking into account the score of the added contender
    /// </summary>
    /// <returns> Returns true if the contender is added to the list, returns false otherwise </returns>
    public bool AddVisitedContender(Contender contender);

    /// <summary>
    /// Compares the score of the contender with the highest visited contender's score
    /// </summary>
    public bool IsBetterThanVisited(Contender contender);

    /// <summary>
    /// Resets the list of visited contenders
    /// </summary>
    public void ResetVisitedContenderList();
}