
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
        public static (DateTime startDate, DateTime endDate) GetMonthStartEndDates(int year, int month, int day = 1)
    {
        var startDate = new DateTime(year: year, month: month, day: day);
        var endDate = startDate.AddMonths(months: 1).AddDays(value: -1);
        return (startDate, endDate);
    }
    public static string GetClientAddress(HttpContext context)
    {
        var forwardedHeader = context.Request.Headers[CommonConstants.XForwardedFor].FirstOrDefault();
        return string.IsNullOrEmpty(value: forwardedHeader) 
                ? context.Connection.RemoteIpAddress?.ToString() ?? Environment.MachineName
                : forwardedHeader.Split(separator: ',').First().Trim();
    }
    public static (uint records, int page, int pageSize) GetDataQueryParameters(HttpContext context)
    {
        var recordsValue = context.Request.Query["records"].FirstOrDefault();
        var pageValue = context.Request.Query["page"].FirstOrDefault();
        var pageSizeValue = context.Request.Query["pageSize"].FirstOrDefault();

        if (!uint.TryParse(recordsValue, out uint records)) records = 1000;
        if (!int.TryParse(pageValue, out int page) || page <= 0) page = 1;
        if (!int.TryParse(pageSizeValue, out int pageSize) || pageSize <= 0) pageSize = 10;

        return (records, page, pageSize);
    }
}
