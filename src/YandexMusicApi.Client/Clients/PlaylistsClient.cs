using YandexMusicApi.Client.Http;

namespace YandexMusicApi.Client;

public sealed class PlaylistsClient : LibraryYandexMusicClientBase, IPlaylistsClient
{
    internal PlaylistsClient(IRestClient restClient, ISearchService searchService) : base(restClient, searchService, SectionType.Playlist) { }

    public async Task<Playlist> GetAsync(PlaylistQuery playlist, CancellationToken cancellationToken = default)
    {
        if (playlist == null) throw new ArgumentNullException(nameof(playlist));
        
        var playlists = await GetAsync(new []{playlist}, cancellationToken).ConfigureAwait(false);

        return playlists.Single();
    }

    public async Task<IReadOnlyCollection<Playlist>> GetAsync(IEnumerable<PlaylistQuery> playlistsQueries, CancellationToken cancellationToken = default)
    {
        if (playlistsQueries == null) throw new ArgumentNullException(nameof(playlistsQueries));

        var ids = playlistsQueries.Select(x => x.ToString());
        var response = await base.GetAsync<PlaylistResult>(ids, cancellationToken).ConfigureAwait(false);

        return response.Playlists;
    }

    public async Task SetLikeAsync(string userId, IEnumerable<PlaylistQuery> playlistsQueries, bool like = true, CancellationToken cancellationToken = default)
    {
        if (userId == null) throw new ArgumentNullException(nameof(userId));
        if (playlistsQueries == null) throw new ArgumentNullException(nameof(playlistsQueries));
        
        var ids = playlistsQueries.Select(x => x.ToString());
        
        await base.SetLikeAsync(userId, ids, like, cancellationToken).ConfigureAwait(false);
    }

    public async Task SetDislikeAsync(string userId, IEnumerable<PlaylistQuery> playlistsQueries, bool dislike = true, CancellationToken cancellationToken = default)
    {
        if (userId == null) throw new ArgumentNullException(nameof(userId));
        if (playlistsQueries == null) throw new ArgumentNullException(nameof(playlistsQueries));

        var ids = playlistsQueries.Select(x => x.ToString());
        
        await base.SetDislikeAsync(userId, ids, dislike, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Paging<Playlist>> SearchAsync(string text, bool textCorrection, int pageIndex = 0, CancellationToken cancellationToken = default)
    {
        return await base.SearchAsync<Playlist>(text, textCorrection, pageIndex, cancellationToken).ConfigureAwait(false);
    }
}