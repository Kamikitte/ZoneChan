using System.Text.Json.Serialization;

namespace ZoneChan.ZoneClient.Games;

public sealed class Pagination
{
    [JsonPropertyName("page")]
    public int Page { get; set; }

    [JsonPropertyName("total")]
    public int Total { get; set; }
}