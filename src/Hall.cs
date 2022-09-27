using HerMajesty.util;

namespace HerMajesty;

public class Hall
{
    /// <summary>
    /// List of contenders, waiting for audience with Princess in the hall
    /// </summary>
    public List<Contender> ContenderList { get; }

    public Hall()
    {
        ContenderList = new List<Contender>(Constants.ContendersCount);
    }

    /// <summary>
    /// Returns the shuffled list of 100 unique contenders
    /// </summary>
    public void FillContendersList()
    {
        FileUtils.ReadContendersListFromFile(ContenderList);
        ContenderList.Shuffle();
    }
}
