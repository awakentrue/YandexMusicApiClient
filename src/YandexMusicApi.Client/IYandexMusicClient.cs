namespace YandexMusicApi.Client;

public interface IYandexMusicClient
{
    ITracksClient Tracks { get; }
    
    IAlbumsClient Albums { get; }
    
    IArtistsClient Artists { get; }
    
    IPlaylistsClient Playlists { get; }
    
    IAccountClient Account { get; }

    Task<SearchResult> SearchAsync(string text, int pageIndex = 0, bool textCorrection = true, CancellationToken cancellationToken = default);
}