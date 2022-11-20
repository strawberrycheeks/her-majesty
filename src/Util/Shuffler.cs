namespace HerMajesty.Util;

public static class Shuffler
{
    private static readonly Random Random = new();  

    /// <summary>
    /// Shuffles a list of elements of type T using modern version of the
    /// Fisher–Yates shuffle algorithm.
    /// See more: https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
    /// </summary>
    /// <param name="list"> The list to be shuffled </param>
    /// <typeparam name="T"> Type of elements in the list </typeparam>
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