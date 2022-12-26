using HerMajesty.Exception;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using HerMajesty.Repository;
using HerMajesty.Util;

namespace HerMajesty.Model;

public class Castle : IHostedService
{
    private readonly IHostApplicationLifetime _lifetime;
    private readonly ILogger<Princess> _logger;
    
    private readonly IHall _hall;
    private readonly Princess _princess;

    private readonly IAttemptRepository _attemptRepository;

    public Castle(
        IHall hall, 
        Princess princess,
        IAttemptRepository attemptRepository,
        ILogger<Princess> logger, 
        IHostApplicationLifetime lifetime)
    {
        _hall = hall;
        _princess = princess;
        _attemptRepository = attemptRepository;
        _logger = logger;
        _lifetime = lifetime;
    }
    
    /// <summary>
    /// The main method of the program where the prince is selected by the princess
    /// </summary>
    private void Run()
    {
        try
        {
            ClearResultFile();
            if (AppSettings.AttemptNumber == null)
            {
                RunAllAttempts();
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

    private void RunAllAttempts()
    {
        var attempts = _attemptRepository
            .GetAllAttemptsAsync().Result?.ToList();
        
        if (attempts == null || attempts.Count == 0)
        {
            throw new AttemptNotFoundException(0);
        }

        var sum = 0.0;
        foreach (var at in attempts)
        {
            _hall.FillContendersList(int.Parse(at.AttemptNumber));
            var chosenPrince = _princess.ChoosePrince();
            sum += Princess.CalculateHappinessPoints(chosenPrince?.Score);
            PrintAttemptResult(int.Parse(at.AttemptNumber), chosenPrince);
        }
        PrintAverageResult(attempts.Count, sum);
    }

    private void RunAttempt(int attemptNumber)
    {
        _hall.FillContendersList(attemptNumber);
        var chosenPrince = _princess.ChoosePrince();
        PrintAttemptResult(attemptNumber, chosenPrince);
    }
    
    private static void ClearResultFile()
    {
        using var writer = new StreamWriter(AppSettings.ResultPath, false);
    }

    /// <summary>
    /// Prints the average algorithm's result for all attempts from database
    /// </summary>
    /// <param name="attemptsCount"> Total number of attempts </param>
    /// <param name="sum"> The amount of happiness points scored for all attempts </param>
    private static void PrintAverageResult(int attemptsCount, double sum)
    {
        using var writer = new StreamWriter(AppSettings.ResultPath, true);
        writer.WriteLine($"Average happiness for {attemptsCount} attempts: {sum / attemptsCount}");
    }

    /// <summary>
    /// Prints the algorithm's result for an attempt
    /// </summary>
    /// <param name="chosenPrince"> The prince who was chosen </param>
    private static void PrintAttemptResult(int attemptNumber, Contender? chosenPrince)
    {
        using var writer = new StreamWriter(AppSettings.ResultPath, true);
        writer.Write($"[ATTEMPT N {attemptNumber}]");
        
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