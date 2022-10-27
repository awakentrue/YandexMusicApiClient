using YandexMusicApi.Client.Http;
using YandexMusicApi.Client.Utils;
using TracksEndpoints = YandexMusicApi.Client.YandexMusicEndpoints.TracksEndpoints;

namespace YandexMusicApi.Client;

///<inheritdoc cref="ITracksClient"/>
public sealed class TracksClient : LibraryYandexMusicClientBase, ITracksClient
{
    internal TracksClient(IRestClient restClient, ISearchService searchService) : base(restClient, searchService, SectionType.Track) { }
    
    public async Task<Track> GetAsync(string trackId, CancellationToken cancellationToken = default)
    {
        if (trackId == null) throw new ArgumentNullException(nameof(trackId));

        var tracks = await GetAsync(new[] {trackId}, cancellationToken).ConfigureAwait(false);
        
        return tracks.Single();
    }

    public async Task<IReadOnlyCollection<Track>> GetAsync(IEnumerable<string> tracksIds, CancellationToken cancellationToken = default)
    {
        if (tracksIds == null) throw new ArgumentNullException(nameof(tracksIds));

        return await base.GetAsync<List<Track>>(tracksIds, cancellationToken).ConfigureAwait(false);
    }

    public async Task<IReadOnlyCollection<Track>> GetSimilarAsync(string trackId, CancellationToken cancellationToken = default)
    {
        if (trackId == null) throw new ArgumentNullException(nameof(trackId));

        var endpoint = TracksEndpoints.GetSimilarTracks(trackId);
        var response = await RestClient.GetAsync<Response<SimilarTracksResponse>>(endpoint, cancellationToken).ConfigureAwait(false);

        return response.Result.SimilarTracks;
    }

    public async Task<TrackSupplement> GetTrackSupplementAsync(string trackId, CancellationToken cancellationToken = default)
    {
        if (trackId == null) throw new ArgumentNullException(nameof(trackId));

        var endpoint = TracksEndpoints.GetTrackSupplement(trackId);
        var response = await RestClient.GetAsync<Response<TrackSupplement>>(endpoint, cancellationToken).ConfigureAwait(false);

        return response.Result;
    }

    public async Task<Paging<Track>> SearchAsync(string text, bool textCorrection, int pageIndex = 0, CancellationToken cancellationToken = default)
    {
        return await base.SearchAsync<Track>(text, textCorrection, pageIndex, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Stream> DownloadAsync(string trackId, string albumId, CancellationToken cancellationToken = default)
    {
        if (trackId == null) throw new ArgumentNullException(nameof(trackId));
        if (albumId == null) throw new ArgumentNullException(nameof(albumId));
        
        var downloadInfoUrl = await GetTrackDownloadInfoUrl(trackId, albumId, cancellationToken).ConfigureAwait(false);
        var downloadFileInfo = await GetTrackDownloadFileInfo(downloadInfoUrl, cancellationToken).ConfigureAwait(false);
        var downloadLink = downloadFileInfo.GetDownloadUrl();

        return await RestClient.GetStreamAsync(downloadLink, cancellationToken).ConfigureAwait(false);
    }
    
    private async Task<Uri> GetTrackDownloadInfoUrl(string trackId, string albumId, CancellationToken cancellationToken = default)
    {
        var endpoint = TracksEndpoints.TrackDownloadInfo(trackId, albumId);

        var response = await RestClient.GetAsync<Response<List<TrackDownloadInfo>>>(endpoint, cancellationToken).ConfigureAwait(false);
        
        var mp3DownloadInfo = response.Result.First(x => x.Codec == AudioCodecNames.Mp3);

        return new Uri($"{mp3DownloadInfo.DownloadInfoUrl}&format=json");
    }
    
    private async Task<DownloadFileInfo> GetTrackDownloadFileInfo(Uri downloadInfoUrl, CancellationToken cancellationToken = default)
    {
        return await RestClient.GetAsync<DownloadFileInfo>(downloadInfoUrl, cancellationToken).ConfigureAwait(false);
    }
}