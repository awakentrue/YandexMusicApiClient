using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace YandexMusicApi.Client;

public class AccountSettings
{
    public string Uid { get; set; } = null!;

    [JsonConverter(typeof(StringEnumConverter))]
    public AccountTheme Theme { get; set; }
}