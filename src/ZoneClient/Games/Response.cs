using System.Text.Json.Serialization;

namespace ZoneChan.ZoneClient.Games;

public sealed class Response
{
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("msg")]
    public Message? Message { get; set; }
}