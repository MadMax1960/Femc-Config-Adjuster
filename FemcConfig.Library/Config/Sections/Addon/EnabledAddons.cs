using FemcConfig.Library.Config.Options;
namespace FemcConfig.Library.Config.Sections;
public class EnabledAddonsSection : ISection
{
    public string Name { get; } = Localisation.LocalisationResources.Resources.Addons;
    public string Description { get; } = Localisation.LocalisationResources.Resources.AddonDesc;
    public SectionCategory Category { get; } = SectionCategory.MainPage;
    public ModOption[] Options { get; }
    public EnabledAddonsSection(AppService app)
    {
        var ctx = app.GetContext();

        // Set all the options available.
        this.Options =
        [
            // Example for a bool setting.
            new ModOption(ctx)
            {
                InternalName = "movieaddon",
                Name = "Persona 3 Reload Intro Movies",
                Authors = [Author.Mosq, Author.TheBestAstroNOT, Author.Neptune],
                Category = "Addon",
                DownloadUrl = "https://github.com/TheBestAstroNOT/Persona-3-Reload-Intro-Movies/releases/download/1.0.0/Persona_3_Reload_Intro_Movies1.0.0.7z",
                Downloader = Models.DownloadHandler.Reloaded,
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Add("Persona_3_Reload_Intro_Movies"),
                Disable = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Remove("Persona_3_Reload_Intro_Movies"),

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Contains("Persona_3_Reload_Intro_Movies")
            },
            new ModOption(ctx)
            {
                InternalName = "colorarm",
                Name = "Colorful Armbands",
                Authors = [Author.Feonyx],
                Category = "Addon",
                DownloadUrl = "https://gamebanana.com/mods/525920",

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Add("p3rpc.colorfularmbands"),
                Disable = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Remove("p3rpc.colorfularmbands"),

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Contains("p3rpc.colorfularmbands")
            }
        ];
    }
}
