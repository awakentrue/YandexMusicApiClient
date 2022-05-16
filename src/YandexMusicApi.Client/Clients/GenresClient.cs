using YandexMusicApi.Client.Http;
using GenresEndpoints = YandexMusicApi.Client.YandexMusicEndpoints.GenresEndpoints;

namespace YandexMusicApi.Client;

public sealed class GenresClient : YandexMusicClientBase, IGenresClient
{
    internal GenresClient(IRestClient restClient) : base(restClient) { }

    public async Task<IReadOnlyCollection<Genre>> GetAsync(CancellationToken cancellationToken = default)
    {
        var endpoint = GenresEndpoints.GetGenres;
        var response = await RestClient.GetAsync<Response<List<Genre>>>(endpoint, cancellationToken);

        return response.Result;
    }
}