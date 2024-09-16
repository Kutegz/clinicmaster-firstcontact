
using FluentValidation;
using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;

namespace ClinicMasterFirstContact.src.App.Common.Exceptions;

public sealed class AppExceptionHandler(ILogger<AppExceptionHandler> logger): IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, 
                                        CancellationToken cancellationToken)
    {

        (string title, int statusCode, string message) = exception switch
        {
            BadHttpRequestException err => ("Bad Request", StatusCodes.Status400BadRequest, err.Message),
            NotImplementedException err => ("Not Implemented", StatusCodes.Status501NotImplemented, err.Message),
            ValidationException err => ("Validation Error", StatusCodes.Status400BadRequest, err.Message),
            FormatException err => ("Bad Request", StatusCodes.Status400BadRequest, err.Message),
            UnauthorizedAccessException err => ("Unauthorized", StatusCodes.Status401Unauthorized, err.Message),
            HttpRequestException err => ("Bad Gateway", StatusCodes.Status502BadGateway, err.Message),
            Exception err => ("Internal Server Error", StatusCodes.Status500InternalServerError, err.Message),
            _ => ("Internal Server Error", StatusCodes.Status500InternalServerError, "An unexpected error occurred.")
        };

        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/problem+json";

        var response = new ErrorResponse
        {
            Title = title,
            StatusCode = statusCode,
            Message = message,
            TraceId = Activity.Current?.Id ?? context.TraceIdentifier
        };

        if (statusCode == StatusCodes.Status500InternalServerError)
        {
            logger.LogError(message: "{exception.GetType().FullName)}: ", args: exception.GetType().Name);
        }

        logger.LogError(message: "{exception.Message}, a request on {Environment.MachineName} with Trace Id: {Activity.Current.Id}", 
                                   args: [exception.Message, Environment.MachineName, Activity.Current?.Id ?? context.TraceIdentifier]);

        await context.Response.WriteAsJsonAsync(value: response, cancellationToken: cancellationToken);

        return  true;
    }
}


