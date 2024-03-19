
namespace App.Auth;
public sealed class ApiAccessAuthEndpointFilter(IConfiguration configuration) : IEndpointFilter
{
    public async ValueTask<dynamic?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var agentId = context.HttpContext.Request.Headers["X-Agent-Id"];
        var apiKey = context.HttpContext.Request.Headers["X-Api-Key"];
        
        if (!IsAgentIdValid(agentId: agentId) || !IsApiKeyValid(apiKey: apiKey)) return Results.Unauthorized();
        
        return await next(context: context);
    }
    private bool IsAgentIdValid(string? agentId) => 
        !string.IsNullOrWhiteSpace(agentId) && agentId == configuration["Authentication:AgentId"];

    private bool IsApiKeyValid(string? apiKey) => 
        !string.IsNullOrWhiteSpace(apiKey) && apiKey == configuration["Authentication:ApiKey"];
    
}