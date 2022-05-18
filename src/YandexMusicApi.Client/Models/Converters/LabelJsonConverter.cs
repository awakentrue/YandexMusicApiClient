using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace YandexMusicApi.Client;

public class LabelJsonConverter : JsonConverter<List<Label>>
{
    public override bool CanWrite => false;

    public override List<Label>? ReadJson(JsonReader reader, Type objectType, List<Label>? existingValue, bool hasExistingValue,
        JsonSerializer serializer)
    {
        var token = JToken.Load(reader);
        
        if (token.HasValues == false || token.Type != JTokenType.Array)
        {
            return existingValue;
        }
        
        var tokenIsObjectLabel = token.First!.Type == JTokenType.Object;
        if (tokenIsObjectLabel)
        {
            return token.ToObject<List<Label>>();
        }

        var textLabels = token.ToObject<List<string>>();

        return textLabels!.Select(x => new Label {Name = x}).ToList();
    }
    

    public override void WriteJson(JsonWriter writer, List<Label>? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}