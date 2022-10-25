namespace HerMajesty.Exception;

public abstract class HerMajestyAppException : System.Exception
{
    public const string DefaultMessage = "An error occurred while the application was running.";
    
    public HerMajestyAppException() 
        : base(DefaultMessage)
    {
    }
    
    public HerMajestyAppException(string message) 
        : base(message)
    {
    }
}