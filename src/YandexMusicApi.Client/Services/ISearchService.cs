namespace YandexMusicApi.Client;

public interface ISearchService
{
    Task<SearchResult> SearchAsync(SectionType sectionType, string text, bool textCorrection, int pageIndex = 0, CancellationToken cancellationToken = default);
}