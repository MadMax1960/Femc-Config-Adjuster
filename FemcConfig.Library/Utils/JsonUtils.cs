using System.Text.Json;
using System.Text.Json.Serialization;
using static FemcConfig.Library.Config.Sections.IntroMovieSection;

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
/*
public class ModManager
{
    private readonly string _jsonFilePath;

    public ModManager(string jsonFilePath)
    {
        _jsonFilePath = jsonFilePath;
    }

    public void ToggleMod(string modName)
    {
        // Load the JSON file
        var config = JsonUtils.DeserializeFile<AppConfig>(_jsonFilePath);

        // Check if the mod is in the EnabledMods list
        if (config.EnabledMods.Contains(modName))
        {
            // If the mod is already enabled, remove it
            config.EnabledMods.Remove(modName);
        }
        else
        {
            // If the mod is not enabled, add it
            config.EnabledMods.Add(modName);
        }

        // Save the modified JSON back to the file
        string reloadeddir = Environment.GetEnvironmentVariable("RELOADEDIIMODS")
        ?? throw new Exception("Failed to find Reloaded II ENV variable.");
        JsonUtils.SerializeFile(config, _jsonFilePath);
    }
}

public class AppConfig
{
    public string AppId { get; set; }
    public string AppName { get; set; }
    public string AppLocation { get; set; }
    public string AppArguments { get; set; }
    public string AppIcon { get; set; }
    public bool AutoInject { get; set; }
    public List<string> EnabledMods { get; set; }
    public string WorkingDirectory { get; set; }
    public Dictionary<string, Dictionary<string, int>> PluginData { get; set; }
    public List<string> SortedMods { get; set; }
    public bool PreserveDisabledModOrder { get; set; }
    public bool DontInject { get; set; }
    public bool IsMsStore { get; set; }
}*/