namespace V_Project.Application;

public sealed class ForbiddenAccessException : Exception
{
    public ForbiddenAccessException() : base()
    {
    }
}