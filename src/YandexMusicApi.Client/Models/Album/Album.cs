using Newtonsoft.Json;

namespace YandexMusicApi.Client;

public class Album
{
    public string Id { get; set; } = null!;
    
    public string Title { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string MetaType { get; set; } = null!;

    public int? Year { get; set; }
    
    public DateTime? ReleaseDate { get; set; }
    
    public string Genre { get; set; } = null!;

    public int? TrackCount { get; set; }
    
    public int? LikesCount { get; set; }
    
    public bool? Recent { get; set; }
    
    public bool? VeryImportant { get; set; }

    [JsonConverter(typeof(LabelJsonConverter))]
    public IReadOnlyCollection<Label> Labels { get; set; } = new List<Label>();
    
    public bool? Available { get; set; }
    
    public bool? AvailableForPremiumUsers { get; set; }
    
    public bool? AvailableForMobile { get; set; }
    
    public bool? AvailablePartially { get; set; }
    
    public string StorageDir { get; set; } = null!;

    public int? OriginalReleaseYear { get; set; }

    public IReadOnlyCollection<Artist> Artists { get; set; } = new List<Artist>();

    public IReadOnlyCollection<string> AvailableRegions { get; set; } = new List<string>();
    
    public string Version { get; set; } = null!;
}