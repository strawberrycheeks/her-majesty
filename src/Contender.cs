namespace HerMajesty;

public class Contender
{
    public string Name { get; }
    public int Score { get; }

    public Contender(string name, int score)
    {
        Name = name;
        Score = score;
    }
}