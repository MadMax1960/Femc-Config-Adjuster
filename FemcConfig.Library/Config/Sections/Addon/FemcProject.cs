using FemcConfig.Library.Config.Options;
namespace FemcConfig.Library.Config.Sections;
public class FemcProjectSection : ISection
{
    public string Name { get; } = Localisation.LocalisationResources.Resources.The_Femc_Mod;
    public string Description { get; } = Localisation.LocalisationResources.Resources.FemcDesc;
    public SectionCategory Category { get; } = SectionCategory.MainPage;
    public ModOption[] Options { get; }
    public FemcProjectSection(AppService app)
    {
        var ctx = app.GetContext();
        // Set all the options available.
        this.Options =
        [
            new ModOption(ctx)
            {
                InternalName = "femcdepend",
                Name = "Femc Reloaded Project",
                Authors = [Author.Femc],
                Category = "Addon",
                DownloadUrl = "https://github.com/MadMax1960/Femc-Reloaded-Project",
                Downloader = Models.DownloadHandler.GithubReloadedDirectDL,
                GithubOwner="MadMax1960",
                GithubName="Femc-Reloaded-Project",

               // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Add("p3rpc.femc"),
                Disable = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Remove("p3rpc.femc"),

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Contains("p3rpc.femc")
            },
        ];
    }
}
