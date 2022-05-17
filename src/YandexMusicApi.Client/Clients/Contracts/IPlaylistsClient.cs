namespace YandexMusicApi.Client;

public interface IPlaylistsClient
{
    Task<Playlist> GetAsync(PlaylistId playlistId, CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<Playlist>> GetAsync(IEnumerable<PlaylistId> playlistIds, CancellationToken cancellationToken = default);
    
    Task SetLikeAsync(string userId, IEnumerable<PlaylistId> playlistIds, bool like = true, CancellationToken cancellationToken = default);

    Task SetDislikeAsync(string userId, IEnumerable<PlaylistId> playlistIds, bool dislike = true, CancellationToken cancellationToken = default);

    Task<Paging<Playlist>> SearchAsync(string text, bool textCorrection = true, int pageIndex = 0, CancellationToken cancellationToken = default);
}