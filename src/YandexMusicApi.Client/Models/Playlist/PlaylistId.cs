using Newtonsoft.Json;

namespace YandexMusicApi.Client;

public class PlaylistId
{
    internal PlaylistId()
    {
    }
    
    public PlaylistId(string ownerId, string kind)
    {
        OwnerId = ownerId;
        Kind = kind;
    }
    
    [JsonProperty("uid")]
    public string OwnerId { get; } = null!;

    public string Kind { get; } = null!;

    public override string ToString()
    {
        return $"{OwnerId}:{Kind}";
    }
}