using HerMajesty.Exception;
using HerMajesty.Util;

namespace HerMajesty.Model;

public class Hall : IHall
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
    /// Returns the filled and shuffled list of contenders
    /// </summary>
    public void FillContendersList()
    {
        FileUtils.ReadContenderListFromFile(_contenderList);
        ValidateContenderList();
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

    /// <summary>
    /// Validates the list of contenders
    /// </summary>
    /// <exception cref="NotEnoughContendersException">
    /// Thrown if the list does not contain the required number of contenders
    /// </exception>
    /// <exception cref="ContenderNameRepeatedException">
    /// Thrown if a name appears in the list more that once
    /// </exception>
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
