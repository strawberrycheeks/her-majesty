namespace HerMajesty;

public interface IStrategy
{
    public Contender? ChooseBestContender(List<Contender> contenders, Friend friend);
}