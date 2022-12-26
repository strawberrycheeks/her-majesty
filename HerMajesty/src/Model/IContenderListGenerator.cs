namespace HerMajesty.Model;

public interface IContenderListGenerator
{
    /// <summary>
    /// Generates a shuffled list of contenders
    /// </summary>
    public List<Contender> GenerateContenderList();
}