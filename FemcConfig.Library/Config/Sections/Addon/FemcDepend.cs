using FemcConfig.Library.Config.Options;
namespace FemcConfig.Library.Config.Sections;
public class FemcDependSection : ISection
{
    public string Name { get; } = "Dependency Managment";
    public string Description { get; } = "Use this page to install and manage the dependencies used by the Femc Mod.";
    public SectionCategory Category { get; } = SectionCategory.Addon;
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
                InternalName = "ryo",
                Name = "Ryo Framework",
                Authors = [Author.ZutomayoFan50],
                Category = "Addon",

               // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Add("Ryo.Reloaded"),
                Disable = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Remove("Ryo.Reloaded"),

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Contains("Ryo.Reloaded")
            },
            new ModOption(ctx)
            {
                InternalName = "ue",
                Name = "Unreal Essentials",
                Authors = [Author.AnimatedSwine37, Author.Rirurin],
                Category = "Addon",

               // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Add("UnrealEssentials"),
                Disable = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Remove("UnrealEssentials"),

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Contains("UnrealEssentials")
            },
            new ModOption(ctx)
            {
                InternalName = "costume",
                Name = "Costume Framework",
                Authors = [Author.ZutomayoFan50],
                Category = "Addon",

               // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Add("P3R.CostumeFramework"),
                Disable = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Remove("P3R.CostumeFramework"),

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Contains("P3R.CostumeFramework")
            },
            new ModOption(ctx)
            {
                InternalName = "bgme",
                Name = "BGME Framework for P3R",
                Authors = [Author.ZutomayoFan50],
                Category = "Addon",

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Add("BGME.Framework.P3R"),
                Disable = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Remove("BGME.Framework.P3R"),

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Contains("BGME.Framework.P3R")
            },
            new ModOption(ctx)
            {
                InternalName = "battletheme",
                Name = "BGME Battle Themes",
                Authors = [Author.ZutomayoFan50],
                Category = "Addon",

               // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Add("BGME.BattleThemes"),
                Disable = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Remove("BGME.BattleThemes"),

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Contains("BGME.BattleThemes")
            },
            new ModOption(ctx)
            {
                InternalName = "object",
                Name = "Unreal Objects Emitter",
                Authors = [Author.ZutomayoFan50],
                Category = "Addon",

               // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Add("Unreal.ObjectsEmitter.Reloaded"),
                Disable = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Remove("Unreal.ObjectsEmitter.Reloaded"),

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Contains("Unreal.ObjectsEmitter.Reloaded")
            },
            new ModOption(ctx)
            {
                InternalName = "p3re",
                Name = "Persona 3 Reload Essentials",
                Authors = [Author.AnimatedSwine37, Author.Rirurin],
                Category = "Addon",

               // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Add("p3rpc.essentials"),
                Disable = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Remove("p3rpc.essentials"),

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.ReloadedAppConfig.Settings.EnabledMods.Contains("p3rpc.essentials")
            },
        ];
    }
}
