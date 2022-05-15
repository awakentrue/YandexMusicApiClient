namespace YandexMusicApi.Client.Http;

public interface IRestClient : IDisposable
{
    Task<TResponse> GetAsync<TResponse>(Uri uri, CancellationToken cancellationToken = default);

    Task<TResponse> PostAsync<TResponse>(Uri uri, HttpBody? body = default, CancellationToken cancellationToken = default);
    
    Task<Stream> GetStreamAsync(Uri uri, CancellationToken cancellationToken = default);
}