using System.Net.Http.Headers;
using Newtonsoft.Json;
using YandexMusicApi.Client.Exceptions;

namespace YandexMusicApi.Client.Http;

public class RestClient : IRestClient
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerSettings _jsonSerializerSettings;

    private RestClient(Action<HttpClient>? configureClient = null)
    {
        _httpClient = new HttpClient();
        _jsonSerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
        };

        configureClient?.Invoke(_httpClient);
    }
    
    private RestClient(string authenticationToken, string tokenType, Action<HttpClient>? configureClient = null) : this(configureClient)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authenticationToken, tokenType);
    }
    
    public static RestClient Authorized(string authenticationToken, string tokenType, Action<HttpClient>? configureClient = null)
    {
        return new RestClient(authenticationToken, tokenType);
    }

    public static RestClient Unauthorized(Action<HttpClient>? configureClient = null)
    {
        return new RestClient(configureClient);
    }
    
    public async Task<TResponse> GetAsync<TResponse>(Uri uri, CancellationToken cancellationToken = default)
    {
        var request = CreateRequest(HttpMethod.Get, uri);

        return await SendRequestAsync<TResponse>(request, cancellationToken).ConfigureAwait(false);
    }

    public async Task<Stream> GetStreamAsync(Uri uri, CancellationToken cancellationToken = default)
    {
        if (uri is null) throw new ArgumentNullException(nameof(uri));
        
        return await _httpClient.GetStreamAsync(uri).ConfigureAwait(false);
    }
    
    public async Task<TResponse> PostAsync<TResponse>(Uri uri, HttpBody? body = default, CancellationToken cancellationToken = default)
    {
        var request = CreateRequest(HttpMethod.Post, uri);
    
        if (body is not null)
        {
            request.Content = new FormUrlEncodedContent(body);
        }
    
        return await SendRequestAsync<TResponse>(request, cancellationToken).ConfigureAwait(false);
    }

    private async Task<TResponse> SendRequestAsync<TResponse>(HttpRequestMessage request, CancellationToken cancellationToken = default)
    {
        if (request is null) throw new ArgumentNullException(nameof(request));

        var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);

        await EnsureSuccessStatusCodeAsync(response, cancellationToken);

        var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        
        return JsonConvert.DeserializeObject<TResponse>(content, _jsonSerializerSettings)!;
    }
    
    private static async Task EnsureSuccessStatusCodeAsync(HttpResponseMessage response, CancellationToken cancellationToken)
    {
        if (response.IsSuccessStatusCode)
            return;
        
        var errorContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        var responseError = JsonConvert.DeserializeObject<ResponseError>(errorContent);

        throw new YandexMusicClientException(response.StatusCode, responseError, errorContent);
    }
    
    private static HttpRequestMessage CreateRequest(HttpMethod method, Uri requestUri)
    {
        if (method is null) throw new ArgumentNullException(nameof(method));
        if (requestUri is null) throw new ArgumentNullException(nameof(requestUri));

        return new HttpRequestMessage(method, requestUri);
    }

    #region Disposing

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _httpClient?.Dispose();
        }
    }

    #endregion
}