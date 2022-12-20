namespace HerMajesty.Model;

public interface IContenderListGenerator
{
    /// <summary>
    /// Returns the filled and shuffled list of contenders
    /// </summary>
    public List<Contender> GenerateContenderList();
    
    /// <summary>
    /// Reads a list of name from a text file {filepath} and creates
    /// a shuffled enumerated list of contenders
    /// </summary>
    public List<Contender> GenerateContenderList(string filepath);
}