
using System.Text.Json;

namespace ClinicMasterFirstContact.src.App.Common.Utils;
public static class CommonUtils 
{
    private readonly static JsonSerializerOptions options = new (defaults: JsonSerializerDefaults.Web);
    public static string SerializeContent<T>(T content) 
        => JsonSerializer.Serialize(value: content, options: options);    
    public static T? DeserializeContent<T>(ReadOnlySpan<char> content) 
        => JsonSerializer.Deserialize<T>(json: content, options: options);   
    public static bool BeAValidDate(string value) => DateTime.TryParse(s: value, result: out _);
    public static DateTime ConvertStringToDateTime(string value)
    {
        var result = DateTime.TryParse(s: value, result: out DateTime date);
        return result ? date : DateTime.MinValue;
    }
    public static DateTime GetCurrentDateTime(TimeProvider timeProvider) => timeProvider.GetLocalNow().DateTime;
    
    public static string GetClientAddress(HttpContext context)
    {
        var forwardedHeader = context.Request.Headers[CommonConstants.XForwardedFor].FirstOrDefault();
        return string.IsNullOrEmpty(value: forwardedHeader) 
                ? context.Connection.RemoteIpAddress?.ToString() ?? Environment.MachineName
                : forwardedHeader.Split(separator: ',').First().Trim();
    }
}
