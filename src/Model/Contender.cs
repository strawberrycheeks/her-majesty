namespace HerMajesty.Model;

public class Contender
{
    /// <summary>
    /// Name of the contender, must be unique
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// Score of the contender 
    /// </summary>
    public int Score { get; }

    public Contender(string name, int score)
    {
        Name = name;
        Score = score;
    }
}