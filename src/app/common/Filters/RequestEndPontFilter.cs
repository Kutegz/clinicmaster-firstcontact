
using FluentValidation;

namespace App.Common.Filters;
public sealed class RequestEndPontFilter<T>(ILogger<RequestEndPontFilter<T>> logger, 
                                            IValidator<T> validator) : IEndpointFilter
{
    public async ValueTask<dynamic?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var item = context.Arguments.OfType<T>().FirstOrDefault(predicate: arg => arg?.GetType() == typeof(T));

        if (item is not null) 
        {
            var validation =  await validator.ValidateAsync(item);
            if (!validation.IsValid) 
            {
                logger.LogError("Invalid Data Supplied: {item}", item);
                return Results.ValidationProblem(validation.ToDictionary());
            }
        }

        return await next(context);
    }
}