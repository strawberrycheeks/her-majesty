using Microsoft.Extensions.Configuration;

namespace HerMajesty.Util;

public static class AppSettings
{
    /// <summary>
    /// Total number of contenders 
    /// </summary>
    private const int DefaultContenderCount = 100;

    /// <summary>
    /// Path to the file with names for contenders, must contain 100 unique names
    /// </summary>
    private const string DefaultContenderPath = "../../../res/100-unique-names.txt";
    
    /// <summary>
    /// Path to the file with the printed algorithm's result
    /// </summary>
    private const string DefaultResultPath = "../../../res/result.txt";
    
    /// <summary>
    /// 
    /// </summary>
    public static int ContenderCount { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public static string ContenderPath { get; private set; }
    
    /// <summary>
    /// 
    /// </summary>
    public static string ResultPath { get; private set; }

    public static void LoadConfigurationSettings(IConfiguration configuration)
    {
        SetContenderCount(configuration["ContenderCount"]);
        SetContenderPath(configuration["ContenderPath"]);
        SetResultPath(configuration["ResultPath"]);
    }

    private static void SetContenderCount(string? value)
    {
        ContenderCount = string.IsNullOrEmpty(value) 
            ? DefaultContenderCount 
            : int.Parse(value);
    }
    
    private static void SetContenderPath(string? value)
    {
        ContenderPath = string.IsNullOrEmpty(value) 
            ? DefaultContenderPath 
            : value;
    }
    
    private static void SetResultPath(string? value)
    {
        ResultPath = string.IsNullOrEmpty(value) 
            ? DefaultResultPath 
            : value;
    }
}