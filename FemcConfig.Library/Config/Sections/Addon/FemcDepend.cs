using FemcConfig.Library.Config.Options;
namespace FemcConfig.Library.Config.Sections;
public class FemcDependSection : ISection
{
    public string Name { get; } = Localisation.LocalisationResources.Resources.Dependencies;
    public string Description { get; } = "Use this page to install and manage the dependencies used by the Femc Mod.";
    public SectionCategory Category { get; } = SectionCategory.MainPage;
    public ModOption[] Options { get; }
    public FemcDependSection(AppService app)
    {
        var ctx = app.GetContext();
        // Set all the options available.
        this.Options =
        [
            // Example for a bool setting.
            new ModOption(ctx)
            {
                InternalName = "mod_dependency",
                Name = "Ryo Framework",
                Authors = [Author.ZutomayoFan50],
                Category = "Addon",
                DownloadUrl = "https://gamebanana.com/mods/495507",

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => { },
                Disable = (ctx) => { },

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.ReloadedAppConfig.Settings.SortedMods.Contains("Ryo.Reloaded")
            },
            new ModOption(ctx)
            {
                InternalName = "mod_dependency",
                Name = "Unreal Essentials",
                Authors = [Author.AnimatedSwine37, Author.Rirurin],
                Category = "Addon",
                DownloadUrl = "https://github.com/AnimatedSwine37/UnrealEssentials/releases/latest",
                Downloader = Models.DownloadHandler.GithubReloadedDirectDL,
                GithubName="UnrealEssentials",
                GithubOwner="AnimatedSwine37",
                Regex="UnrealEssentials",

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => { },
                Disable = (ctx) => { },

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.ReloadedAppConfig.Settings.SortedMods.Contains("UnrealEssentials")
            },
            new ModOption(ctx)
            {
                InternalName = "mod_dependency",
                Name = "Costume Framework",
                Authors = [Author.ZutomayoFan50],
                Category = "Addon",
                DownloadUrl = "https://gamebanana.com/mods/501833",

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => { },
                Disable = (ctx) => { },

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.ReloadedAppConfig.Settings.SortedMods.Contains("P3R.CostumeFramework")
            },
            new ModOption(ctx)
            {
                InternalName = "mod_dependency",
                Name = "BGME Framework for P3R",
                Authors = [Author.ZutomayoFan50],
                Category = "Addon",
                DownloadUrl = "https://gamebanana.com/mods/495456",

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => { },
                Disable = (ctx) => { },

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.ReloadedAppConfig.Settings.SortedMods.Contains("BGME.Framework.P3R")
            },
            new ModOption(ctx)
            {
                InternalName = "mod_dependency",
                Name = "BGME Battle Themes",
                Authors = [Author.ZutomayoFan50],
                Category = "Addon",
                DownloadUrl = "https://gamebanana.com/mods/495458",

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => { },
                Disable = (ctx) => { },

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.ReloadedAppConfig.Settings.SortedMods.Contains("BGME.BattleThemes")
            },
            new ModOption(ctx)
            {
                InternalName = "mod_dependency",
                Name = "Unreal Objects Emitter",
                Authors = [Author.ZutomayoFan50],
                Category = "Addon",
                DownloadUrl = "https://gamebanana.com/mods/500638",

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => { },
                Disable = (ctx) => { },

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.ReloadedAppConfig.Settings.SortedMods.Contains("Unreal.ObjectsEmitter.Reloaded")
            },
            new ModOption(ctx)
            {
                InternalName = "mod_dependency",
                Name = "Persona 3 Reload Essentials",
                Authors = [Author.AnimatedSwine37, Author.Rirurin],
                Category = "Addon",
                DownloadUrl = "https://gamebanana.com/mods/494020",

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => { },
                Disable = (ctx) => { },

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.ReloadedAppConfig.Settings.SortedMods.Contains("p3rpc.essentials"),
            },
        ];
    }
}
