namespace ZoneChan.ZoneClient;

public sealed class ZoneOptions
{
    public const string SectionName = "ZoneClient";
    
    public string? BaseUri { get; set; }

    public Uri ParsedBaseUri => BaseUri is null ? throw new ArgumentNullException() : new Uri(BaseUri);
}