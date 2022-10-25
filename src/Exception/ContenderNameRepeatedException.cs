namespace HerMajesty.Exception;

public class ContenderNameRepeatedException : HerMajestyAppException
{
    public ContenderNameRepeatedException() 
        : base(HerMajestyAppException.DefaultMessage)
    {
    }
    
    public ContenderNameRepeatedException(string name) 
        : base($"Contender with name '{name}' already exists in the list.")
    {
    }
}