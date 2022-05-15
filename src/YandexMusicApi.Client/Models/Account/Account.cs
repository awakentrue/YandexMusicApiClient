namespace YandexMusicApi.Client;

public class Account
{
    public string Uid { get; set; } = null!;
    
    public string DisplayName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public bool HostedUser { get; set; }

    public string Login { get; set; } = null!;

    public DateTime? Now { get; set; }

    public int Region { get; set; }

    public DateTime? RegisteredAt { get; set; }

    public string SecondName { get; set; } = null!;

    public bool ServiceAvailable { get; set; }
}