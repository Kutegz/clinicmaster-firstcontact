
using FluentValidation;
using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;

namespace App.Common.Exceptions;
public sealed class AppExceptionHandler(ILogger<AppExceptionHandler> logger): IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, 
                                        CancellationToken cancellationToken)
    {

        (int statusCode, string title, string errorMessage) = exception switch
        {
            BadHttpRequestException err => (StatusCodes.Status400BadRequest, "Bad Request", err.Message),
            NotImplementedException err => (StatusCodes.Status501NotImplemented, "Not Implemented", err.Message),
            ValidationException err => (StatusCodes.Status400BadRequest, "Validation Error", err.Message),
            FormatException err => (StatusCodes.Status400BadRequest, "Bad Request", err.Message),
            UnauthorizedAccessException err => (StatusCodes.Status401Unauthorized, "Unauthorized", err.Message),
            HttpRequestException err => (StatusCodes.Status502BadGateway, "Bad Gateway", err.Message),
            Exception err => (StatusCodes.Status500InternalServerError, "Internal Server Error", err.Message),
            _ => (StatusCodes.Status500InternalServerError, "Internal Server Error", "An unexpected error occurred.")
        };

        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/problem+json";

        var response = new ErrorResponse
        {
            StatusCode = statusCode,
            Title = title,
            ErrorMessage = errorMessage,
            TraceId = Activity.Current?.Id ?? context.TraceIdentifier
        };

        if (statusCode == StatusCodes.Status500InternalServerError)
        {
            logger.LogError(message: "{exception.GetType().FullName)}: ", exception.GetType().Name);
        }

        logger.LogError(message: "{exception.Message}, a request on {Environment.MachineName} with Trace Id: {Activity.Current.Id}", 
                                    exception.Message, Environment.MachineName, Activity.Current?.Id ?? context.TraceIdentifier);

        await context.Response.WriteAsJsonAsync(value: response, cancellationToken: cancellationToken);

        return  true;
    }
}
