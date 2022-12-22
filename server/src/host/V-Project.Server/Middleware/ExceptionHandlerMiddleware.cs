using System.Net;
using System.Text.Json;
using V_Project.Application;

namespace V_Project.Server;

public sealed class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionMessageAsync(context, ex).ConfigureAwait(false);
        }
    }

    private static async Task HandleExceptionMessageAsync(HttpContext context, Exception exception)
    {
        ErrorResponse response;
        int code;
        switch (exception)
        {
            case ForbiddenAccessException:
                code = (int)HttpStatusCode.Forbidden;
                response = new ErrorResponse(
                    "ForbiddenAccess",
                    "You dont have an access to do that.");
                LogWarning(context, exception, "Forbidden Access");
                break;
            case ClientException:
                code = (int)HttpStatusCode.BadRequest;
                response = new ErrorResponse(
                    "ClientException",
                    exception.Message);
                LogWarning(context, exception, "Bad Request");
                break;
            default:
                code = (int)HttpStatusCode.InternalServerError;
                response = new ErrorResponse(
                    "InternalServerError",
                    "Error occured on the server. Please contact an administrator.");
                LogError(context, exception, "Internal Server Error");
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = code;
        var result = JsonSerializer.Serialize(response, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        await context.Response.WriteAsync(result);
    }

    private static void LogWarning(HttpContext context, Exception exception, string message)
    {
        context.RequestServices.GetService<ILogger<ExceptionHandlerMiddleware>>()?
            .LogWarning(exception, message);
    }

    private static void LogError(HttpContext context, Exception exception, string message)
    {
        context.RequestServices.GetService<ILogger<ExceptionHandlerMiddleware>>()?
            .LogError(exception, message);
    }
}

public static class ExceptionHandlerMiddlewareExtensions
{
    public static void UseExceptionHandlerMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}