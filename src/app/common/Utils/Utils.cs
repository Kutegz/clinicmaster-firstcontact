using System.Text.Json;

namespace App.Common.Utils;
public static class Utils 
{
    private readonly static JsonSerializerOptions options = new (JsonSerializerDefaults.Web);
    public static string SerializeContent<T>(T content) 
    => JsonSerializer.Serialize(value: content, options: options);    
    public static T? DeserializeContent<T>(ReadOnlySpan<char> content) 
    => JsonSerializer.Deserialize<T>(json: content, options: options);   
    public static bool BeAValidDate(string value) => DateTime.TryParse(value, out _);
    public static DateTime ConvertStringToDateTime(string value)
    {
        var result = DateTime.TryParse(value, out DateTime date);
        if (!result) return DateTime.Parse(Constants.NullDateTimeString);
        return date;
    }
}