using System.Text.Json;
using System.Text.Json.Serialization;

namespace FemcConfig.Library.Utils;

public static class JsonUtils
{   
    // Use same serialization options as Reloaded.
    private static JsonSerializerOptions serializerOptions { get; } = new JsonSerializerOptions()
    {
        Converters = { new JsonStringEnumConverter() },
        WriteIndented = true
    };

    public static T DeserializeFile<T>(string file)
    {
        var obj = JsonSerializer.Deserialize<T>(File.ReadAllText(file), serializerOptions);
        return obj ?? throw new Exception($"Failed to deserialize file.\nFile: {file}");
    }

    public static void SerializeFile<T>(T obj, string file)
    {
        var objText = JsonSerializer.Serialize(obj, serializerOptions);
        File.WriteAllText(file, objText);
    }
}
