namespace HerMajesty;

public class LadyInWaiting
{
    public List<Contender> ContenderList { get; }
    
    /// <summary>
    /// Stores the highest contender's score among all contenders
    /// </summary>
    private int _bestContenderScore;

    public LadyInWaiting()
    {
        ContenderList = new List<Contender>();
        _bestContenderScore = 0;
    }

    /// <summary>
    /// Adds the contender to the list and updates the best contender's score
    /// taking into account the score of the added contender
    /// </summary>
    /// <param name="contender"> A new contender to be added to the list </param>
    public void AddAudiencedContender(Contender contender)
    {
        ContenderList.Add(contender);
        UpdateBestScore(contender);
    }

    /// <summary>
    /// Saves the highest contender's score among all contenders who visited the Princess 
    /// </summary>
    /// <param name="contender"> A new contender who has just been added to the list </param>
    private void UpdateBestScore(Contender contender)
    {
        if (contender.Score > _bestContenderScore)
        {
            _bestContenderScore = contender.Score;
        }
    }

    /// <summary>
    /// Compares the score of the contender with the highest contender's score
    /// </summary>
    /// <param name="contender"> A contender whose score needs to be compared </param>
    public bool IsBetterThanPrevious(Contender contender)
    {
        return contender.Score == _bestContenderScore;
    }
}