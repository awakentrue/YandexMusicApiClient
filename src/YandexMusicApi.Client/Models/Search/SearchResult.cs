namespace YandexMusicApi.Client;

public class SearchResult
{
    public BestResult Best { get; set; } = null!;
    
    public Paging<Track> Tracks { get; set; } = null!;

    public Paging<Album> Albums { get; set; } = null!;
    
    public Paging<Artist> Artists { get; set; } = null!;
    
    public Paging<Playlist> Playlists { get; set; } = null!;

    internal Paging<TLibraryEntity> Get<TLibraryEntity>()
    {
        return typeof(TLibraryEntity).Name switch
        {
            nameof(Track) => (Tracks as Paging<TLibraryEntity>)!,
            nameof(Album) => (Albums as Paging<TLibraryEntity>)!,
            nameof(Artist) => (Artists as Paging<TLibraryEntity>)!,
            nameof(Playlist) => (Playlists as Paging<TLibraryEntity>)!,
            _ => throw new InvalidCastException()
        };
    }
}