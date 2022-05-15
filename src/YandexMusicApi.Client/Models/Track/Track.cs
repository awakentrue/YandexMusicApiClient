namespace YandexMusicApi.Client;

public class Track
{
    public string Id { get; set; } = null!;

    public string RealId { get; set; } = null!;

    public string Title { get; set; } = null!;

    public bool Available { get; set; }

    public bool AvailableForPremiumUsers { get; set; }
    
    public bool AvailableFullWithoutPermission { get; set; }

    public bool LyricsAvailable { get; set; }

    public bool RememberPosition { get; set; }

    public string TrackSharingFlag { get; set; } = null!;

    public string CoverUri { get; set; } = null!;

    public string Type { get; set; } = null!;

    public int DurationMs { get; set; }
    
    public int PreviewDurationMs { get; set; }
    
    public IReadOnlyCollection<Artist> Artists { get; set; } = Array.Empty<Artist>();

    public IReadOnlyCollection<string> Regions { get; set; } = Array.Empty<string>();
    
    public IReadOnlyCollection<Album> Albums { get; set; } = Array.Empty<Album>();
}