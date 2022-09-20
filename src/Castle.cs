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

        var cutoff = (int) Math.Round(Constants.ContendersCount / Constants.EulerNumber);
        for (var i = 0; i < Constants.ContendersCount; i++)
        {
            if (i < cutoff) { continue; }
            else
            {
                /*
                 * STOPPED HERE!
                 */
            }
        }
        
        // using var writer = new StreamWriter(Constants.ResultPath, false);
        // foreach (var contender in Hall.ContenderList)
        // {
        //     writer.WriteLine($"{contender.Score} {contender.Name}");
        // }
    }
}