using Newtonsoft.Json;

namespace YandexMusicApi.Client;

public class GenreTitles
{
    [JsonProperty("be")]
    public GenreTitle Belorussian { get; set; } = null!;
    
    [JsonProperty("ka")]
    public GenreTitle Georgian { get; set; } = null!;
    
    [JsonProperty("en")]
    public GenreTitle English { get; set; } = null!;
    
    [JsonProperty("uk")]
    public GenreTitle Ukraine { get; set; } = null!;
    
    [JsonProperty("tr")]
    public GenreTitle Turkish { get; set; } = null!;
    
    [JsonProperty("ru")]
    public GenreTitle Russian { get; set; } = null!;

    [JsonProperty("kk")]
    public GenreTitle Kazakh { get; set; } = null!;
    
    [JsonProperty("ro")]
    public GenreTitle Romanian { get; set; } = null!;
    
    [JsonProperty("he")]
    public GenreTitle Hebrew { get; set; } = null!;
    
    [JsonProperty("az")]
    public GenreTitle Azerbaijani { get; set; } = null!;
    
    [JsonProperty("uz")]
    public GenreTitle Uzbek { get; set; } = null!;
}