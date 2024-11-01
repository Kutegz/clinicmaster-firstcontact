
namespace ClinicMasterFirstContact.src.App.Common.Utils;
public static class CommonConstants 
{
    public static string XAgentId => "X-Agent-Id";
    public static string XApiKey => "X-Api-Key";
    public static string ClinicMaster => "ClinicMaster";
    public static string XForwardedFor => "X-Forwarded-For";
    public static string CorsPolicyName => "CorsPolicy";
    public static string AuthenticationAgentId => "Authentication:AgentId";
    public static string AuthenticationApiKey => "Authentication:ApiKey";
    public static IReadOnlyList<string> OpenTelemetryMeterNames 
        => ["Microsoft.AspNetCore.Hosting", "System.Net.Http",
            "Microsoft.AspNetCore.Server.Kestrel", "ReadMedicalReport"];
    public static int HttpCallRetryCount => 3;
    public static IReadOnlyList<string> DateFormats 
        => ["dd MMM yyyy", "d MMM yyyy", "dd MMMM yyyy", 
            "d MMMM yyyy", "yyyy-MM-dd", "dd/MM/yyyy", 
            "dd-MM-yyyy", "d/M/yyyy", "d-M-yyyy"];
}
