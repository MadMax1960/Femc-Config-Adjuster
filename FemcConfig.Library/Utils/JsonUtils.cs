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
            string backupjsonstr = "string jsonbackup = \"{\\r\\n  \\\"mosq\\\": false,\\r\\n  \\\"mosqeidk\\\": true,\\r\\n  \\\"karma\\\": false,\\r\\n  \\\"rock\\\": false,\\r\\n  \\\"nighttrue1\\\": \\\"TimeNightByMosqGabiVer\\\",\\r\\n  \\\"dayintrue1\\\": \\\"TimeByMosqGabiVer\\\",\\r\\n  \\\"dayintrue2\\\": \\\"SunByMosq\\\",\\r\\n  \\\"dayouttrue1\\\": \\\"WayOfL";
            // If deserialization fails, replace the file content with the stored string
            File.WriteAllText(file,backupjsonstr);

            // Deserialize the new file content
            obj = JsonSerializer.Deserialize<T>(File.ReadAllText(file), serializerOptions);

            // If deserialization of the stored string fails, throw an exception
            if (obj == null)
            {
                throw new Exception($"Failed to deserialize stored string.\nStored String: {backupjsonstr}");
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
