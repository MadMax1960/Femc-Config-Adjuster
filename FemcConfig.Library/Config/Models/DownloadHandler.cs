namespace FemcConfig.Library.Config.Models;

public enum DownloadHandler
{
    Browser,
    Direct,
    Reloaded,
    GithubReloadedDirectDL //Downloads the latest release from a github repository via the r2 protocol. It's the most stable method available but a release can only have one 7Z file (So no delta releases). If a release has more than one 7Z file it might not work as intended. Only use this if you know what you are doing.
}
