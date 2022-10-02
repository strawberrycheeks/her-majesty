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
    /// The main method of the program where the prince is selected by the princess
    /// </summary>
    public void Run()
    {
        Hall.FillContendersList();

        Contender? prince = Princess.ChoosePrince(Hall.ContenderList);

        // TODO: class FileWriter
        using var writer = new StreamWriter(Constants.ResultPath, false);
        foreach (var contender in Princess.LadyInWaiting.ContenderList)
        {
            writer.WriteLine($"{contender.Score} {contender.Name}");
        }
        writer.WriteLine("=============");
        writer.WriteLine(prince == null ? "Did not choose a prince!" : $"{prince.Score} {prince.Name}");
    }
}