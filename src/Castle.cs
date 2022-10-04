using HerMajesty.strategy;
using HerMajesty.util;

namespace HerMajesty;

public class Castle
{
    private readonly Hall _hall;
    private readonly IStrategy _strategy;
    private readonly LadyInWaiting _ladyInWaiting;
    private readonly Princess _princess;

    public Castle()
    {
        _hall = new Hall();
        _ladyInWaiting = new LadyInWaiting();
        _strategy = new OptimalStrategy(_ladyInWaiting);
        _princess = new Princess(_strategy);
    }
    
    /// <summary>
    /// The main method of the program where the prince is selected by the princess
    /// </summary>
    public void Run()
    {
        _hall.FillContendersList();

        var chosenPrince = _princess.ChoosePrince(_hall.ContenderList);
        
        PrintResult(chosenPrince);
    }

    /// <summary>
    /// Prints the list of reviewed contenders and the algorithm's result
    /// </summary>
    /// <param name="chosenPrince"> The prince who was chosen </param>
    private void PrintResult(Contender? chosenPrince)
    {
        using var writer = new StreamWriter(Constants.ResultPath, false);
        foreach (var contender in _ladyInWaiting.ContenderList)
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