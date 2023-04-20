using System.Net;
using System.Text.Json;

namespace Game.API.Middlewares;

public class GlobalErrorHandlerMiddleware : IMiddleware
{
    private readonly ILogger<GlobalErrorHandlerMiddleware> _logger;

    public GlobalErrorHandlerMiddleware(ILogger<GlobalErrorHandlerMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            _logger.LogInformation("An internal server error has occured.");
            await GlobalErrorHandler(context, ex);
        }
    }

    private static Task GlobalErrorHandler(HttpContext context, Exception ex)
    {
        var code = (int)HttpStatusCode.InternalServerError;
        var result = JsonSerializer.Serialize(new { error = "An internal server error has occured.", ex.StackTrace });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = code;
        return context.Response.WriteAsync(result);
    }
}
