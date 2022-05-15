namespace YandexMusicApi.Client;

public interface ITracksClient
{
    Task<Track> GetAsync(string trackId, CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<Track>> GetAsync(IEnumerable<string> tracksIds, CancellationToken cancellationToken = default);
    
    Task<IReadOnlyCollection<Track>> GetSimilarAsync(string trackId, CancellationToken cancellationToken = default);

    Task<TrackSupplement> GetTrackSupplementAsync(string trackId, CancellationToken cancellationToken = default);

    Task SetLikeAsync(string userId, IEnumerable<string> tracksIds, bool like = true, CancellationToken cancellationToken = default);

    Task SetDislikeAsync(string userId, IEnumerable<string> tracksIds, bool dislike = true, CancellationToken cancellationToken = default);

    Task<Paging<Track>> SearchAsync(string text, bool textCorrection, int pageIndex = 0, CancellationToken cancellationToken = default);
    
    Task<Stream> DownloadAsync(string trackId, string albumId, CancellationToken cancellationToken = default);
}