namespace HerMajesty.Exception;

public class EmployeeListNotFoundException : System.Exception
{
    public EmployeeListNotFoundException()
    {
    }

    public EmployeeListNotFoundException(string message)
        : base(message)
    {
    }

    public EmployeeListNotFoundException(string message, System.Exception inner)
        : base(message, inner)
    {
    }
}