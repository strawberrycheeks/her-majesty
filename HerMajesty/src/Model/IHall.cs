namespace HerMajesty.Model;

public interface IHall
{
    /// <summary>
    /// Returns the filled and shuffled list of contenders
    /// </summary>
    public Task FillContendersList(int attemptNumber);

    /// <summary>
    /// Gets the next contender from the list
    /// </summary>
    public Contender? GetNextContender();
}