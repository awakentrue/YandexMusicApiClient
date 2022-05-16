using System.ComponentModel;
using YandexMusicApi.Client.Http;

namespace YandexMusicApi.Client;

public abstract class LibraryYandexMusicClientBase : YandexMusicClientBase
{
    private readonly ISearchService _searchService;
    private readonly SectionType _sectionType;
    
    protected LibraryYandexMusicClientBase(IRestClient restClient, ISearchService searchService, SectionType sectionType) : base(restClient)
    {
        if (!Enum.IsDefined(typeof(SectionType), sectionType))
            throw new InvalidEnumArgumentException(nameof(sectionType), (int) sectionType, typeof(SectionType));
        
        _searchService = searchService ?? throw new ArgumentNullException(nameof(searchService));
        _sectionType = sectionType;
    }

    public async Task SetLikeAsync(string userId, IEnumerable<string> ids, bool like = true, CancellationToken cancellationToken = default)
    {
        if (userId == null) throw new ArgumentNullException(nameof(userId));
        if (ids == null) throw new ArgumentNullException(nameof(ids));
        
        var endpoint = YandexMusicEndpoints.SetLike(_sectionType, userId, like);

        var body = HttpBodyBuilder.New()
                                  .Add($"{_sectionType.GetName()}-ids", string.Join(",", ids))
                                  .Build();
        
        await RestClient.PostAsync<Response>(endpoint, body, cancellationToken).ConfigureAwait(false);
    }
    
    public async Task SetDislikeAsync(string userId, IEnumerable<string> ids, bool dislike = true, CancellationToken cancellationToken = default)
    {
        if (userId == null) throw new ArgumentNullException(nameof(userId));
        if (ids == null) throw new ArgumentNullException(nameof(ids));

        var endpoint = YandexMusicEndpoints.SetDislike(_sectionType, userId, dislike);

        var body = HttpBodyBuilder.New()
                                  .Add($"{_sectionType.GetName()}-ids", string.Join(",", ids))
                                  .Build();

        await RestClient.PostAsync<Response>(endpoint, body, cancellationToken).ConfigureAwait(false);
    }
    
    protected async Task<TResponse> GetAsync<TResponse>(IEnumerable<string> ids, CancellationToken cancellationToken = default)
    {
        if (ids == null) throw new ArgumentNullException(nameof(ids));

        var endpoint = YandexMusicEndpoints.Get(_sectionType, ids);
        var response = await RestClient.GetAsync<Response<TResponse>>(endpoint, cancellationToken).ConfigureAwait(false);

        return response.Result;
    }

    protected async Task<Paging<T>> SearchAsync<T>(string text, bool textCorrection, int pageIndex = 0, CancellationToken cancellationToken = default)
    {
        var searchResult = await _searchService.SearchAsync(_sectionType, text, textCorrection, pageIndex, cancellationToken).ConfigureAwait(false);

        return searchResult.Get<T>();
    }
}