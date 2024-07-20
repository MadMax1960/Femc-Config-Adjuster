using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections;

public class AOASection : ISection
{
    public string Name { get; } = "AOA";

    public SectionCategory Category { get; } = SectionCategory.TwoD;

    public ModOption[] Options { get; }

    public AOASection(AppService app)
    {
        var ctx = app.GetContext();
        this.Options =
        [
            new ModOption(ctx)
            {
                InternalName = "aoa_ely",
                Authors = [Author.Ely],
                Enable = (ctx) => ctx.ModConfig.Settings.AOATrue = Models.ReloadedModConfig.AOAType.Ely,
                IsEnabledFunc = (ctx) => ctx.ModConfig.Settings.AOATrue == Models.ReloadedModConfig.AOAType.Ely,
            },
            new ModOption(ctx)
            {
                InternalName = "aoa_fernando",
                Authors = [Author.Fernando],
                Enable = (ctx) => ctx.ModConfig.Settings.AOATrue = Models.ReloadedModConfig.AOAType.Fernando,
                IsEnabledFunc = (ctx) => ctx.ModConfig.Settings.AOATrue == Models.ReloadedModConfig.AOAType.Fernando,
            },
            new ModOption(ctx)
            {
                InternalName = "aoa_ronald",
                Authors = [Author.Ronald],
                Enable = (ctx) => ctx.ModConfig.Settings.AOATrue = Models.ReloadedModConfig.AOAType.RonaldReagan,
                IsEnabledFunc = (ctx) => ctx.ModConfig.Settings.AOATrue == Models.ReloadedModConfig.AOAType.RonaldReagan,
            },
            new ModOption(ctx)
            {
                InternalName = "aoa_monica",
                Authors = [Author.Monica],
                Enable = (ctx) => ctx.ModConfig.Settings.AOATrue = Models.ReloadedModConfig.AOAType.Monica,
                IsEnabledFunc = (ctx) => ctx.ModConfig.Settings.AOATrue == Models.ReloadedModConfig.AOAType.Monica,
            },
            new ModOption(ctx)
            {
                InternalName = "aoa_chrysanthie",
                Authors = [Author.Chrysanthie],
                Enable = (ctx) => ctx.ModConfig.Settings.AOATrue = Models.ReloadedModConfig.AOAType.Chrysanthie,
                IsEnabledFunc = (ctx) => ctx.ModConfig.Settings.AOATrue == Models.ReloadedModConfig.AOAType.Chrysanthie,
            },
        ];
    }
}
