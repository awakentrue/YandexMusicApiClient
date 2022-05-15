namespace YandexMusicApi.Client;

public interface IArtistsClient
{
    Task<Artist> GetAsync(string artistId, CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<Artist>> GetAsync(IEnumerable<string> artistsIds, CancellationToken cancellationToken = default);
    
    Task<Paging<Track>> GetTracksAsync(string artistId, int pageIndex = 0, int pageSize = 20, CancellationToken cancellationToken = default);

    Task<Paging<Album>> GetAlbumsAsync(string artistId, int pageIndex = 0, int pageSize = 20, SortType sortType = SortType.Year, CancellationToken cancellationToken = default);

    Task<ArtistBriefInfo> GetBriefInfoAsync(string artistId, CancellationToken cancellationToken = default);
    
    Task SetLikeAsync(string userId, IEnumerable<string> artistsIds, bool like = true, CancellationToken cancellationToken = default);

    Task SetDislikeAsync(string userId, IEnumerable<string> artistsIds, bool dislike = true, CancellationToken cancellationToken = default);

    Task<Paging<Artist>> SearchAsync(string text, bool textCorrection, int pageIndex = 0, CancellationToken cancellationToken = default);
}