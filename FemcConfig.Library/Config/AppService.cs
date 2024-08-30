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

        var appConfigFile = Path.Join(reloadedDir, "Apps", "p3r.exe", "AppConfig.json");
        if (!File.Exists(appConfigFile))
        {
            throw new Exception("Failed to find Reloaded app config.");
        }

        var appConfig = new SavableFile<ReloadedAppConfig>(appConfigFile);
        var reloadedModsDir = Path.Join(reloadedDir, "Mods");

        // Verify FEMC mod install dir.
        // Manually search for FEMC DLL since folder name isn't constant.
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

        if (femcDir == null)
        {
            throw new FemcNotFound();
        }

        // Find FEMC mod config file.
        var reloadedConfigsDir = Path.Join(reloadedDir, "User", "Mods");
        string? femcConfigFile = null;
        foreach (var configDir in Directory.EnumerateDirectories(reloadedConfigsDir))
        {
            var userConfigFile = Path.Join(configDir, "ModUserConfig.json");
            var userConfig = JsonUtils.DeserializeFile<ReloadedModUserConfig>(userConfigFile);

            if (userConfig.ModId == Constants.FEMC_MOD_ID)
            {
                femcConfigFile = Path.Join(configDir, "Config.json");
                break;
            }
        }

        if (femcConfigFile == null || File.Exists(femcConfigFile) == false)
        {
            throw new Exception("Failed to find FEMC config file.");
        }

        string? movieConfigFile = null;
		if (appConfig.Settings.EnabledMods.Contains("Persona_3_Reload_Intro_Movies"))
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
				else
				{
				}
			}
		}

		// Setup mod context.
		this.appContext = new()
        {
            ReloadedDir = reloadedDir,
            ModDir = femcDir,
            ReloadedAppConfig = appConfig,
            FemcConfig = new(femcConfigFile),
            MovieConfig = File.Exists(movieConfigFile) ? new(movieConfigFile) : null,
        };
    }

    // Automatically initialize by fetching Reloaded path from
    // ENV var.
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
    public FemcNotFound() : base("FEMC install was not found.")
    {
    }
}

public partial class AppData : ObservableObject
{
    [ObservableProperty]
    public string? reloadedDir;
}
