using FemcConfig.Library.Config.Models;

namespace FemcConfig.Library.Config;

public class ModContext
{
    public required string ReloadedDir { get; init; }

    public required string ModDir { get; init; }

    public required ModConfig ModConfig { get; init; }
}
