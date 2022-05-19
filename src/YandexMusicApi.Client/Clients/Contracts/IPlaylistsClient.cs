using YandexMusicApi.Client.Exceptions;

namespace YandexMusicApi.Client;

/// <summary>
/// Client for retrieving information about one or more playlists.
/// </summary>
public interface IPlaylistsClient
{
    /// <summary>
    /// Get playlist information.
    /// </summary>
    /// <param name="playlistId">The Yandex.Music ID of the playlist. The playlist ID is a union of the playlist owner ID and playlist kind.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <exception cref="YandexMusicClientException">Thrown if request to Yandex.Music API does not indicate success.</exception>
    Task<Playlist> GetAsync(PlaylistId playlistId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get several playlists information.
    /// </summary>
    /// <param name="playlistIds">The Yandex.Music IDs of the playlists. The playlist ID is a union of the playlist owner ID and playlist kind.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <exception cref="YandexMusicClientException">Thrown if request to Yandex.Music API does not indicate success.</exception>
    Task<IReadOnlyCollection<Playlist>> GetAsync(IEnumerable<PlaylistId> playlistIds, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get several user playlists information. 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="YandexMusicClientException">Thrown if request to Yandex.Music API does not indicate success.</exception>
    Task<IReadOnlyCollection<Playlist>> GetUserPlaylistAsync(string userId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add or remove the playlist to favorites.
    /// </summary>
    /// <param name="userId">The Yandex.Music ID of the user.</param>
    /// <param name="playlistIds">The Yandex.Music IDs of the playlists. The playlist ID is a union of the playlist owner ID and playlist kind.</param>
    /// <param name="like">The action, if <b>true</b>, adds the playlist to favorites, if <b>false</b>, removes it from favorites.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <exception cref="YandexMusicClientException">Thrown if request to Yandex.Music API does not indicate success.</exception>
    Task SetLikeAsync(string userId, IEnumerable<PlaylistId> playlistIds, bool like = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add or remove the playlist to dislikes.
    /// </summary>
    /// <param name="userId">The Yandex.Music ID of the user.</param>
    /// <param name="playlistIds">The Yandex.Music IDs of the playlists. The playlist ID is a union of the playlist owner ID and playlist kind.</param>
    /// <param name="dislike">The action, if <b>true</b>, adds the playlist to disliked, if <b>false</b>, removes it from disliked.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <exception cref="YandexMusicClientException">Thrown if request to Yandex.Music API does not indicate success.</exception>
    Task SetDislikeAsync(string userId, IEnumerable<PlaylistId> playlistIds, bool dislike = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Search for playlists by title.
    /// </summary>
    /// <param name="text">The text of the search query.</param>
    /// <param name="textCorrection">The text correction before searching, if <b>true</b>, auto spell checks the input text before searching, if <b>false</b>, searches with the exact input text.</param>
    /// <param name="pageIndex">The page index of search result.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <exception cref="YandexMusicClientException">Thrown if request to Yandex.Music API does not indicate success.</exception>
    Task<Paging<Playlist>> SearchAsync(string text, bool textCorrection = true, int pageIndex = 0, CancellationToken cancellationToken = default);
}