namespace YandexMusicApi.Client;

public class AccountShortInfo
{
    public string Uid { get; set; } = null!;
    
    public string Login { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public bool Verified { get; set; }
    
    public AccountStatistic Statistic { get; set; } = null!;
}