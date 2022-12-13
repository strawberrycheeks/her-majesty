using HerMajesty.Model;
using HerMajesty.Util;

namespace HerMajestyTests.Mock;

public class MockContenderList
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

    public static List<Contender> Generate(int contCount = AppSettings.DefaultContenderCount)
    {
        var contenders = new List<Contender>();
        return contenders;
    }
}