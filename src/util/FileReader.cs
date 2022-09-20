namespace HerMajesty.util;

public static class FileReader
{
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