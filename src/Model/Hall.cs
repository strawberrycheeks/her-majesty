using HerMajesty.Exception;
using HerMajesty.Util;

namespace HerMajesty.Model;

public class Hall
{
    /// <summary>
    /// List of contenders, waiting for audience with Princess in the hall,
    /// must contain a list of 100 unique contenders
    /// </summary>
    private readonly List<Contender> _contenderList;

    /// <summary>
    /// Enumerator for the list of contenders
    /// </summary>
    private List<Contender>.Enumerator _enumerator;

    public Hall()
    {
        _contenderList = new List<Contender>(Constants.ContenderCount);
        _enumerator = new List<Contender>.Enumerator();
    }

    /// <summary>
    /// Returns the shuffled list of contenders
    /// </summary>
    public void FillContendersList()
    {
        FileUtils.ReadContenderListFromFile(_contenderList);
        ValidateContenderList();
        _contenderList.Shuffle();
        _enumerator = _contenderList.GetEnumerator();
    }

    /// <summary>
    /// Get the next contender from the list
    /// </summary>
    /// <returns>
    /// Returns the next contender from the list. If there are no more
    /// contenders left in the list, returns null.
    /// </returns>
    public Contender? GetNextContender()
    {
        return _enumerator.MoveNext() ? _enumerator.Current : null;
    }

    private void ValidateContenderList()
    {
        // TODO: Нужно ли выносить проверки в отдельный метод Validate(), или их можно выполнять при считывании имён из файла?
        if (_contenderList.Count < Constants.ContenderCount)
        {
            throw new NotEnoughContendersException(
                _contenderList.Count, 
                Constants.ContenderCount);
        }
        
        foreach (var contender in _contenderList)
        {
            var found = _contenderList.FindAll(c => c.Name == contender.Name);
            if (found.Count > 1)
            {
                throw new ContenderNameRepeatedException(contender.Name);
            }
        }
    }
}
