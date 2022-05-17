namespace YandexMusicApi.Client;

public class Paging<T> : Pager
{
    public IReadOnlyCollection<T> Results { get; set; } = new List<T>();

    public static Paging<T> MapFrom(IReadOnlyCollection<T> results, Pager pager)
    {
        return new Paging<T>
        {
            Results = results,
            Order = pager.Order,
            Total = pager.Total,
            PerPage = pager.PerPage
        };
    }
}