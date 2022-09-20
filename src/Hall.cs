using HerMajesty.util;

namespace HerMajesty;

public class Hall
{
    private List<Contender> _contenderList;
    public List<Contender> ContenderList => _contenderList;

    public Hall()
    {
        _contenderList = new List<Contender>(Constants.ContendersCount);
        
        FillContenderList(_contenderList);
        Shuffler.Shuffle(_contenderList);
    }

    private void FillContenderList(List<Contender> list)
    {
        using (StreamReader reader = new StreamReader(Constants.ContendersPath))
        {
            string? line;
            for (int i = 1; i <= Constants.ContendersCount; i++)
            {
                if ((line = reader.ReadLine()) == null) break;
                list.Add(new Contender(line, i));
            }
        }
    }
}
