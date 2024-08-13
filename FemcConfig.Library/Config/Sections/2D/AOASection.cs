using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections;

public class AOASection : ISection
{
    public string Name { get; } = "AOA";

    public string Description { get; } = "Card used when finishing battles with an all-out attack.";

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
                Enable = (ctx) => ctx.FemcConfig.Settings.AOATrue = Models.FemcModConfig.AOAType.Ely,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.AOATrue == Models.FemcModConfig.AOAType.Ely,
            },
            new ModOption(ctx)
            {
                InternalName = "aoa_fernando",
                Authors = [Author.Fernando],
                Enable = (ctx) => ctx.FemcConfig.Settings.AOATrue = Models.FemcModConfig.AOAType.Fernando,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.AOATrue == Models.FemcModConfig.AOAType.Fernando,
            },
            new ModOption(ctx)
            {
                InternalName = "aoa_ronald",
                Authors = [Author.Ronald],
                Enable = (ctx) => ctx.FemcConfig.Settings.AOATrue = Models.FemcModConfig.AOAType.RonaldReagan,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.AOATrue == Models.FemcModConfig.AOAType.RonaldReagan,
            },
            new ModOption(ctx)
            {
                InternalName = "aoa_monica",
                Authors = [Author.Monica],
                Enable = (ctx) => ctx.FemcConfig.Settings.AOATrue = Models.FemcModConfig.AOAType.Monica,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.AOATrue == Models.FemcModConfig.AOAType.Monica,
            },
            new ModOption(ctx)
            {
                InternalName = "aoa_chrysanthie",
                Authors = [Author.Chrysanthie],
                Enable = (ctx) => ctx.FemcConfig.Settings.AOATrue = Models.FemcModConfig.AOAType.Chrysanthie,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.AOATrue == Models.FemcModConfig.AOAType.Chrysanthie,
            },
        ];
    }
}
