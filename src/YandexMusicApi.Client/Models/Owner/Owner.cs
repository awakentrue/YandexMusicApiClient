using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace YandexMusicApi.Client;

public class Owner
{
    public string Uid { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Name { get; set; } = null!;

    [JsonConverter(typeof(StringEnumConverter))]
    public Sex Sex { get; set; }
        
    public bool Verified { get; set; }
}