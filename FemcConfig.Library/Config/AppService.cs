using CommunityToolkit.Mvvm.ComponentModel;
using FemcConfig.Library.Common;
using FemcConfig.Library.Config.Models;
using FemcConfig.Library.Utils;

namespace FemcConfig.Library.Config;

public class AppService
{
    private AppContext? appContext;
    private readonly SavableFile<AppData> appData;

    public AppService()
    {
        var appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        this.AppDataDir = Path.Join(appDataDir, "FemcConfigAdjuster");
        Directory.CreateDirectory(this.AppDataDir);

        var appDataFile = Path.Join(this.AppDataDir, "femc.json");
        this.appData = new(appDataFile);

        try
        {
            this.AutoInit();
        }
        catch (Exception) { }
    }

    public string AppDataDir { get; }

    public AppContext GetContext()
        => this.appContext ?? throw new Exception("App context not set.");

    public void Initialize(string reloadedDir)
    {
        this.appData.Settings.ReloadedDir = reloadedDir;
        if (reloadedDir is null)
            throw new Exception("Reloaded Directory not found");
        var appConfigFile = Path.Join(reloadedDir, "Apps", "p3r.exe", "AppConfig.json");
        if (!File.Exists(appConfigFile))
        {
            throw new Exception("Failed to find Reloaded app config.");
        }

        var appConfig = new SavableFile<ReloadedAppConfig>(appConfigFile);
        var reloadedModsDir = Path.Join(reloadedDir, "Mods");

        // Search for the FEMC mod installation directory
        string? femcDir = null;
        foreach (var dir in Directory.EnumerateDirectories(reloadedModsDir))
        {
            var femcDll = Path.Join(dir, "p3rpc.femc.dll");
            if (File.Exists(femcDll))
            {
                femcDir = dir;
                break;
            }
        }

        // Search for the FEMC user configuration folder
        var reloadedConfigsDir = Path.Join(reloadedDir, "User", "Mods");
        string? femcConfigFile = null;
        foreach (var configDir in Directory.EnumerateDirectories(reloadedConfigsDir))
        {
            var userConfigFile = Path.Join(configDir, "ModUserConfig.json");
            var userConfig = File.Exists(userConfigFile) ? JsonUtils.DeserializeFile<ReloadedModUserConfig>(userConfigFile) : null;

            if (userConfig?.ModId == Constants.FEMC_MOD_ID)
            {
                femcConfigFile = Path.Join(configDir, "Config.json");
                break;
            }
        }

        // NEW: If the config file path was not found via scan, assume the default path based on Mod ID
        if (femcConfigFile == null)
        {
            femcConfigFile = Path.Join(reloadedConfigsDir, Constants.FEMC_MOD_ID, "Config.json");
        }

        // NEW: Ensure the configuration directory exists so the file can be created if missing
        var femcConfigDir = Path.GetDirectoryName(femcConfigFile);
        if (!string.IsNullOrEmpty(femcConfigDir))
        {
            Directory.CreateDirectory(femcConfigDir);
        }

        // Search for Movie Mod config if enabled
        string? movieConfigFile = null;
        if (appConfig.Settings.EnabledMods.Contains(Constants.MOVIE_MOD_ID))
        {
            foreach (var configDir in Directory.EnumerateDirectories(reloadedConfigsDir))
            {
                var userConfigFile = Path.Join(configDir, "ModUserConfig.json");
                if (File.Exists(userConfigFile))
                {
                    var userConfig = JsonUtils.DeserializeFile<ReloadedModUserConfig>(userConfigFile);
                    if (userConfig.ModId == Constants.MOVIE_MOD_ID)
                    {
                        movieConfigFile = Path.Join(configDir, "Config.json");
                        break;
                    }
                }
            }
        }

        // Determine Mod Version status
        string femcModVersionStatus = "NotExecError";
        string? femcModConfigFile = femcDir != null ? Path.Join(femcDir, "ModConfig.json") : null;
        if (femcModConfigFile != null && File.Exists(femcModConfigFile))
        {
            var femcModVersion = JsonUtils.DeserializeFile<ModInfo>(femcModConfigFile).ModVersion;
            femcModVersionStatus = (femcModVersion == Constants.FEMC_MOD_VER) ? "SUPPORTED" : "UNSUPPORTED";
        }
        else
        {
            femcModVersionStatus = "404FILENOTFOUND";
        }

        // Setup mod context.
        this.appContext = new()
        {
            ReloadedDir = reloadedDir,
            ModDir = femcDir ?? "",
            ReloadedAppConfig = appConfig,
            // SavableFile will automatically create 'Config.json' with default values if it doesn't exist
            FemcConfig = new(femcConfigFile),
            FemcModVersion = femcModVersionStatus,
            MovieConfig = File.Exists(movieConfigFile) ? new(movieConfigFile) : null,
        };
    }

    private void AutoInit()
    {
        if (this.appData.Settings.ReloadedDir != null)
        {
            this.Initialize(this.appData.Settings.ReloadedDir);
        }
        else if (Environment.GetEnvironmentVariable("RELOADEDIIMODS") is string reloadedModsDir)
        {
            var reloadedDir = Path.GetDirectoryName(reloadedModsDir)!;
            this.Initialize(reloadedDir);
        }
    }
}

public class FemcNotFound : Exception
{
    public FemcNotFound() : base("Failed to find FEMC config file. Please launch the game once with the mod enabled.")
    {
    }
}

public partial class AppData : ObservableObject
{
    [ObservableProperty]
    public string? reloadedDir;
}

public class ModInfo
{
    public string ModVersion { get; set; } = string.Empty;
}