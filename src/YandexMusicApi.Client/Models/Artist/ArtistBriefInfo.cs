namespace YandexMusicApi.Client;

public class ArtistBriefInfo
{
    public Artist Artist { get; set; } = null!;

    public IReadOnlyCollection<Album> Albums { get; set; } = new List<Album>();
    
    public IReadOnlyCollection<Album> AlsoAlbums { get; set; } = new List<Album>();

    public IReadOnlyCollection<Track> PopularTracks { get; set; } = new List<Track>();
    
    public IReadOnlyCollection<Artist> SimilarArtists { get; set; } = new List<Artist>();

    public IReadOnlyCollection<PlaylistId> PlaylistIds { get; set; } = new List<PlaylistId>();

    public IReadOnlyCollection<Playlist> Playlists { get; set; } = new List<Playlist>();
    
    public bool HasPromotions { get; set; }
}