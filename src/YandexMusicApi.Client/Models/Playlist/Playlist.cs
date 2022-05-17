using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace YandexMusicApi.Client;

public class Playlist
{
    public Owner Owner { get; set; } = null!;

    public string PlaylistUuid { get; set; } = null!;

    public bool Available { get; set; }
    
    public string Uid { get; set; } = null!;

    public string Kind { get; set; } = null!;

    public string Title { get; set; } = null!;

    public int? Revision { get; set; }
    
    public int? Snapshot { get; set; }
    
    public int TrackCount { get; set; }
    
    [JsonConverter(typeof(StringEnumConverter))]
    public Visibility Visibility { get; set; }

    public bool Collective { get; set; }
    
    public DateTime Created { get; set; }
    
    public DateTime Modified { get; set; }
    
    public bool IsBanner { get; set; }
    
    public bool IsPremiere { get; set; }
    
    public int? DurationMs { get; set; }
    
    public int? LikesCount { get; set; }
}