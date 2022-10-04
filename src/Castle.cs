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

        var chosenPrince = Princess.ChoosePrince(Hall.ContenderList);
        
        PrintResult(chosenPrince);
    }

    /// <summary>
    /// Prints the list of reviewed contenders and the algorithm's result
    /// </summary>
    /// <param name="chosenPrince"> The prince who was chosen </param>
    private void PrintResult(Contender? chosenPrince)
    {
        using var writer = new StreamWriter(Constants.ResultPath, false);
        foreach (var contender in Princess.LadyInWaiting.ContenderList)
        {
            writer.WriteLine($"{contender.Score} {contender.Name}");
        }
        writer.WriteLine("===");

        var princessPoints = Princess.CalculateHappinessPoints(chosenPrince);
        switch (princessPoints)
        {
            case 0:
                writer.WriteLine($"Oh, bad choice! Happiness points: {princessPoints}");
                break;
            case 10:
                writer.WriteLine($"Did not choose a prince! Happiness points: {princessPoints}");
                break;
            default:
                writer.WriteLine($"...and they lived happily ever after! Happiness points: {princessPoints}");
                break;
        }
    }
}