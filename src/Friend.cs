namespace HerMajesty;

public class Friend
{
    public List<Contender> ContenderList { get; }
    private int _bestContenderScore;

    public Friend()
    {
        ContenderList = new List<Contender>();
        _bestContenderScore = 0;
    }

    public void AddAudiencedContender(Contender contender)
    {
        UpdateBestScore(contender);
        ContenderList.Add(contender);
    }

    private void UpdateBestScore(Contender contender)
    {
        if (contender.Score > _bestContenderScore)
        {
            _bestContenderScore = contender.Score;
        }
    }

    public bool IsBetterThanPrevious(Contender contender)
    {
        return contender.Score == _bestContenderScore;
    }
}