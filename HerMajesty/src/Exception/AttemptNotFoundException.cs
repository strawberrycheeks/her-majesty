namespace HerMajesty.Exception;

public class AttemptNotFoundException : HerMajestyAppException
{
    public AttemptNotFoundException() 
        : base(HerMajestyAppException.DefaultMessage)
    {
    }
    
    public AttemptNotFoundException(int attemptNumber) 
        : base($"Attempt with number {attemptNumber} was not found in database.")
    {
    }
}
