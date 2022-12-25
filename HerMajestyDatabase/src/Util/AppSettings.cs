using Microsoft.Extensions.Configuration;

namespace HerMajestyDatabase.Util;

public class AppSettings
{
    public const int DefaultAttemptCount = 100;
    
    /// <summary>
    /// Total number of attempts
    /// </summary>
    public static int AttemptCount { get; private set; } = DefaultAttemptCount;
    
    /// <summary>
    /// Path to the file with names for contenders, must contain {ContenderCount}
    /// unique names
    /// </summary>
    public static string DbConnection { get; private set; } = "Host=localhost;Port=5432;Database=hermajesty;Username=admin;Password=1234";

    public static void LoadConfigurationSettings(IConfiguration configuration)
    {
        SetAttemptCount(configuration["AttemptCount"]);
        SetDbConnection(configuration["DbConnection"]);
    }
    
    private static void SetAttemptCount(string? value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            AttemptCount = int.Parse(value);
        }
    }
    
    private static void SetDbConnection(string? value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            DbConnection = value;
        }
    }
}