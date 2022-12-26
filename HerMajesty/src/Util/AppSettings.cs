using Microsoft.Extensions.Configuration;

namespace HerMajesty.Util;

public static class AppSettings
{
    public const int DefaultAttemptCount = 100;
    public const int DefaultContenderCount = 100;

    /// <summary>
    /// A number of attempt from the database
    /// </summary>
    public static int? AttemptNumber { get; set; } = null;
    
    /// <summary>
    /// Total number of attempts
    /// </summary>
    public static int AttemptCount { get; private set; } = DefaultAttemptCount;
    
    /// <summary>
    /// Total number of contenders 
    /// </summary>
    public static int ContenderCount { get; private set; } = DefaultContenderCount;

    /// <summary>
    /// Path to the file with names for contenders, must contain {ContenderCount}
    /// unique names
    /// </summary>
    public static string ContenderPath { get; private set; } = "../../../res/100-unique-names.txt";

    /// <summary>
    /// Path to the file with the printed algorithm's result
    /// </summary>
    public static string ResultPath { get; private set; } = "../../../res/result.txt";

    /// <summary>
    /// Information about database connection
    /// </summary>
    public static string DbConnection { get; private set; } = "Host=localhost;Port=5432;Database=hermajesty;Username=admin;Password=1234";

    public static void LoadConfigurationSettings(IConfiguration configuration)
    {
        SetAttemptCount(configuration["AttemptCount"]);
        SetContenderCount(configuration["ContenderCount"]);
        SetContenderPath(configuration["ContenderPath"]);
        SetDbConnection(configuration["ConnectionStrings:DefaultConnection"]);
        SetResultPath(configuration["ResultPath"]);
    }
    
    private static void SetAttemptCount(string? value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            AttemptCount = int.Parse(value);
        }
    }

    private static void SetContenderCount(string? value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            ContenderCount = int.Parse(value);
        }
    }
    
    private static void SetContenderPath(string? value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            ContenderPath = value;
        }
    }
    
    private static void SetDbConnection(string? value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            DbConnection = value;
        }
    }
    
    private static void SetResultPath(string? value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            ResultPath = value;
        }
    }
}