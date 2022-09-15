namespace HerMajesty;

public class Contender
{
    private string _name;
    private int _score;

    public string Name => _name;
    public int Score => _score;

    public Contender(string name, int score)
    {
        _name = name;
        _score = score;
    }
}