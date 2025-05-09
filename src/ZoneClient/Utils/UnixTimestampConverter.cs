using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZoneChan.ZoneClient.Utils;

public class UnixTimestampConverter : JsonConverter<DateTimeOffset>
{
    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var seconds = reader.GetInt64();
        return DateTimeOffset.FromUnixTimeSeconds(seconds);
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
        long unixTimer = value.ToUnixTimeSeconds();
        writer.WriteNumberValue(unixTimer);
    }
}