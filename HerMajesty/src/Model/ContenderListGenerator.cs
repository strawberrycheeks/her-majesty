using HerMajesty.Exception;
using HerMajesty.Util;

namespace HerMajesty.Model;

public class ContenderListGenerator : IContenderListGenerator
{
    public List<Contender> GenerateContenderList()
    {
        var contenderList = new List<Contender>();
        ReadContenderListFromFile(contenderList, AppSettings.ContenderPath);
        contenderList.Shuffle();
        return contenderList;
    }
    
    public List<Contender> GenerateContenderList(string filepath)
    {
        var contenderList = new List<Contender>();
        ReadContenderListFromFile(contenderList, filepath);
        contenderList.Shuffle();
        return contenderList;
    }
    
    /// <summary>
    /// Fills a list of contenders with names read from a file and numbers from 1 to 100.
    /// The file must contain a list of 100 unique names. 
    /// </summary>
    /// <param name="contenderList"> List of contenders to be filled </param>
    /// <param name="path"> Path to the file with the list of 100 unique names </param>
    /// <exception cref="InvalidContendersNumberException">
    /// Thrown if the file does not contain the required number of names
    /// </exception>
    private static void ReadContenderListFromFile(ICollection<Contender> contenderList, string path)
    {
        using var reader = new StreamReader(path);
        for (var i = 1; i <= AppSettings.ContenderCount; i++)
        {
            string? line;
            if ((line = reader.ReadLine()) == null)
            {
                throw new InvalidContendersNumberException(
                    i,
                    AppSettings.ContenderCount, 
                    path);
            }
            contenderList.Add(new Contender(i, line));
        }
    }
}