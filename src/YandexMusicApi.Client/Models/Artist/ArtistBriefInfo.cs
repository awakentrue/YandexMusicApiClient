namespace YandexMusicApi.Client;

public class ArtistBriefInfo
{
    public Artist Artist { get; set; } = null!;

    public List<Album> Albums { get; set; } = new List<Album>();
    
    //todo: add another fields
}