using YandexMusicApi.Client.Exceptions;

namespace YandexMusicApi.Client;

/// <summary>
/// Client for retrieving information about genres.
/// </summary>
public interface IGenresClient
{
    /// <summary>
    /// Get all genres.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <exception cref="YandexMusicClientException">Thrown if request to Yandex.Music API does not indicate success.</exception>
    Task<IReadOnlyCollection<Genre>> GetAsync(CancellationToken cancellationToken = default);
}