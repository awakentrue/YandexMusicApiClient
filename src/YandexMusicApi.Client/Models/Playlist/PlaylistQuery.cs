namespace YandexMusicApi.Client;

public class PlaylistQuery
{
    public PlaylistQuery(string ownerId, string kind)
    {
        OwnerId = ownerId;
        Kind = kind;
    }
    
    public string OwnerId { get; }

    public string Kind { get; }

    public override string ToString()
    {
        return $"{OwnerId}.{Kind}";
    }
}