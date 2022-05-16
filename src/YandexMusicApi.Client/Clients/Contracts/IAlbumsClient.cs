namespace YandexMusicApi.Client;

public interface IAlbumsClient
{
    Task<Album> GetAsync(string albumId, CancellationToken cancellationToken = default);
    
    Task<IReadOnlyCollection<Album>> GetAsync(IEnumerable<string> albumsIds, CancellationToken cancellationToken = default);
    
    Task<AlbumWithTracks> GetWithTracksAsync(string albumId, CancellationToken cancellationToken = default);
    
    Task SetLikeAsync(string userId, IEnumerable<string> albumsIds, bool like = true, CancellationToken cancellationToken = default);

    Task SetDislikeAsync(string userId, IEnumerable<string> albumsIds, bool dislike = true, CancellationToken cancellationToken = default);

    Task<Paging<Album>> SearchAsync(string text, bool textCorrection, int pageIndex = 0, CancellationToken cancellationToken = default);
}