using HerMajesty.DbModel;
using HerMajesty.Exception;
using HerMajesty.Repository;

namespace HerMajesty.Model;

public class Hall : IHall
{
    /// <summary>
    /// List of contenders waiting for audience with Princess in the hall,
    /// must contain a list of 100 unique contenders
    /// </summary>
    private List<Contender> _contenderList;

    /// <summary>
    /// Enumerator for the list of contenders
    /// </summary>
    private List<Contender>.Enumerator _enumerator;
    
    private readonly IAttemptRepository _attemptRepository;

    public Hall(IAttemptRepository attemptRepository)
    {
        _attemptRepository = attemptRepository;
        _contenderList = new List<Contender>();
        _enumerator = _contenderList.GetEnumerator();
    }

    /// <summary>
    /// Returns the filled and shuffled list of contenders
    /// </summary>
    public void FillContendersList(int attemptNumber)
    {
        var attemptEntity = _attemptRepository.GetAttemptByNumberAsync(attemptNumber.ToString());
        
        if (attemptEntity.Result == null)
        {
            throw new AttemptNotFoundException(attemptNumber);
        }

        _contenderList = Map(attemptEntity.Result.Contenders);
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
    /// Maps a collection of database entities to the collection of app entities
    /// </summary>
    /// <param name="contenders"> A collection to be mapped </param>
    /// <returns> Returns a mapped collection of app entities </returns>
    private static List<Contender> Map(IEnumerable<ContenderEntity> contenders)
    {
        return contenders.OrderBy(ce => ce.Order)
            .Select(ce => new Contender(ce.Score, ce.Name!)).ToList();
    }
}
