using HerMajesty.Model;
using HerMajesty.Util;

namespace HerMajestyTests.Mock;

public static class MockContenderListGenerator
{
    public static List<Contender> GenerateAscendingList(int contCount = AppSettings.DefaultContenderCount)
    {
        var contenders = new List<Contender>();
        for (var i = 1; i <= contCount; ++i)
        {
            contenders.Add(new Contender(i, i.ToString()));
        }

        return contenders;
    }
    
    public static List<Contender> GenerateDescendingList(int contCount = AppSettings.DefaultContenderCount)
    {
        var contenders = new List<Contender>();
        for (var i = contCount; i >= 1; --i)
        {
            contenders.Add(new Contender(i, i.ToString()));
        }

        return contenders;
    }
    
    /// <summary>
    /// Generates a list of {contCount} contenders in descending order, but the
    /// largest in the order will appear at the top of the list
    /// </summary>
    /// <returns> Returns generated list </returns>
    public static List<Contender> GenerateMaximalHappinessList(int contCount = AppSettings.DefaultContenderCount)
    {
        var contenders = new List<Contender>();
        for (var i = contCount - 1; i >= 1; --i)
        {
            contenders.Add(new Contender(i, i.ToString()));
        }
        contenders.Add(new Contender(contCount, contCount.ToString()));
        
        return contenders;
    }
}