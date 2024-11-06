
using System.Text.Json;
using System.Globalization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace ClinicMasterFirstContact.src.App.Common.Utils;
public static class CommonUtils 
{
    private readonly static JsonSerializerOptions options = new (defaults: JsonSerializerDefaults.Web);
    public static string SerializeContent<T>(T content) 
        => JsonSerializer.Serialize(value: content, options: options);    
    public static T? DeserializeContent<T>(ReadOnlySpan<char> content) 
        => JsonSerializer.Deserialize<T>(json: content, options: options);   
    public static DateTime ConvertStringToDateTime(string value)
    {
        var result = DateTime.TryParse(s: value, result: out DateTime date);
        return result ? date : DateTime.MinValue;
    }
    public static DateTime GetCurrentDate(TimeProvider timeProvider) => timeProvider.GetLocalNow().Date;
    public static DateTime GetCurrentDateTime(TimeProvider timeProvider) => timeProvider.GetLocalNow().DateTime;
    public static bool BeTodayOrFutureDate(DateTime date)=> date.Date >= DateTime.Now.Date;
    public static bool BeTodayOrPastDate(DateTime date)=> date.Date <= DateTime.Now.Date;
    public static bool BeValidDate(DateTime date) => date.Date != DateTime.MinValue.Date;
    public static bool BeValidDateTime(DateTime date) => date != DateTime.MinValue;
        public static (DateTime startDate, DateTime endDate) GetMonthStartEndDates(int year, int month, int day = 1)
    {
        var startDate = new DateTime(year: year, month: month, day: day);
        var endDate = startDate.AddMonths(months: 1).AddDays(value: -1);
        return (startDate, endDate);
    }
    public static int GetQuarterBeginMonth(string quarter)
        => quarter.ToUpper() switch { "Q1" => 1, "Q2" => 4, "Q3" => 7, "Q4" => 10, _ => 0 };
    public static int GetQuarterEndMonth(string quarter)
        => quarter.ToUpper() switch { "Q1" => 3, "Q2" => 6, "Q3" => 9, "Q4" => 12, _ => 0 };
    public static (DateTime startDate, DateTime endDate) GetQuarterStartEndDates(string quarter, int year)
        => quarter.ToUpper() switch
            {
                "Q1" => (new DateTime(year: year, month: 1, day: 1), new DateTime(year: year, month: 3, day: 31)),
                "Q2" => (new DateTime(year: year, month: 4, day: 1), new DateTime(year: year, month: 6, day: 30)),
                "Q3" => (new DateTime(year: year, month: 7, day: 1), new DateTime(year: year, month: 9, day: 30)),
                "Q4" => (new DateTime(year: year, month: 10, day: 1), new DateTime(year: year, month: 12, day: 31)),
                _ => (DateTime.MinValue, DateTime.MinValue)
            };
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

        if (!uint.TryParse(s: recordsValue, result: out uint records)) records = 1000;
        if (!int.TryParse(s: pageValue, result: out int page) || page <= 0) page = 1;
        if (!int.TryParse(s: pageSizeValue, result: out int pageSize) || pageSize <= 0) pageSize = 10;

        return (records, page, pageSize);
    }
    public static (DateTime startDate, DateTime endDate) GetDateRangeQueryParameters(HttpContext context, DateTime now, 
                                                                                    IReadOnlyList<string> dateFormats)
    {
        var startDateValue = context.Request.Query["startDate"].FirstOrDefault();
        var endDateValue = context.Request.Query["endDate"].FirstOrDefault();

        if (!DateTime.TryParseExact(s: startDateValue, formats: [.. dateFormats], 
            provider: CultureInfo.InvariantCulture, 
            style: DateTimeStyles.None, result: out DateTime startDate) ||
            startDate <= DateTime.MinValue || startDate > now)
        { startDate = DateTime.MinValue; }

        if (!DateTime.TryParseExact(s: endDateValue, formats: [.. dateFormats], 
            provider: CultureInfo.InvariantCulture, 
            style: DateTimeStyles.None, result: out DateTime endDate) ||
            endDate <= DateTime.MinValue || endDate > now)
        { endDate = DateTime.MinValue; }

        if (startDate == DateTime.MinValue) endDate = DateTime.MinValue;

        return (startDate, endDate);
    }

    public static (DateTime startDateTime, DateTime endDateTime) GetDateTimeRangeQueryParameters(HttpContext context, DateTime now, 
                                                                                    IReadOnlyList<string> dateTimeFormats)
    {
        var startDateTimeValue = context.Request.Query["startDateTime"].FirstOrDefault();
        var endDateTimeValue = context.Request.Query["endDateTime"].FirstOrDefault();

        if (!DateTime.TryParseExact(s: startDateTimeValue, formats: [.. dateTimeFormats], 
            provider: CultureInfo.InvariantCulture, 
            style: DateTimeStyles.None, result: out DateTime startDateTime) ||
            startDateTime <= DateTime.MinValue || startDateTime > now)
        { startDateTime = DateTime.MinValue; }

        if (!DateTime.TryParseExact(s: endDateTimeValue, formats: [.. dateTimeFormats], 
            provider: CultureInfo.InvariantCulture, 
            style: DateTimeStyles.None, result: out DateTime endDateTime) ||
            endDateTime <= DateTime.MinValue || endDateTime > now)
        { endDateTime = DateTime.MinValue; }

        if (startDateTime == DateTime.MinValue) endDateTime = DateTime.MinValue;

        return (startDateTime, endDateTime);
    }
    public static (string userName, string fullName) GetLoginCredentials(HttpContext context)
    {

        string userName = context.User.FindFirstValue(claimType: ClaimTypes.NameIdentifier) ?? 
                          context.User.FindFirstValue(claimType: JwtRegisteredClaimNames.Sub) ?? 
                          string.Empty;
                          
        string fullName = context.User.FindFirstValue(claimType: ClaimTypes.Name) ??
                            context.User.FindFirstValue(claimType: JwtRegisteredClaimNames.GivenName) ?? 
                            string.Empty;

        return (userName, fullName);
    }
}
