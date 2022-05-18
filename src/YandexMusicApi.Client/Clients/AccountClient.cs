using YandexMusicApi.Client.Http;
using AccountEndpoints = YandexMusicApi.Client.YandexMusicEndpoints.AccountEndpoints;

namespace YandexMusicApi.Client;

///<inheritdoc cref="IAccountClient"/>
public sealed class AccountClient : YandexMusicClientBase, IAccountClient
{
    internal AccountClient(IRestClient restClient) : base(restClient) { }

    public async Task<AccountStatus> GetAccountStatusAsync(CancellationToken cancellationToken = default)
    {
        var endpoint = AccountEndpoints.AccountStatus;
        var response = await RestClient.GetAsync<Response<AccountStatus>>(endpoint, cancellationToken).ConfigureAwait(false);

        return response.Result;
    }

    public async Task<AccountShortInfo> GetAccountInfoAsync(string uidOrLogin, CancellationToken cancellationToken = default)
    {
        if (uidOrLogin == null) throw new ArgumentNullException(nameof(uidOrLogin));
        
        var endpoint = AccountEndpoints.AccountInfo(uidOrLogin);
        var response = await RestClient.GetAsync<Response<AccountShortInfo>>(endpoint, cancellationToken).ConfigureAwait(false);

        return response.Result;
    }

    public async Task<AccountSettings> GetAccountSettingsAsync(CancellationToken cancellationToken = default)
    {
        var endpoint = AccountEndpoints.AccountSettings;
        var response = await RestClient.GetAsync<Response<AccountSettings>>(endpoint, cancellationToken).ConfigureAwait(false);

        return response.Result;
    }
}