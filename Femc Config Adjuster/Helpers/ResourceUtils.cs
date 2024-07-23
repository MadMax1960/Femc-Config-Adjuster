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

    public static string? GetOptionYoutubeUrl(ModOption option)
    {
        var youtubeFile = Path.Join(appDir, "resources", option.InternalName, "youtube.txt");
        if (File.Exists(youtubeFile))
        {
            try
            {
                var youtubeUrl = File.ReadAllText(youtubeFile).Trim();
                return youtubeUrl;

            }
            catch (Exception)
            {
                return null;
            }
        }

        return null;
    }
}
