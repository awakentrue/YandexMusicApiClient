using YandexMusicApi.Client.Http;

namespace YandexMusicApi.Client;

internal class SearchService : ISearchService
{
    private readonly IRestClient _restClient;

    public SearchService(IRestClient restClient)
    {
        _restClient = restClient ?? throw new ArgumentNullException(nameof(restClient));
    }
    
    public async Task<SearchResult> SearchAsync(SectionType sectionType, string text, bool textCorrection, int pageIndex = 0, CancellationToken cancellationToken = default)
    {
        var endpoint = YandexMusicEndpoints.Search(sectionType, text, pageIndex, textCorrection);
        var response = await _restClient.GetAsync<Response<SearchResult>>(endpoint, cancellationToken).ConfigureAwait(false);

        return response.Result;
    }
}