using HerMajesty.Util;

namespace HerMajesty.Exception;

public class NotEnoughContendersException : HerMajestyAppException
{
    public NotEnoughContendersException() 
        : base(HerMajestyAppException.DefaultMessage)
    {
    }
    
    public NotEnoughContendersException(int read, int required, string path = Constants.ContenderPath) 
        : base($"File {path} does not contain enough contenders. Required = {required}, got = {read}.")
    {
    }
}