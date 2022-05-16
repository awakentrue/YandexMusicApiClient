using Newtonsoft.Json;

namespace YandexMusicApi.Client;

public class TrackSupplement
{
    public string Id { get; set; } = null!;
    
    public string Description { get; set; } = null!;
    
    public Lyrics Lyrics { get; set; } = null!;
    
    public Videos Videos { get; set; } = null!;

    [JsonProperty("radio_is_available")]
    public bool RadioIsAvailable { get; set; }
}