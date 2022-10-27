using YandexMusicApi.Client.Http;
using ArtistsEndpoints = YandexMusicApi.Client.YandexMusicEndpoints.ArtistsEndpoints;

namespace YandexMusicApi.Client;

///<inheritdoc cref="IArtistsClient"/>
public sealed class ArtistsClient : LibraryYandexMusicClientBase, IArtistsClient
{
    internal ArtistsClient(IRestClient restClient, ISearchService searchService) : base(restClient, searchService, SectionType.Artist) { }

    public async Task<Artist> GetAsync(string artistId, CancellationToken cancellationToken = default)
    {
        if (artistId == null) throw new ArgumentNullException(nameof(artistId));

        var artists = await GetAsync(new[] {artistId}, cancellationToken).ConfigureAwait(false);
        
        return artists.Single();
    }

    public async Task<IReadOnlyCollection<Artist>> GetAsync(IEnumerable<string> artistsIds, CancellationToken cancellationToken = default)
    {
        if (artistsIds == null) throw new ArgumentNullException(nameof(artistsIds));

        return await base.GetAsync<List<Artist>>(artistsIds, cancellationToken).ConfigureAwait(false);
    }
    
    public async Task<Paging<Track>> GetTracksAsync(string artistId, int pageIndex = 0, int pageSize = 20, CancellationToken cancellationToken = default)
    {
        if (artistId == null) throw new ArgumentNullException(nameof(artistId));

        var endpoint = ArtistsEndpoints.GetTracks(artistId, pageIndex, pageSize);
        var response = await RestClient.GetAsync<Response<ArtistTracks>>(endpoint, cancellationToken).ConfigureAwait(false);
        var artistTracks = response.Result;
        
        return Paging<Track>.MapFrom(artistTracks.Tracks, artistTracks.Pager);
    }

    public async Task<Paging<Album>> GetAlbumsAsync(string artistId, int pageIndex = 0, int pageSize = 20,
        SortType sortType = SortType.Year, CancellationToken cancellationToken = default)
    {
        if (artistId == null) throw new ArgumentNullException(nameof(artistId));
        
        var endpoint = ArtistsEndpoints.GetAlbums(artistId, pageIndex, pageSize, sortType);
        var response = await RestClient.GetAsync<Response<ArtistAlbums>>(endpoint, cancellationToken).ConfigureAwait(false);
        var artistAlbums = response.Result;
        
        return Paging<Album>.MapFrom(artistAlbums.Albums, artistAlbums.Pager);
    }

    public async Task<ArtistBriefInfo> GetBriefInfoAsync(string artistId, CancellationToken cancellationToken = default)
    {
        if (artistId == null) throw new ArgumentNullException(nameof(artistId));
        
        var endpoint = ArtistsEndpoints.GetBriefInfo(artistId);
        var response = await RestClient.GetAsync<Response<ArtistBriefInfo>>(endpoint, cancellationToken).ConfigureAwait(false);

        return response.Result;
    }

    public async Task<Paging<Artist>> SearchAsync(string text, bool textCorrection, int pageIndex = 0, CancellationToken cancellationToken = default)
    {
        return await SearchAsync<Artist>(text, textCorrection, pageIndex, cancellationToken).ConfigureAwait(false);
    }
}