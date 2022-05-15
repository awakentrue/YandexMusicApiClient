using System.Collections.Specialized;
using System.Web;

namespace YandexMusicApi.Client;

internal class QueryUriBuilder
{
    private readonly UriBuilder _uriBuilder;
    private readonly NameValueCollection _query;
    
    private QueryUriBuilder(string uri)
    {
        _uriBuilder = new UriBuilder(uri);
        _query = HttpUtility.ParseQueryString(_uriBuilder.Query);
    }

    public static QueryUriBuilder New(string uri)
    {
        return new QueryUriBuilder(uri);
    }

    public QueryUriBuilder AddQueryParameter(string key, object value)
    {
        _query.Add(key, value.ToString());

        return this;
    }

    public Uri Build()
    {
        _uriBuilder.Query = _query.ToString();

        return _uriBuilder.Uri;
    }
}