using System.Transactions;

namespace HerMajesty.Exception;

public class UnvisitedContenderComparedException : HerMajestyAppException
{
    public UnvisitedContenderComparedException() 
        : base(HerMajestyAppException.DefaultMessage)
    {
    }
    
    public UnvisitedContenderComparedException(string name) 
        : base($"Tried to compare the participant {name} who has not visited the Princess yet.")
    {
    }
}