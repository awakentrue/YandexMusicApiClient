using System.Net;

namespace YandexMusicApi.Client.Exceptions;

public class YandexMusicClientException : Exception
{
    public YandexMusicClientException(HttpStatusCode statusCode, ResponseError? responseError, string? message) : base(message)
    {
        HttpStatusCode = statusCode;
        ResponseError = responseError;
    }

    public HttpStatusCode? HttpStatusCode { get; }
    
    public ResponseError? ResponseError { get; }
}