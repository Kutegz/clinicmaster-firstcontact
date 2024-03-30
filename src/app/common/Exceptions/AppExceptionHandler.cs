
using FluentValidation;
using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;

namespace App.Common.Exceptions;
public sealed class AppExceptionHandler(ILogger<AppExceptionHandler> logger): IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, 
                                        CancellationToken cancellationToken)
    {

        (int statusCode, string title, string errorMessage) = exception switch
        {
            BadHttpRequestException error => (StatusCodes.Status400BadRequest, "Bad Request", error.Message),
            NotImplementedException error => (StatusCodes.Status501NotImplemented, "Not Implemented", error.Message),
            ValidationException error => (StatusCodes.Status400BadRequest, "Validation Error", error.Message),
            FormatException error => (StatusCodes.Status400BadRequest, "Bad Request", error.Message),
            UnauthorizedAccessException error => (StatusCodes.Status401Unauthorized, "Unauthorized", error.Message),
            _ => (StatusCodes.Status500InternalServerError, "Internal Server Error", "An unexpected error occurred.")
        };

        httpContext.Response.StatusCode = statusCode;
        httpContext.Response.ContentType = "application/problem+json";

        var response = new ErrorResponse
        {
            StatusCode = statusCode,
            Title = title,
            ErrorMessage = errorMessage
        };

        if (statusCode == StatusCodes.Status500InternalServerError)
        {
            logger.LogError(message: "{exception.GetType().FullName)}: ", exception.GetType().Name);
        }

        logger.LogError(message: "{exception.Message}, a request on {Environment.MachineName} with Trace Id: {Activity.Current.Id}", 
                                    exception.Message, Environment.MachineName, Activity.Current?.Id ?? httpContext.TraceIdentifier);

        await httpContext.Response.WriteAsJsonAsync(value: response, cancellationToken: cancellationToken);

        return  true;
    }
}
