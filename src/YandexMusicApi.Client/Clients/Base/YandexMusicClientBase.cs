using YandexMusicApi.Client.Http;

namespace YandexMusicApi.Client;

public abstract class YandexMusicClientBase
{
    protected YandexMusicClientBase(IRestClient restClient)
    {
        RestClient = restClient ?? throw new ArgumentNullException(nameof(restClient));
    }

    protected IRestClient RestClient { get; }
}