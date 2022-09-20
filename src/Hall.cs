using HerMajesty.util;

namespace HerMajesty;

public class Hall
{
    public List<Contender> ContenderList { get; }

    public Hall()
    {
        ContenderList = new List<Contender>(Constants.ContendersCount);
        
        FillContenderList(ContenderList);
        Shuffler.Shuffle(ContenderList);
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
