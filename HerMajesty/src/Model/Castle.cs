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
                RunAttempt(AppSettings.AttemptNumber.Value);
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
        var attempts = await _dbc.Attempts
            .Include(c => c.Contenders)
            .ToListAsync();

        var sum = 0.0;
        foreach (var at in attempts)
        {
            _hall.FillContendersList(int.Parse(at.AttemptNumber));
            var chosenPrince = _princess.ChoosePrince();
            sum += Princess.CalculateHappinessPoints(chosenPrince?.Score);
            
            //
            PrintAttemptResult(int.Parse(at.AttemptNumber), chosenPrince);
            //
        }
        PrintAverageResult(attempts.Count, sum);
    }

    private void RunAttempt(int attemptNumber)
    {
        _hall.FillContendersList(attemptNumber);
        var chosenPrince = _princess.ChoosePrince();
        PrintAttemptResult(attemptNumber, chosenPrince);
    }

    /// <summary>
    /// Prints the average algorithm's result for all attempts from database
    /// </summary>
    /// <param name="attemptsCount"> Total number of attempts </param>
    /// <param name="sum"> The amount of happiness points scored for all attempts </param>
    private static void PrintAverageResult(int attemptsCount, double sum)
    {
        using var writer = new StreamWriter(AppSettings.ResultPath, false);
        writer.WriteLine($"Average happiness for {attemptsCount} attempts: {sum / attemptsCount}");
    }

    /// <summary>
    /// Prints the algorithm's result for an attempt
    /// </summary>
    /// <param name="chosenPrince"> The prince who was chosen </param>
    private static void PrintAttemptResult(int attemptNumber, Contender? chosenPrince)
    {
        // using var writer = new StreamWriter(AppSettings.ResultPath, false);
        using var writer = new StreamWriter(Console.OpenStandardOutput());
        writer.WriteLine($"Attempt N {attemptNumber}:");
        
        var princessPoints = Princess.CalculateHappinessPoints(chosenPrince?.Score);
        switch (princessPoints)
        {
            case Princess.BadPrinceChosenScore:
                writer.WriteLine($"\tOh, bad choice! Happiness points: {princessPoints}");
                break;
            case Princess.NoPrinceChosenScore:
                writer.WriteLine($"\tDid not choose a prince! Happiness points: {princessPoints}");
                break;
            default:
                writer.WriteLine($"\t...and they lived happily ever after! Happiness points: {princessPoints}");
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