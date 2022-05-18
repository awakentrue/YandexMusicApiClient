using YandexMusicApi.Client.Exceptions;

namespace YandexMusicApi.Client;

/// <summary>
/// A client for the Yandex.Music API.
/// </summary>S
public interface IYandexMusicClient
{
    /// <summary>
    /// Client for retrieving information about one or more tracks.
    /// </summary>
    ITracksClient Tracks { get; }
    
    /// <summary>
    /// Client for retrieving information about one or more albums.
    /// </summary>
    IAlbumsClient Albums { get; }
    
    /// <summary>
    /// Client for retrieving information about one or more artists.
    /// </summary>
    IArtistsClient Artists { get; }
    
    /// <summary>
    /// Client for retrieving information about one or more playlists.
    /// </summary>
    IPlaylistsClient Playlists { get; }
    
    /// <summary>
    /// Client for retrieving information about account.
    /// </summary>
    IAccountClient Account { get; }
    
    /// <summary>
    /// Client for retrieving information about genres.
    /// </summary>
    IGenresClient Genres { get; }

    /// <summary>
    /// Search for tracks/albums/artists/playlists by name or title.
    /// </summary>
    /// <param name="text">The text of the search query.</param>
    /// <param name="textCorrection">The text correction before searching, if <b>true</b>, auto spell checks the input text before searching, if <b>false</b>, searches with the exact input text.</param>
    /// <param name="pageIndex">The page index of search result.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <exception cref="YandexMusicClientException">Thrown if request to Yandex.Music API does not indicate success.</exception>
    Task<SearchResult> SearchAsync(string text, int pageIndex = 0, bool textCorrection = true, CancellationToken cancellationToken = default);
}