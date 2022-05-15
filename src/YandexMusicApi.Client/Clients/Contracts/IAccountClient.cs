namespace YandexMusicApi.Client;

public interface IAccountClient
{
    Task<AccountStatus> GetAccountStatusAsync(CancellationToken cancellationToken = default);

    Task<AccountSettings> GetAccountSettingsAsync(CancellationToken cancellationToken = default);

    Task<AccountShortInfo> GetAccountInfoAsync(string uidOrLogin, CancellationToken cancellationToken = default);
}