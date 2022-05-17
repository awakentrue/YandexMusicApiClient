using Newtonsoft.Json;

namespace YandexMusicApi.Client;

public class Lyrics
{
    public string Id { get; set; } = null!;

    [JsonProperty("lyrics")]
    public string ShortLyrics { get; set; } = null!;
    
    public string FullLyrics { get; set; } = null!;
    
    public bool HasRights { get; set; }
    
    public bool ShowTranslation { get; set; }
    
    public string TextLanguage { get; set; } = null!;
}