namespace HerMajesty.util;

public static class FileReader
{
    /// <summary>
    /// Fills a list of contenders with names read from a file and numbers from 1 to 100.
    /// The file must contain a list of 100 unique names. 
    /// </summary>
    /// <param name="list"> List of contenders to be filled </param>
    /// <param name="path"> Path to the file with the list of unique names </param>
    public static void ReadContendersList(List<Contender> list, string path = Constants.ContendersPath)
    {
        using var reader = new StreamReader(path);
        for (var i = 1; i <= Constants.ContendersCount; i++)
        {
            string? line;
            if ((line = reader.ReadLine()) == null) break;
            list.Add(new Contender(line, i));
        }
    }
}