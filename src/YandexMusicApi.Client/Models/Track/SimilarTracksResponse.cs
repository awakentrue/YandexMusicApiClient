namespace YandexMusicApi.Client;

public class SimilarTracksResponse
{
    public IReadOnlyCollection<Track> SimilarTracks { get; set; } = null!;
}