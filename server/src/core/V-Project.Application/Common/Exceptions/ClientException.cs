namespace V_Project.Application;

public sealed class ClientException : Exception
{
    public ClientException() : base()
    {
    }
    
    public ClientException(string message) : base(message)
    {
    }
}