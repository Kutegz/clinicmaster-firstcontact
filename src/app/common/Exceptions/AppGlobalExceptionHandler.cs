

using Microsoft.AspNetCore.Diagnostics;

namespace App.Common.Exceptions;

public sealed class AppGlobalExceptionHandler(ILogger<AppGlobalExceptionHandler> logger): IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, 
                                        CancellationToken cancellationToken)
    {

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        httpContext.Response.ContentType = "application/problem+json";
        var response = new ErrorResponse
        {
            StatusCode = StatusCodes.Status500InternalServerError,
            Title = "Internal Server Error",
            ErrorMessage = "An unexpected error occurred. Please try again later."
        };

        logger.LogError(message: "{exception.Message}: ", exception.Message);
        logger.LogError(message: "{exception.GetType().FullName)}: ", exception.GetType().Name);

        await httpContext.Response.WriteAsJsonAsync(value: response, cancellationToken: cancellationToken);
        return  true;
    }
}
