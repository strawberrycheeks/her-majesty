namespace HerMajesty;

public class LadyInWaiting
{
    /// <summary>
    /// Stores all visited contenders
    /// </summary>
    public List<Contender> VisitedContenderList { get; }
    
    /// <summary>
    /// Stores the highest contender's score among all visited contenders
    /// </summary>
    private int _bestVisitedScore;

    public LadyInWaiting()
    {
        VisitedContenderList = new List<Contender>();
        _bestVisitedScore = 0;
    }

    /// <summary>
    /// Adds the contender to the list and updates the best contender's score
    /// taking into account the score of the added contender
    /// </summary>
    /// <param name="contender"> A new contender to be added to the list </param>
    public void AddAudiencedContender(Contender contender)
    {
        VisitedContenderList.Add(contender);
        UpdateBestScore(contender);
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
    /// Compares the score of the contender with the highest visited contender's score
    /// </summary>
    /// <param name="contender"> A contender whose score needs to be compared </param>
    public bool IsBetterThanPrevious(Contender contender)
    {
        return VisitedContenderList.Exists(c => c.Score == contender.Score)
               && contender.Score == _bestVisitedScore;
    }
}