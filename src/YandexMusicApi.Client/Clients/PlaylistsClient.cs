using YandexMusicApi.Client.Http;

namespace YandexMusicApi.Client;

///<inheritdoc cref="IPlaylistsClient"/>
public sealed class PlaylistsClient : LibraryYandexMusicClientBase, IPlaylistsClient
{
    internal PlaylistsClient(IRestClient restClient, ISearchService searchService) : base(restClient, searchService, SectionType.Playlist) { }

    public async Task<Playlist> GetAsync(PlaylistId playlistId, CancellationToken cancellationToken = default)
    {
        if (playlistId == null) throw new ArgumentNullException(nameof(playlistId));
        
        var playlists = await GetAsync(new []{playlistId}, cancellationToken).ConfigureAwait(false);

        return playlists.Single();
    }

    public async Task<IReadOnlyCollection<Playlist>> GetAsync(IEnumerable<PlaylistId> playlistIds, CancellationToken cancellationToken = default)
    {
        if (playlistIds == null) throw new ArgumentNullException(nameof(playlistIds));

        var ids = playlistIds.Select(x => x.ToString());
        var response = await base.GetAsync<PlaylistResult>(ids, cancellationToken).ConfigureAwait(false);

        return response.Playlists;
    }

    public async Task SetLikeAsync(string userId, IEnumerable<PlaylistId> playlistIds, bool like = true, CancellationToken cancellationToken = default)
    {
        if (userId == null) throw new ArgumentNullException(nameof(userId));
        if (playlistIds == null) throw new ArgumentNullException(nameof(playlistIds));
        
        var ids = playlistIds.Select(x => x.ToString());
        
        await base.SetLikeAsync(userId, ids, like, cancellationToken).ConfigureAwait(false);
    }

    public async Task SetDislikeAsync(string userId, IEnumerable<PlaylistId> playlistIds, bool dislike = true, CancellationToken cancellationToken = default)
    {
        if (userId == null) throw new ArgumentNullException(nameof(userId));
        if (playlistIds == null) throw new ArgumentNullException(nameof(playlistIds));

        var ids = playlistIds.Select(x => x.ToString());
        
        await base.SetDislikeAsync(userId, ids, dislike, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Paging<Playlist>> SearchAsync(string text, bool textCorrection, int pageIndex = 0, CancellationToken cancellationToken = default)
    {
        return await base.SearchAsync<Playlist>(text, textCorrection, pageIndex, cancellationToken).ConfigureAwait(false);
    }
}