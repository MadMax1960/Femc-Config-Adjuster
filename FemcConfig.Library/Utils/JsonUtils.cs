using System.Text.Json;

namespace FemcConfig.Library.Utils;

public static class JsonUtils
{
    public static T DeserializeFile<T>(string file)
    {
        var obj = JsonSerializer.Deserialize<T>(File.ReadAllText(file));
        return obj ?? throw new Exception($"Failed to deserialize file.\nFile: {file}");
    }

    public static void SerializeFile<T>(T obj, string file)
    {
        var objText = JsonSerializer.Serialize(obj);
        File.WriteAllText(file, objText);
    }
}
