namespace FemcConfig.Library.Config.Models;

public enum DownloadHandler
{
    Browser,
    Direct,
    Reloaded,
    GithubReloadedDirectDL //It's the most stable method available but a release can only have one 7Z file (2 if you include delta releases). However you can have more than one 7Z file if the name of both the 7z files are different and in this case you will need to fill the Regex option in the Mod Option Settings. For Example: UnrealEssentials in UnrealEssentials1.1.5.7z.
}