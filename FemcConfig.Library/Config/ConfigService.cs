using FemcConfig.Library.Common;
using FemcConfig.Library.Config.Models;
using FemcConfig.Library.Utils;

namespace FemcConfig.Library.Config;

public class ConfigService
{
    private ModContext? modContext;

    public ConfigService()
    {
        this.AutoInit();
    }

    public void SaveConfig()
    {
        this.modContext?.ModConfig?.Save();
    }

    private void AutoInit()
    {
        // Get Reloaded dir from environment.
        var reloadedModsDir = Environment.GetEnvironmentVariable("RELOADEDIIMODS")
            ?? throw new Exception("Failed to find Reloaded II ENV variable.");

        var reloadedDir = Path.GetDirectoryName(reloadedModsDir)!;

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
            throw new Exception("Failed to find FEMC dir.");
        }

        // Find FEMC mod config file.
        var reloadedConfigsDir = Path.Join(reloadedDir, "user", "mods");
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

        // Setup mod context.
        this.modContext = new()
        {
            ReloadedDir = reloadedDir,
            ModDir = femcDir,
            ModConfig = new(femcConfigFile),
        };
    }
}
