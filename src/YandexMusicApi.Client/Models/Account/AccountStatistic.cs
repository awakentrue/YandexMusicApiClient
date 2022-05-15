namespace YandexMusicApi.Client;

public class AccountStatistic
{
    public int LikedUsers { get; set; }
    
    public int LikedByUsers { get; set; }
    
    public bool HasTracks { get; set; }
    
    public int LikedArtists { get; set; }
    
    public int LikedAlbums { get; set; }
    
    public int UgcTracks { get; set; }
}