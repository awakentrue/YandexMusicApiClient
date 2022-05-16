using Newtonsoft.Json;

namespace YandexMusicApi.Client;

public class Videos
{
    public string Cover { get; set; } = null!;

    public string Provider { get; set; } = null!;

    public string Title { get; set; } = null!;

    [JsonProperty("provider_video_id")]
    public string ProviderVideoId { get; set; } = null!;
    
    public string Url { get; set; } = null!;
    
    public string EmbedUrl { get; set; } = null!;
}