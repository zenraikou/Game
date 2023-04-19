using Game.API.Exceptions;
using KeyNotFoundException = System.Collections.Generic.KeyNotFoundException;
using UnauthorizedAccessException = System.UnauthorizedAccessException;

namespace Game.API.Middlewares;

public class GlobalErrorHandlerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Exception error)
        {
            switch (error)
            {
                case BadRequestException:
                    // "Bad Request"
                    break;
                case NotFoundException:
                    // "Not Found"
                    break;
                case KeyNotFoundException:
                    // "Key Not Found"
                    break;
                case UnauthorizedAccessException:
                    // "Unauthorized Access"
                    break;
                default:
                    // "Internal Server Error"
                    break;
            }
        }
    }
}
