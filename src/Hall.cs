namespace HerMajesty;

public class Hall
{
    public const int ContendersCount = 100;
    // TODO: replace with relative path
    private const string Path = "E:/Courses/7-semester/c-sharp/HerMajesty/res/listOfNames.txt";

    private List<Contender> _contenderList;
    public List<Contender> ContenderList => _contenderList;

    public Hall()
    {
        _contenderList = new List<Contender>(ContendersCount);
        
        FillContenderList(_contenderList);
        Shuffler.Shuffle(_contenderList);
    }

    private void FillContenderList(List<Contender> list)
    {
        using (StreamReader reader = new StreamReader(Path))
        {
            string? line;
            for (int i = 1; i <= ContendersCount; i++)
            {
                if ((line = reader.ReadLine()) == null) break;
                list.Add(new Contender(line, i));
            }
        }
    }
}

static class Shuffler
{
    public static Random Random = new Random();  

    // Using modern version of the Fisher–Yates shuffle algorithm
    // See more: https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = Random.Next(i);
            (list[i], list[j]) = (list[j], list[i]);
        }
    }
}