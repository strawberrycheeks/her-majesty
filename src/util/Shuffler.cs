namespace HerMajesty.util;

public static class Shuffler
{
    private static readonly Random Random = new Random();  

    // Using modern version of the Fisher–Yates shuffle algorithm
    // See more: https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
    public static void Shuffle<T>(this IList<T> list)
    {
        var n = list.Count;
        for (var i = n - 1; i > 0; i--)
        {
            var j = Random.Next(i);
            (list[i], list[j]) = (list[j], list[i]);
        }
    }
}