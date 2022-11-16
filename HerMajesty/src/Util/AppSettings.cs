using Microsoft.Extensions.Configuration;

namespace HerMajesty.Util;

public static class AppSettings
{
    /// <summary>
    /// Total number of contenders 
    /// </summary>
    public static int ContenderCount { get; private set; } = 100;

    /// <summary>
    /// Path to the file with names for contenders, must contain 100 unique names
    /// </summary>
    public static string ContenderPath { get; private set; } = "../../../res/100-unique-names.txt";

    /// <summary>
    /// Path to the file with the printed algorithm's result
    /// </summary>
    public static string ResultPath { get; private set; } = "../../../res/result.txt";

    public static void LoadConfigurationSettings(IConfiguration configuration)
    {
        SetContenderCount(configuration["ContenderCount"]);
        SetContenderPath(configuration["ContenderPath"]);
        SetResultPath(configuration["ResultPath"]);
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
    
    private static void SetResultPath(string? value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            ResultPath = value;
        }
    }
}