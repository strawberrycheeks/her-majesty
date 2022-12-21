using HerMajesty.Exception;

namespace HerMajesty.Model;

public class Friend : IFriend
{
    /// <summary>
    /// Stores all visited contenders
    /// </summary>
    private readonly List<Contender> _visitedContenderList;
    
    /// <summary>
    /// Stores the highest contender's score among all visited contenders
    /// </summary>
    private int _bestVisitedScore;

    public Friend()
    {
        _visitedContenderList = new List<Contender>();
        _bestVisitedScore = 0;
    }

    /// <summary>
    /// Adds the contender to the list and updates the best contender's score
    /// taking into account the score of the added contender
    /// </summary>
    /// <param name="contender"> A new contender to be added to the list </param>
    public bool AddVisitedContender(Contender contender)
    {
        if (contender == null) return false; 
        
        _visitedContenderList.Add(contender);
        UpdateBestScore(contender);
        return true;
    }

    /// <summary>
    /// Compares the score of the contender with the highest visited contender's score
    /// </summary>
    /// <param name="contender"> A contender whose score needs to be compared, must be already marked as visited </param>
    /// <returns>
    /// Returns true, if current contender's score is greater than best
    /// visited contenders' score; returns false otherwise
    /// </returns>
    public bool IsBetterThanVisited(Contender contender)
    {
        if (!IsVisited(contender))
        {
            throw new UnvisitedContenderComparedException(contender.Name);
        }
        return contender.Score >= _bestVisitedScore;
    }
    
    /// <summary>
    /// Saves the highest contender's score among all contenders who visited the Princess 
    /// </summary>
    /// <param name="contender"> A new contender who has just been added to the list </param>
    private void UpdateBestScore(Contender contender)
    {
        if (contender.Score > _bestVisitedScore)
        {
            _bestVisitedScore = contender.Score;
        }
    }

    /// <summary>
    /// Checks if contender has already visited the Princess
    /// </summary>
    /// <returns>
    /// Returns true, if contender is visited; otherwise returns false 
    /// </returns>
    private bool IsVisited(Contender contender)
    {
        return _visitedContenderList.Exists(c => c.Score == contender.Score);
    }
}