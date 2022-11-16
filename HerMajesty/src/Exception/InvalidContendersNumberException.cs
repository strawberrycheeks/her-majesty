using HerMajesty.Util;

namespace HerMajesty.Exception;

public class InvalidContendersNumberException : HerMajestyAppException
{
    public InvalidContendersNumberException() 
        : base(HerMajestyAppException.DefaultMessage)
    {
    }
    
    public InvalidContendersNumberException(int read, int required, string path) 
        : base($"File {path} does not contain enough contenders. Required = {required}, got = {read}.")
    {
    }
}