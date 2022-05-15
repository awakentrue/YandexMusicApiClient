namespace YandexMusicApi.Client;

public class Album
{
    public string Id { get; set; } = null!;
    
    public string Title { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string MetaType { get; set; } = null!;

    public int Year { get; set; }
    
    public DateTime ReleaseDate { get; set; }
    
    public string Genre { get; set; } = null!;

    public int TrackCount { get; set; }
    
    public int LikesCount { get; set; }
    
    public bool Recent { get; set; }
    
    public bool VeryImportant { get; set; }

    public List<Label> Labels { get; set; } = new List<Label>();
    
    public bool Available { get; set; }
    
    public bool AvailableForPremiumUsers { get; set; }
    
    public bool AvailableForMobile { get; set; }
    
    public bool AvailablePartially { get; set; }
}