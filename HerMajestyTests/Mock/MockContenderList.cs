using HerMajesty.Entity;
using HerMajesty.Model;
using HerMajesty.Util;

namespace HerMajestyTests.Mock;

public static class MockContenderList
{
    public static List<ContenderEntity> GetAscendingList(int contCount = AppSettings.DefaultContenderCount)
    {
        var contenders = new List<Contender>();
        for (var i = 1; i <= contCount; ++i)
        {
            contenders.Add(new Contender(i, i.ToString()));
        }

        return contenders.Map();
    }
    
    public static List<ContenderEntity> GetDescendingList(int contCount = AppSettings.DefaultContenderCount)
    {
        var contenders = new List<Contender>();
        for (var i = contCount; i >= 1; --i)
        {
            contenders.Add(new Contender(i, i.ToString()));
        }

        return contenders.Map();
    }
    
    /// <summary>
    /// Generates a list of {contCount} contenders in descending order, but the
    /// largest in the order will appear at the top of the list
    /// </summary>
    /// <returns> Returns generated list </returns>
    public static List<ContenderEntity> GetMaximalHappinessList(int contCount = AppSettings.DefaultContenderCount)
    {
        var contenders = new List<Contender>();
        for (var i = contCount - 1; i >= 1; --i)
        {
            contenders.Add(new Contender(i, i.ToString()));
        }
        contenders.Add(new Contender(contCount, contCount.ToString()));
        
        return contenders.Map();
    }
    
    private static List<ContenderEntity> Map(this IEnumerable<Contender> contenders)
    {
        var order = 0;
        return contenders.Select(c => new ContenderEntity()
        {
            Name = c.Name,
            Score = c.Score,
            Order = order++
        }).ToList();
    }
}