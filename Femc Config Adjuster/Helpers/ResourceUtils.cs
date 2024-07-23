using FemcConfig.Library.Config;
using FemcConfig.Library.Config.Options;
using System.IO;

namespace Femc_Config_Adjuster.Helpers;

internal static class ResourceUtils
{
    private static readonly string appDir = AppDomain.CurrentDomain.BaseDirectory;

    public static string GetOptionImagePath(ModOption option, bool isFullSize)
    {
        var imagePath = isFullSize ? Path.Join(appDir, "resources", option.InternalName, "image.webp")
            : Path.Join(appDir, "resources", option.InternalName, "image_small.webp");

        if (File.Exists(imagePath))
        {
            return imagePath;
        }

        return Path.Join(AppDomain.CurrentDomain.BaseDirectory, "resources", "missing.png");
    }

    public static string? GetOptionAudioPath(AppService app, ModOption option)
    {
        var audioPath = Path.Join(appDir, "resources", option.InternalName, "audio.hca");
        if (File.Exists(audioPath))
        {
            return audioPath;
        }

        return null;
    }
}
