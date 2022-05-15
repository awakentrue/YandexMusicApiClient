namespace YandexMusicApi.Client;

public class ArtistTracks
{
    public List<Track> Tracks { get; set; } = new List<Track>();

    public Pager Pager { get; set; } = null!;
}