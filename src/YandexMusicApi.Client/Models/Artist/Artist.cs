namespace YandexMusicApi.Client;

public class Artist
{
    public string Id { get; set; } = null!;
    
    public string Name { get; set; } = null!;

    public bool Various { get; set; }
    
    public bool Composer { get; set; }

    public List<string> Genres { get; set; } = new List<string>();
    
    public bool Available { get; set; }
    
    public ArtistCounts Counts { get; set; } = null!;

    public AristRatings Ratings { get; set; } = null!;
    
    public bool TicketsAvailable { get; set; }
}