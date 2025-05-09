using System.Text.Json.Serialization;

namespace ZoneChan.ZoneClient.Games;

public sealed class Message
{
    [JsonPropertyName("data")]
    public IList<Game> Games { get; set; } = [];

    [JsonPropertyName("pagination")]
    public Pagination? Pagination { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }
}