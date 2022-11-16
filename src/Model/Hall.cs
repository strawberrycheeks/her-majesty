using HerMajesty.Util;

namespace HerMajesty.Model;

public class Hall : IHall
{
    /// <summary>
    /// List of contenders waiting for audience with Princess in the hall,
    /// must contain a list of 100 unique contenders
    /// </summary>
    private readonly List<Contender> _contenderList;

    /// <summary>
    /// Enumerator for the list of contenders
    /// </summary>
    private List<Contender>.Enumerator _enumerator;

    public Hall()
    {
        _contenderList = new List<Contender>(AppSettings.ContenderCount);
        _enumerator = new List<Contender>.Enumerator();
    }

    /// <summary>
    /// Returns the filled and shuffled list of contenders
    /// </summary>
    public void FillContendersList()
    {
        FileUtils.ReadContenderListFromFile(_contenderList, AppSettings.ContenderPath);
        _contenderList.Shuffle();
        _enumerator = _contenderList.GetEnumerator();
    }

    /// <summary>
    /// Gets the next contender from the list
    /// </summary>
    /// <returns>
    /// Returns the next contender from the list. If there are no more
    /// contenders left in the list, returns null.
    /// </returns>
    public Contender? GetNextContender()
    {
        return _enumerator.MoveNext() ? _enumerator.Current : null;
    }
}
