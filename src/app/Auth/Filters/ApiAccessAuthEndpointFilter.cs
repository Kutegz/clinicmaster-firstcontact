
using App.Common.Utils;

namespace App.Auth.Filters;
public sealed class ApiAccessAuthEndpointFilter(IConfiguration configuration) : IEndpointFilter
{
    public async ValueTask<dynamic?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var agentId = context.HttpContext.Request.Headers[CommonConstants.XAgentId];
        var apiKey = context.HttpContext.Request.Headers[CommonConstants.XApiKey];
        
        if (!IsAgentIdValid(agentId: agentId) || !IsApiKeyValid(apiKey: apiKey)) return Results.Unauthorized();
        
        return await next(context: context);
    }
    private bool IsAgentIdValid(string? agentId) => 
        !string.IsNullOrWhiteSpace(value: agentId) && agentId == configuration[CommonConstants.AuthenticationAgentId];

    private bool IsApiKeyValid(string? apiKey) => 
        !string.IsNullOrWhiteSpace(value: apiKey) && apiKey == configuration[CommonConstants.AuthenticationApiKey];
    
}