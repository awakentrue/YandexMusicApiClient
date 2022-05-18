using YandexMusicApi.Client.Exceptions;

namespace YandexMusicApi.Client;

/// <summary>
/// Client for retrieving information about one or more tracks.
/// </summary>
public interface ITracksClient
{
    /// <summary>
    /// Get track information.
    /// </summary>
    /// <param name="trackId">The Yandex.Music ID of the track.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <exception cref="YandexMusicClientException">Thrown if request to Yandex.Music API does not indicate success.</exception>
    Task<Track> GetAsync(string trackId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get several tracks information.
    /// </summary>
    /// <param name="tracksIds">The Yandex.Music IDs of the tracks.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <exception cref="YandexMusicClientException">Thrown if request to Yandex.Music API does not indicate success.</exception>
    Task<IReadOnlyCollection<Track>> GetAsync(IEnumerable<string> tracksIds, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Get similar tracks information.
    /// </summary>
    /// <param name="trackId">The Yandex.Music ID of the track.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <exception cref="YandexMusicClientException">Thrown if request to Yandex.Music API does not indicate success.</exception>
    Task<IReadOnlyCollection<Track>> GetSimilarAsync(string trackId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get track supplement information.
    /// </summary>
    /// <param name="trackId">The Yandex.Music ID of the track.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <exception cref="YandexMusicClientException">Thrown if request to Yandex.Music API does not indicate success.</exception>
    Task<TrackSupplement> GetTrackSupplementAsync(string trackId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add or remove the track to favorites.
    /// </summary>
    /// <param name="userId">The Yandex.Music ID of the user.</param>
    /// <param name="tracksIds">The Yandex.Music IDs of the tracks.</param>
    /// <param name="like">The action, if <b>true</b>, adds the track to favorites, if <b>false</b>, removes it from favorites.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <exception cref="YandexMusicClientException">Thrown if request to Yandex.Music API does not indicate success.</exception>
    Task SetLikeAsync(string userId, IEnumerable<string> tracksIds, bool like = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add or remove the track to dislikes.
    /// <b>Disliked tracks are tracks which will no longer be recommended to the user</b>.
    /// </summary>
    /// <param name="userId">The Yandex.Music ID of the user.</param>
    /// <param name="tracksIds">The Yandex.Music IDs of the tracks.</param>
    /// <param name="dislike">The action, if <b>true</b>, adds the track to disliked, if <b>false</b>, removes it from disliked.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <exception cref="YandexMusicClientException">Thrown if request to Yandex.Music API does not indicate success.</exception>
    Task SetDislikeAsync(string userId, IEnumerable<string> tracksIds, bool dislike = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Search for tracks by name.
    /// </summary>
    /// <param name="text">The text of the search query.</param>
    /// <param name="textCorrection">The text correction before searching, if <b>true</b>, auto spell checks the input text before searching, if <b>false</b>, searches with the exact input text.</param>
    /// <param name="pageIndex">The page index of search result.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <exception cref="YandexMusicClientException">Thrown if request to Yandex.Music API does not indicate success.</exception>
    Task<Paging<Track>> SearchAsync(string text, bool textCorrection = true, int pageIndex = 0, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Download track.
    /// </summary>
    /// <param name="trackId">The Yandex.Music ID of the track.</param>
    /// <param name="albumId">The Yandex.Music ID of the album.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <exception cref="YandexMusicClientException">Thrown if request to Yandex.Music API does not indicate success.</exception>
    Task<Stream> DownloadAsync(string trackId, string albumId, CancellationToken cancellationToken = default);
}