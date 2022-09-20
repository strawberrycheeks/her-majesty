using HerMajesty.util;

namespace HerMajesty;

public class Hall
{
    public List<Contender> ContenderList { get; }

    public Hall()
    {
        ContenderList = new List<Contender>(Constants.ContendersCount);
    }

    public void FillContendersList()
    {
        FileReader.ReadContendersList(ContenderList);
        ContenderList.Shuffle();
    }
}
