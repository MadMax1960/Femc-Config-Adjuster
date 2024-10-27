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
	{
		byte[] fileBytes = File.ReadAllBytes(file);

		if (fileBytes.Length >= 3 && fileBytes[0] == 0xEF && fileBytes[1] == 0xBB && fileBytes[2] == 0xBF)
		{
			fileBytes = fileBytes[3..]; // Skip the BOM
		}

		return JsonSerializer.Deserialize<T>(fileBytes, serializerOptions)
			   ?? throw new Exception("Failed to deserialize JSON.");
	}


	public static void SerializeFile<T>(T obj, string file)
    {
        var objText = JsonSerializer.Serialize(obj, serializerOptions);
        File.WriteAllText(file, objText);
    }
}