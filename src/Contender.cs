namespace HerMajesty;

public class Contender
{
    /// <summary>
    /// Name of the contender, must be unique
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// Score of the contender. If score > 50, it equals to the 'happiness'
    /// points scored by the Princess  
    /// </summary>
    public int Score { get; }

    public Contender(string name, int score)
    {
        Name = name;
        Score = score;
    }
}