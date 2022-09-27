namespace HerMajesty;

/// <summary>
/// TODO: Rename to BaseFriend, BaseStrategy
/// </summary>
public class Friend
{
    public List<Contender> ContenderList { get; }
    private int _bestContenderScore;

    public Friend()
    {
        ContenderList = new List<Contender>();
        _bestContenderScore = 0;
    }

    /// <summary>
    /// TODO:
    /// </summary>
    public void AddAudiencedContender(Contender contender)
    {
        UpdateBestScore(contender);
        ContenderList.Add(contender);
    }

    /// <summary>
    /// TODO:
    /// </summary>
    private void UpdateBestScore(Contender contender)
    {
        if (contender.Score > _bestContenderScore)
        {
            _bestContenderScore = contender.Score;
        }
    }

    /// <summary>
    /// TODO:
    /// </summary>
    public bool IsBetterThanPrevious(Contender contender)
    {
        return contender.Score == _bestContenderScore;
    }
}