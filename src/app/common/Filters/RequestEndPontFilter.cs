
using FluentValidation;

namespace App.Common.Filters;
public sealed class RequestEndPontFilter<TRequest>(ILogger<RequestEndPontFilter<TRequest>> logger, 
                                                    IValidator<TRequest> validator) : IEndpointFilter
{
    public async ValueTask<dynamic?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        TRequest request = context.Arguments.OfType<TRequest>().First(predicate: arg => arg?.GetType() == typeof(TRequest));

        if (request is not null) 
        {
            var validation =  await validator.ValidateAsync(instance: request, cancellation: context.HttpContext.RequestAborted);
            if (!validation.IsValid) 
            {
                logger.LogError(message: "Invalid Data Supplied: {request}", args: [request]);
                return Results.ValidationProblem(errors: validation.ToDictionary());
            }
        }

        return await next(context);
    }
}