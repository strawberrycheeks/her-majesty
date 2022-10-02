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
    /// Prints the list of reviewed contenders and the Princess's happiness
    /// points. Princess gets:
    /// a) 10 points if she does not choose any of the contenders,
    /// b) 0 if the score of the chosen contender is less than 51,
    /// c) points are equal to the contender's score (from 51 to 100) otherwise.
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

        var princessPoints = CalculatePrincessPoints(chosenPrince);
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

    private static int CalculatePrincessPoints(Contender? chosenPrince)
    {
        if (chosenPrince == null)
        {
            return 10;
        }
        return chosenPrince.Score > 50 ? chosenPrince.Score : 0 ;
    }
}