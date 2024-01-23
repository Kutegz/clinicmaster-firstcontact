
namespace App.Auth;

public sealed class ApiKeyAuthEndpointFilter(IConfiguration configuration) : IEndpointFilter
{
    private const string ApiKeyHeaderName = "X-Api-Key";
    public async ValueTask<dynamic?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var apiKey = context.HttpContext.Request.Headers[ApiKeyHeaderName];
        if (!IsApiKeyValid(apiKey: apiKey)) return Results.Unauthorized();
        
        return await next(context: context);
    }
    private bool IsApiKeyValid(string? apiKey) => 
        !string.IsNullOrWhiteSpace(apiKey) && apiKey == configuration["Authentication:ApiKey"];
    
}