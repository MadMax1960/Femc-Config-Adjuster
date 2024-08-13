using System.Text.Json;
using System.Text.Json.Serialization;

namespace FemcConfig.Library.Utils;

public static class JsonUtils
{   
    // Use same serialization options as Reloaded.
    private static readonly JsonSerializerOptions serializerOptions = new()
    {
        Converters = { new JsonStringEnumConverter() },
        WriteIndented = true
    };

    public static T DeserializeFile<T>(string file)
        => JsonSerializer.Deserialize<T>(File.ReadAllBytes(file), serializerOptions) ?? throw new Exception();

    public static void SerializeFile<T>(T obj, string file)
    {
        var objText = JsonSerializer.Serialize(obj, serializerOptions);
        File.WriteAllText(file, objText);
    }
}
