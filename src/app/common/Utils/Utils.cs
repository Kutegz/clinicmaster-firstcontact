using System.Text.Json;

namespace App.Common.Utils;
public static class Utils 
{
    private readonly static JsonSerializerOptions options = new (JsonSerializerDefaults.Web);
    public static string SerializeContent<T>(T content) 
    => JsonSerializer.Serialize(value: content, options: options);    
    public static T? DeserializeContent<T>(ReadOnlySpan<char> content) 
    => JsonSerializer.Deserialize<T>(json: content, options: options);   
    public static bool BeAValidDate(string value) => DateTimeOffset.TryParse(value, out _);
    public static DateTimeOffset ConvertStringToDateTime(string value)
    {
        var result = DateTimeOffset.TryParse(value, out DateTimeOffset date);
        if (!result) return DateTimeOffset.Parse(Constants.NullDateTimeString);
        return date;
    }
}