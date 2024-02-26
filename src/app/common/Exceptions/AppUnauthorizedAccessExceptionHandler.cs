
using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;

namespace App.Common.Exceptions;
public sealed class AppUnauthorizedAccessExceptionHandler(ILogger<AppBadHttpRequestExceptionHandler> logger): IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, 
                                        CancellationToken cancellationToken)
    {

        if (exception is UnauthorizedAccessException unauthorizedAccessException)
        {
            httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            httpContext.Response.ContentType = "application/problem+json";
            var response = new ErrorResponse
            {
                StatusCode = StatusCodes.Status401Unauthorized,
                Title = "Unauthorized",
                ErrorMessage = unauthorizedAccessException.Message
            };

            logger.LogError(message: "{exception.Message}, a request on {Environment.MachineName} with Trace Id: {Activity.Current.Id}", 
                                        exception.Message, Environment.MachineName, Activity.Current?.Id ?? httpContext.TraceIdentifier);

            await httpContext.Response.WriteAsJsonAsync(value: response, cancellationToken: cancellationToken);
            return  true;
        }

        return  false;
    }
}
