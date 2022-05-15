namespace YandexMusicApi.Client;

public interface IPlaylistsClient
{
    Task<Playlist> GetAsync(PlaylistQuery playlistQuery, CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<Playlist>> GetAsync(IEnumerable<PlaylistQuery> playlistsQueries, CancellationToken cancellationToken = default);
    
    Task SetLikeAsync(string userId, IEnumerable<PlaylistQuery> playlistsQueries, bool like = true, CancellationToken cancellationToken = default);

    Task SetDislikeAsync(string userId, IEnumerable<PlaylistQuery> playlistsQueries, bool dislike = true, CancellationToken cancellationToken = default);

    Task<Paging<Playlist>> SearchAsync(string text, bool textCorrection, int pageIndex = 0, CancellationToken cancellationToken = default);
}