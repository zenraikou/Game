using Microsoft.AspNetCore.Mvc;
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
        catch (Exception error)
        {
            _logger.LogError(error.Message);

            var status = (int)HttpStatusCode.InternalServerError;

            var problem = new ProblemDetails()
            {
                Type = "Internal Server Error",
                Title = "Internal Server Error",
                Status = status,
                Detail = "An internal server error has occured."
            };

            var result = JsonSerializer.Serialize(problem);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = status;
            await context.Response.WriteAsync(result);
        }
    }
}
