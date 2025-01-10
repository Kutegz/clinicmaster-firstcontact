
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
    public static string RateLimitPolicyName => "fixedWindowPolicy";
    public static int RateTimeSpanSeconds => 10;
    public static int RatePermitLimit => 5;
    public static IReadOnlyList<string> OpenTelemetryMeterNames 
        => ["Microsoft.AspNetCore.Hosting", "System.Net.Http",
            "Microsoft.AspNetCore.Server.Kestrel", "ReadMedicalReport"];
    public static int HttpCallRetryCount => 3;
    public static IReadOnlyList<string> DateFormats 
        => ["dd MMM yyyy", "d MMM yyyy", "dd MMMM yyyy", 
            "d MMMM yyyy", "yyyy-MM-dd", "dd/MM/yyyy", 
            "dd-MM-yyyy", "d/M/yyyy", "d-M-yyyy"];
    public static IReadOnlyList<string> DateTimeFormats
        => ["dd/MM/yyyy HH:mm:ss", "dd/MM/yyyy HH:mm", "dd-MM-yyyy HH:mm:ss", 
            "dd-MM-yyyy HH:mm", "yyyy-MM-dd HH:mm:ss", "yyyy-MM-dd HH:mm",
            "yyyy-MM-dd", "dd MMM yyyy HH:mm:ss", "dd MMM yyyy HH:mm", 
            "dd MMMM yyyy HH:mm:ss", "dd MMMM yyyy HH:mm",
            "yyyy-MM-ddTHH:mm:ss", "yyyy-MM-ddTHH:mm", "yyyy-MM-ddTHH:mm:ssZ",
            "yyyy-MM-ddTHH:mmZ", "yyyy-MM-ddTHH:mm:sszzz", "yyyy-MM-ddTHH:mmzzz",
            "yyyy-MM-ddTHH:mm:sszzzz", "yyyy-MM-ddTHH:mmzzzz",
            "yyyy-MM-ddTHH:mm:ss.fffZ"];
}
