namespace YandexMusicApi.Client;

public class Artist
{
    public string Id { get; set; } = null!;
    
    public string Name { get; set; } = null!;

    public bool Various { get; set; }
    
    public bool Composer { get; set; }

    public IReadOnlyCollection<string> Genres { get; set; } = new List<string>();
    
    public bool Available { get; set; }
    
    public ArtistCounts Counts { get; set; } = null!;

    public AristRatings Ratings { get; set; } = null!;

    public IReadOnlyCollection<SocialNetworkLink> Links { get; set; } = new List<SocialNetworkLink>();
    
    public bool TicketsAvailable { get; set; }
}