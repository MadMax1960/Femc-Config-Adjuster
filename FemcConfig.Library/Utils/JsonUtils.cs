using FemcConfig.Library.Config.Models;
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
        // If deserialization succeeds, return the object
        if (obj != null)
        {
            return obj;
        }
        else
        {
            var defaultConfig = new ReloadedModConfig();
            var defaultJson = JsonSerializer.Serialize(defaultConfig, serializerOptions);
            // If deserialization fails, replace the file content with the default JSON string
            File.WriteAllText(file, defaultJson);
            // Deserialize the new file content
            obj = JsonSerializer.Deserialize<T>(File.ReadAllText(file), serializerOptions);

            // If deserialization of the default JSON string fails, throw an exception
            if (obj == null)
            {
                throw new Exception($"Failed to deserialize default JSON string.\nDefault JSON String: {defaultJson}");
            }

            return obj;
        }
    }

    public static void SerializeFile<T>(T obj, string file)
    {
        var objText = JsonSerializer.Serialize(obj, serializerOptions);
        File.WriteAllText(file, objText);
    }
}
