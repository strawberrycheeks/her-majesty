namespace HerMajesty.util;

public static class Constants
{
    /// <summary>
    /// Total number of contenders 
    /// </summary>
    public const int ContendersCount = 100;
    
    /// <summary>
    /// The Euler's number, used in the algorithm of choosing the Prince 
    /// </summary>
    public const double EulerNumber = 2.7182818284;
    
    /// <summary>
    /// Path to the file with the printed algorithm's result
    /// </summary>
    public const string ResultPath = "../../../res/result.txt";
    
    /// <summary>
    /// Path to the file with names for contenders, must contain 100 unique names
    /// </summary>
    public const string ContendersPath = "../../../res/contenders.txt";
}