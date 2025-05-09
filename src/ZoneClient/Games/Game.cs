using System.Text.Json.Serialization;
using ZoneChan.ZoneClient.Utils;

namespace ZoneChan.ZoneClient.Games;

public sealed class Game
{
    [JsonPropertyName("thread_id")]
    public int? Id { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }
    
    [JsonPropertyName("creator")]
    public string? Creator { get; set; }
    
    [JsonPropertyName("version")]
    [JsonConverter(typeof(FlexibleStringConverter))]
    public string? Version { get; set; }
    
    [JsonPropertyName("views")]
    public int? Views { get; set; }
    
    [JsonPropertyName("likes")]
    public int? Likes { get; set; }

    [JsonPropertyName("prefixes")]
    public IList<Prefix> Prefixes { get; set; } = [];
    
    [JsonPropertyName("tags")]
    public IList<Tag> Tags { get; set; } = [];

    [JsonPropertyName("rating")]
    public decimal Rating { get; set; }

    [JsonPropertyName("cover")]
    public Uri? Cover { get; set; }

    [JsonPropertyName("screens")]
    public IList<Uri> Screens { get; set; } = [];

    [JsonPropertyName("date")]
    public string? RelativeUpdated { get; set; }

    [JsonPropertyName("watched")]
    public bool? IsWatched { get; set; }
    
    [JsonPropertyName("ignored")]
    public bool? IsIgnored { get; set; }
    
    [JsonPropertyName("new")]
    public bool? IsNew { get; set; }

    [JsonPropertyName("ts")]
    [JsonConverter(typeof(UnixTimestampConverter))]
    public DateTimeOffset UpdatedAt { get; set; }
}