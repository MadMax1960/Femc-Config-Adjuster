using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Threading;

namespace FemcConfig.Library.Utils;

public static class JsonUtils
{
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
            fileBytes = fileBytes[3..]; 
        }

        return JsonSerializer.Deserialize<T>(fileBytes, serializerOptions)
               ?? throw new Exception("Failed to deserialize JSON.");
    }


    public static void SerializeFile<T>(T obj, string file)
    {
        var objText = JsonSerializer.Serialize(obj, serializerOptions);

        const int maxAttempts = 5;
        for (var attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                using var fs = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                using var writer = new StreamWriter(fs);
                writer.Write(objText);
                return;
            }
            catch (IOException) when (attempt < maxAttempts)
            {
                Thread.Sleep(100);
            }
        }
    }
}