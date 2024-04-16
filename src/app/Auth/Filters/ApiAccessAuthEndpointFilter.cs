
using App.Common.Utils;

namespace App.Auth.Filters;
public sealed class ApiAccessAuthEndpointFilter(IConfiguration configuration) : IEndpointFilter
{
    public async ValueTask<dynamic?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var agentId = context.HttpContext.Request.Headers[Constants.XAgentId];
        var apiKey = context.HttpContext.Request.Headers[Constants.XApiKey];
        
        if (!IsAgentIdValid(agentId: agentId) || !IsApiKeyValid(apiKey: apiKey)) return Results.Unauthorized();
        
        return await next(context: context);
    }
    private bool IsAgentIdValid(string? agentId) => 
        !string.IsNullOrWhiteSpace(agentId) && agentId == configuration[Constants.AuthenticationAgentId];

    private bool IsApiKeyValid(string? apiKey) => 
        !string.IsNullOrWhiteSpace(apiKey) && apiKey == configuration[Constants.AuthenticationApiKey];
    
}