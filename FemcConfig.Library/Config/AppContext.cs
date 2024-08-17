using FemcConfig.Library.Config.Models;

namespace FemcConfig.Library.Config;

public class AppContext
{
    public string AppDir { get; } = AppDomain.CurrentDomain.BaseDirectory;

    public required string ReloadedDir { get; init; }

    public required string ModDir { get; init; }

    public required ModConfig<FemcModConfig> FemcConfig { get; init; }

    public ModConfig<MovieModConfig>? MovieConfig { get; init; }

    public required ModConfig<ReloadedAppConfig> AppConfig { get; init; }
}
