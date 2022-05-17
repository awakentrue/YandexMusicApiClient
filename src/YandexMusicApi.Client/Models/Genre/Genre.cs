namespace YandexMusicApi.Client;

public class Genre
{
    public string Id { get; set; } = null!;

    public int Weight { get; set; }
    
    public bool ComposerTop { get; set; }
    
    public string Title { get; set; } = null!;

    public string FullTitle { get; set; } = null!;

    public GenreTitles Titles { get; set; } = null!;

    public IReadOnlyCollection<Genre> SubGenres { get; set; } = new List<Genre>();
}