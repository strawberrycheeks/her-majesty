namespace HerMajesty.Model;

public interface IContenderGenerator
{
    /// <summary>
    /// Returns the filled and shuffled list of contenders
    /// </summary>
    public List<Contender> GenerateContenderList();
}