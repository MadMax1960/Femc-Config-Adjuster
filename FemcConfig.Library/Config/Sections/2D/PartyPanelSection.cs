using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections;

public class PartyPanelSection : ISection
{
    public string Name { get; } = "Party Panel";

    public string Description { get; } = "Select the party panel, the things on the side.";

    public SectionCategory Category { get; } = SectionCategory.TwoD;

    public ModOption[] Options { get; }

    public PartyPanelSection(AppService app)
    {
        var ctx = app.GetContext();
        this.Options =
        [
            new ModOption(ctx)
            {
                InternalName = "partypanel_kris",
                Authors = [Author.Kris],
                Enable = (ctx) => ctx.FemcConfig.Settings.PartyPanelTrue = Models.FemcModConfig.PartyPanelType.Kris,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.PartyPanelTrue == Models.FemcModConfig.PartyPanelType.Kris,
            },
            new ModOption(ctx)
            {
                InternalName = "partypanel_esa",
                Authors = [Author.Esa],
                Enable = (ctx) => ctx.FemcConfig.Settings.PartyPanelTrue = Models.FemcModConfig.PartyPanelType.Esa,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.PartyPanelTrue == Models.FemcModConfig.PartyPanelType.Esa,
            },
        ];
    }
}
