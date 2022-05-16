namespace YandexMusicApi.Client;

public class AlbumWithTracks : Album
{
    public IReadOnlyCollection<IReadOnlyCollection<Track>> Volumes { get; set; } = new List<List<Track>>();

    public IReadOnlyCollection<Track> Tracks => Volumes.SelectMany(x => x).ToList();
}