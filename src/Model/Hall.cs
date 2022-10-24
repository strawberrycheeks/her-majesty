using HerMajesty.Util;

namespace HerMajesty.Model;

public class Hall
{
    /// <summary>
    /// List of contenders, waiting for audience with Princess in the hall,
    /// must contain a list of 100 unique contenders
    /// </summary>
    public List<Contender> ContenderList { get; }

    public Hall()
    {
        ContenderList = new List<Contender>(Constants.ContendersCount);
    }

    /// <summary>
    /// Returns the shuffled list of contenders
    /// </summary>
    public void FillContendersList()
    {
        FileUtils.ReadContenderListFromFile(ContenderList);
        ContenderList.Shuffle();
    }
}
