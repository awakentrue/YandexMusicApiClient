namespace YandexMusicApi.Client.Http;

internal sealed class HttpBodyBuilder
{
    private readonly HttpBody _body;

    private HttpBodyBuilder(HttpBody? body)
    {
        _body = body ?? new HttpBody();
    }

    public static HttpBodyBuilder New(HttpBody? body = default)
    {
        return new HttpBodyBuilder(body);
    }

    public HttpBodyBuilder Add(string key, string value)
    {
        _body.Add(key, value);
        
        return this;
    }

    public HttpBody Build()
    {
        return _body;
    }
}