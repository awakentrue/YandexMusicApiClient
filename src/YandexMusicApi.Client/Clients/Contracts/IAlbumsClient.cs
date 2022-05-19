using YandexMusicApi.Client.Exceptions;

namespace YandexMusicApi.Client;

/// <summary>
/// Client for retrieving information about one or more albums.
/// </summary>
public interface IAlbumsClient
{
    /// <summary>
    /// Get album information.
    /// </summary>
    /// <param name="albumId">The Yandex.Music ID of the album.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <exception cref="YandexMusicClientException">Thrown if request to Yandex.Music API does not indicate success.</exception>
    Task<Album> GetAsync(string albumId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Get several album information.
    /// </summary>
    /// <param name="albumsIds">The Yandex.Music IDs of the albums.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <exception cref="YandexMusicClientException">Thrown if request to Yandex.Music API does not indicate success.</exception>
    Task<IReadOnlyCollection<Album>> GetAsync(IEnumerable<string> albumsIds, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Get album information with tracks.
    /// </summary>
    /// <param name="albumId">The Yandex.Music ID of the album.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <exception cref="YandexMusicClientException">Thrown if request to Yandex.Music API does not indicate success.</exception>
    Task<AlbumWithTracks> GetWithTracksAsync(string albumId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Add or remove the album to favorites.
    /// </summary>
    /// <param name="userId">The Yandex.Music ID of the user.</param>
    /// <param name="albumsIds">The Yandex.Music IDs of the albums.</param>
    /// <param name="like">The action, if <b>true</b>, adds the album to favorites, if <b>false</b>, removes it from favorites.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <exception cref="YandexMusicClientException">Thrown if request to Yandex.Music API does not indicate success.</exception>
    Task SetLikeAsync(string userId, IEnumerable<string> albumsIds, bool like = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add or remove the album to dislikes.
    /// </summary>
    /// <param name="userId">The Yandex.Music ID of the user.</param>
    /// <param name="albumsIds">The Yandex.Music IDs of the albums.</param>
    /// <param name="dislike">The action, if <b>true</b>, adds the album to disliked, if <b>false</b>, removes it from disliked.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <exception cref="YandexMusicClientException">Thrown if request to Yandex.Music API does not indicate success.</exception>
    Task SetDislikeAsync(string userId, IEnumerable<string> albumsIds, bool dislike = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Search for albums by title.
    /// </summary>
    /// <param name="text">The text of the search query.</param>
    /// <param name="textCorrection">The text correction before searching, if <b>true</b>, auto spell checks the input text before searching, if <b>false</b>, searches with the exact input text.</param>
    /// <param name="pageIndex">The page index of search result.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <exception cref="YandexMusicClientException">Thrown if request to Yandex.Music API does not indicate success.</exception>
    Task<Paging<Album>> SearchAsync(string text, bool textCorrection = true, int pageIndex = 0, CancellationToken cancellationToken = default);
}