namespace V_Project.Server;

public sealed class ErrorResponse
{
    public ErrorResponse(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public string Code { get; set; }
    public string Message { get; set; }
}