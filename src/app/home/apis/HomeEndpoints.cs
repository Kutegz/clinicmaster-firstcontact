
namespace App.Home.Apis;
public static class HomeEndpoints 
{
    public static void ConfigureHomeApis(this WebApplication app)
    {
        // Includes all API endpoint mappings as well as /metrics for Prometheus/OpenTelemetry
        app.MapGet(pattern: "/error", handler: () =>  Results.Problem()).AllowAnonymous();
        app.MapGet(pattern: "/", handler: () => new 
            {
                IsLive = true,
                Message = "Welcome to ClinicMaster First Contact API",
                Descrition = "Provide patient number to get patient data summary"
            }
            
        ).AllowAnonymous();
    }
}