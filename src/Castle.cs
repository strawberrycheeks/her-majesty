using HerMajesty.util;

namespace HerMajesty;

public class Castle
{
    public Princess Princess { get; }
    public Hall Hall { get; }

    public Castle()
    {
        Princess = new Princess();
        Hall = new Hall();
    }
    
    /// <summary>
    /// The main method of the program where the prince is selected by the princess.
    /// </summary>
    public void Method()
    {
        Hall.FillContendersList();

        Contender? prince = Princess.ChoosePrince(Hall.ContenderList);

        // TODO: OrderBy()
        // lines = lines.OrderBy(x => random.Next()).ToArray();

        // TODO: class FileWriter
        using var writer = new StreamWriter(Constants.ResultPath, false);
        foreach (var contender in Princess.Friend.ContenderList)
        {
            writer.WriteLine($"{contender.Score} {contender.Name}");
        }
        writer.WriteLine("=============");
        if (prince == null)
        {
            writer.WriteLine("Did not choose a prince!");
        }
        else
        {
            writer.WriteLine($"{prince.Score} {prince.Name}");
        }
    }
}