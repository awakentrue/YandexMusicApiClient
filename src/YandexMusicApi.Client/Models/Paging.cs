namespace YandexMusicApi.Client;

public class Paging<T> : Pager
{
    public List<T> Results { get; set; } = new List<T>();

    public static Paging<T> MapFrom(List<T> results, Pager pager)
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