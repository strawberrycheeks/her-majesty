using HerMajesty.Util;

namespace HerMajesty.Model;

public class Hall : IHall
{
    /// <summary>
    /// TODO:
    /// </summary>
    private readonly IContenderGenerator _contenderGenerator;
    
    /// <summary>
    /// List of contenders waiting for audience with Princess in the hall,
    /// must contain a list of 100 unique contenders
    /// </summary>
    private List<Contender> _contenderList;

    /// <summary>
    /// Enumerator for the list of contenders
    /// </summary>
    private List<Contender>.Enumerator _enumerator;

    public Hall(IContenderGenerator contenderGenerator)
    {
        _contenderGenerator = contenderGenerator;
        _contenderList = new List<Contender>();
    }

    /// <summary>
    /// Returns the filled and shuffled list of contenders
    /// </summary>
    public void FillContendersList()
    {
        _contenderList = _contenderGenerator.GenerateContenderList();
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
