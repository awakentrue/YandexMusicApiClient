namespace YandexMusicApi.Client;

public class PlaylistResult
{
    public IReadOnlyCollection<Playlist> Playlists { get; set; } = new List<Playlist>();
}