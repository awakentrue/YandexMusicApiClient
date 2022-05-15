using System.Security.Cryptography;
using System.Text;

namespace YandexMusicApi.Client;

public class DownloadFileInfo
{
    public string Host { get; set; } = null!;

    public string Path { get; set; } = null!;

    public string S { get; set; } = null!;

    public string Ts { get; set; } = null!;

    public Uri GetDownloadUrl()
    {
        const string salt = "XGRlBW9FXlekgbPrRHuSiA";

        var path = Path[1..];
        var secret = $"{salt}{path}{S}";
        var md5Secret = CreateMd5(secret);
        var uriString = $"https://{Host}/get-mp3/{md5Secret}/{Ts}{Path}";

        return new Uri(uriString);
    }
    
    private static string CreateMd5(string input)
    {
        using var md5 = MD5.Create();
        var inputBytes = Encoding.ASCII.GetBytes(input);
        var hashBytes = md5.ComputeHash(inputBytes);
        
        return BitConverter.ToString(hashBytes).Replace("-", "");
    }
}