namespace YandexMusicApi.Client;

public class ArtistAlbums
{
    public List<Album> Albums { get; set; } = new List<Album>();

    public Pager Pager { get; set; } = null!;
}