using YandexMusicApi.Client.Http;
using AlbumsEndpoints = YandexMusicApi.Client.YandexMusicEndpoints.AlbumsEndpoints;

namespace YandexMusicApi.Client;

///<inheritdoc cref="IAlbumsClient"/>
public sealed class AlbumsClient : LibraryYandexMusicClientBase, IAlbumsClient
{
    internal AlbumsClient(IRestClient restClient, ISearchService searchService) : base(restClient, searchService, SectionType.Album) { }

    public async Task<Album> GetAsync(string albumId, CancellationToken cancellationToken = default)
    {
        if (albumId == null) throw new ArgumentNullException(nameof(albumId));

        var albums = await GetAsync(new[] {albumId}, cancellationToken).ConfigureAwait(false);
        
        return albums.Single();
    }

    public async Task<IReadOnlyCollection<Album>> GetAsync(IEnumerable<string> albumsIds, CancellationToken cancellationToken = default)
    {
        if (albumsIds == null) throw new ArgumentNullException(nameof(albumsIds));

        return await base.GetAsync<List<Album>>(albumsIds, cancellationToken).ConfigureAwait(false);
    }
    
    public async Task<AlbumWithTracks> GetWithTracksAsync(string albumId, CancellationToken cancellationToken = default)
    {
        if (albumId == null) throw new ArgumentNullException(nameof(albumId));

        var endpoint = AlbumsEndpoints.GetWithTracks(albumId);
        var response = await RestClient.GetAsync<Response<AlbumWithTracks>>(endpoint, cancellationToken).ConfigureAwait(false);

        return response.Result;
    }

    public async Task<Paging<Album>> SearchAsync(string text, bool textCorrection, int pageIndex = 0, CancellationToken cancellationToken = default)
    {
        return await base.SearchAsync<Album>(text, textCorrection, pageIndex, cancellationToken).ConfigureAwait(false);
    }
}