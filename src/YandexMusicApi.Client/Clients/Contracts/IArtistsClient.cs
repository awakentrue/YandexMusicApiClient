using YandexMusicApi.Client.Exceptions;

namespace YandexMusicApi.Client;

/// <summary>
/// Client for retrieving information about one or more artists.
/// </summary>
public interface IArtistsClient
{
    /// <summary>
    /// Get artist information.
    /// </summary>
    /// <param name="artistId">The Yandex.Music ID of the artist.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <exception cref="YandexMusicClientException">Thrown if request to Yandex.Music API does not indicate success.</exception>
    Task<Artist> GetAsync(string artistId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get several artists information.
    /// </summary>
    /// <param name="artistsIds">The Yandex.Music IDs of the artists.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <exception cref="YandexMusicClientException">Thrown if request to Yandex.Music API does not indicate success.</exception>
    Task<IReadOnlyCollection<Artist>> GetAsync(IEnumerable<string> artistsIds, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Get artist tracks.
    /// </summary>
    /// <param name="artistId">The Yandex.Music ID of the artist.</param>
    /// <param name="pageIndex">The page index of result.</param>
    /// <param name="pageSize">The page size of result.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <exception cref="YandexMusicClientException">Thrown if request to Yandex.Music API does not indicate success.</exception>
    Task<Paging<Track>> GetTracksAsync(string artistId, int pageIndex = 0, int pageSize = 20, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get artist albums.
    /// </summary>
    /// <param name="artistId">The Yandex.Music ID of the artist.</param>
    /// <param name="pageIndex">The page index of result.</param>
    /// <param name="pageSize">The page size of result.</param>
    /// <param name="sortType">The sort type of result.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <exception cref="YandexMusicClientException">Thrown if request to Yandex.Music API does not indicate success.</exception>
    Task<Paging<Album>> GetAlbumsAsync(string artistId, int pageIndex = 0, int pageSize = 20, SortType sortType = SortType.Year, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get artist brief information. />.
    /// </summary>
    /// <param name="artistId">The Yandex.Music ID of the artist.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <exception cref="YandexMusicClientException">Thrown if request to Yandex.Music API does not indicate success.</exception>
    Task<ArtistBriefInfo> GetBriefInfoAsync(string artistId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Add or remove the artist to favorites.
    /// </summary>
    /// <param name="userId">The Yandex.Music ID of the user.</param>
    /// <param name="artistsIds">The Yandex.Music IDs of the artists.</param>
    /// <param name="like">The action, if <b>true</b>, adds the artist to favorites, if <b>false</b>, removes it from favorites.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <exception cref="YandexMusicClientException">Thrown if request to Yandex.Music API does not indicate success.</exception>
    Task SetLikeAsync(string userId, IEnumerable<string> artistsIds, bool like = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add or remove the artist to dislikes.
    /// </summary>
    /// <param name="userId">The Yandex.Music ID of the user.</param>
    /// <param name="artistsIds">The Yandex.Music IDs of the artists.</param>
    /// <param name="dislike">The action, if <b>true</b>, adds the artist to disliked, if <b>false</b>, removes it from disliked.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <exception cref="YandexMusicClientException">Thrown if request to Yandex.Music API does not indicate success.</exception>
    Task SetDislikeAsync(string userId, IEnumerable<string> artistsIds, bool dislike = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Search for artists by name.
    /// </summary>
    /// <param name="text">The text of the search query.</param>
    /// <param name="textCorrection">The text correction before searching, if <b>true</b>, auto spell checks the input text before searching, if <b>false</b>, searches with the exact input text.</param>
    /// <param name="pageIndex">The page index of search result.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <exception cref="YandexMusicClientException">Thrown if request to Yandex.Music API does not indicate success.</exception>
    Task<Paging<Artist>> SearchAsync(string text, bool textCorrection = true, int pageIndex = 0, CancellationToken cancellationToken = default);
}