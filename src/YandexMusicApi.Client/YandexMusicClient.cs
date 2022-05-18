using YandexMusicApi.Client.Http;

namespace YandexMusicApi.Client;

///<inheritdoc cref="IYandexMusicClient"/>
public class YandexMusicClient : IYandexMusicClient
{
    private readonly ISearchService _searchService;

    public YandexMusicClient() : this(RestClient.Unauthorized()) { }
    
    public YandexMusicClient(IRestClient restClient)
    {
        if (restClient == null) throw new ArgumentNullException(nameof(restClient));
        
        _searchService = new SearchService(restClient);
        
        Tracks = new TracksClient(restClient, _searchService);
        Albums = new AlbumsClient(restClient, _searchService);
        Artists = new ArtistsClient(restClient, _searchService);
        Playlists = new PlaylistsClient(restClient, _searchService);
        Genres = new GenresClient(restClient);
        Account = new AccountClient(restClient);
    }

    public ITracksClient Tracks { get; }
    
    public IAlbumsClient Albums { get; }
    
    public IArtistsClient Artists { get; }
    
    public IPlaylistsClient Playlists { get; }
    
    public IAccountClient Account { get; }
    
    public IGenresClient Genres { get; }

    public async Task<SearchResult> SearchAsync(string text, int pageIndex = 0, bool textCorrection = true, CancellationToken cancellationToken = default)
    {
        if (text == null) throw new ArgumentNullException(nameof(text));

        return await _searchService.SearchAsync(SectionType.All, text, textCorrection, pageIndex, cancellationToken).ConfigureAwait(false);
    }
}