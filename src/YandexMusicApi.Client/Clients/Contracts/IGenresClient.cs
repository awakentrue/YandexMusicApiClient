namespace YandexMusicApi.Client;

public interface IGenresClient
{
    Task<IReadOnlyCollection<Genre>> GetAsync(CancellationToken cancellationToken = default);
}