namespace YandexMusicApi.Client;

public class Response
{
    public ResponseError? Error { get; set; }

    public bool HasError => Error == null;
}

public class Response<TResult> : Response
{
    public TResult Result { get; set; } = default!;
}