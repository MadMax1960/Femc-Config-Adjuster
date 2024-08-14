using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections;

public class AOATextSection : ISection
{
    public string Name { get; } = "AOA Text";

    public string Description { get; } = "Text used when finishing battles with an all-out attack.";

    public SectionCategory Category { get; } = SectionCategory.TwoD;

    public ModOption[] Options { get; }

    public AOATextSection(AppService app)
    {
        var ctx = app.GetContext();
        this.Options =
        [
            new ModOption(ctx)
            {
                InternalName = "aoatext_srry",
                Authors = [Author.Femc],
                Enable = (ctx) => ctx.FemcConfig.Settings.AOAText = Models.FemcModConfig.AOATextType.SorryBoutThat,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.AOAText == Models.FemcModConfig.AOATextType.SorryBoutThat,
            },
            new ModOption(ctx)
            {
                InternalName = "aoatext_dontlook",
                Authors = [Author.Femc],
                Enable = (ctx) => ctx.FemcConfig.Settings.AOAText = Models.FemcModConfig.AOATextType.DontLookBack,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.AOAText == Models.FemcModConfig.AOATextType.DontLookBack,
            },
        ];
    }
}
