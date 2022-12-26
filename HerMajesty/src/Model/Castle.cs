using HerMajesty.Context;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using HerMajesty.Util;
using Microsoft.EntityFrameworkCore;

namespace HerMajesty.Model;

public class Castle : IHostedService
{
    private readonly IHostApplicationLifetime _lifetime;
    private readonly ILogger<Princess> _logger;
    
    private readonly IHall _hall;
    private readonly Princess _princess;

    private readonly PostgresDbContext _dbc;

    public Castle(
        IHall hall, 
        Princess princess,
        PostgresDbContext dbc,
        ILogger<Princess> logger, 
        IHostApplicationLifetime lifetime)
    {
        _dbc = dbc;
        _hall = hall;
        _princess = princess;
        _logger = logger;
        _lifetime = lifetime;
    }
    
    /// <summary>
    /// The main method of the program where the prince is selected by the princess
    /// </summary>
    private async void Run()
    {
        try
        {
            if (AppSettings.AttemptNumber == null)
            {
                await RunAllAttempts();
            } else {
                await RunAttempt(AppSettings.AttemptNumber.Value);
            }
        }
        catch (System.Exception ex)
        {
            _logger.LogError($"{ex.GetType()}: {ex.Message}");
        }
        finally
        {
            _lifetime.StopApplication();
        }
    }

    private async Task RunAllAttempts()
    {
        // _hall.FillContendersList();
        // var chosenPrince = _princess.ChoosePrince();
        // PrintResult(chosenPrince);
        
        var attempts = await _dbc.Attempts
            .Include(c => c.Contenders)
            .ToListAsync();

        foreach (var at in attempts)
        {
            _hall.FillContendersList(int.Parse(at.AttemptNumber));
            var chosenPrince = _princess.ChoosePrince();
            PrintResult(chosenPrince);
        }
        
        
        // var sum = attempts.Sum(at => _princess.ChoosePrince(at.AttemptNumber));
    }

    private async Task RunAttempt(int attemptNumber)
    {
        
    }

    /// <summary>
    /// Prints the list of reviewed contenders and the algorithm's result
    /// </summary>
    /// <param name="chosenPrince"> The prince who was chosen </param>
    private static void PrintResult(Contender? chosenPrince)
    {
        using var writer = new StreamWriter(AppSettings.ResultPath, false);
        // using var writer = new StreamWriter(Console.OpenStandardOutput());
        
        var chosenPrinceScore = chosenPrince?.Score;
        if (chosenPrince != null)
        {
            writer.WriteLine($"{chosenPrince.Name} ({chosenPrince.Score})");
        }

        var princessPoints = Princess.CalculateHappinessPoints(chosenPrinceScore);
        switch (princessPoints)
        {
            case Princess.BadPrinceChosenScore:
                writer.WriteLine($"Oh, bad choice! Happiness points: {princessPoints}");
                break;
            case Princess.NoPrinceChosenScore:
                writer.WriteLine($"Did not choose a prince! Happiness points: {princessPoints}");
                break;
            default:
                writer.WriteLine($"...and they lived happily ever after! Happiness points: {princessPoints}");
                break;
        }
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _lifetime.ApplicationStarted.Register(() =>
        {
            Task.Run(Run, cancellationToken);
        });
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}