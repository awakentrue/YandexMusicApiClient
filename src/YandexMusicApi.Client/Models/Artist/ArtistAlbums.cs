namespace YandexMusicApi.Client;

public class ArtistAlbums
{
    public IReadOnlyCollection<Album> Albums { get; set; } = new List<Album>();

    public Pager Pager { get; set; } = null!;
}