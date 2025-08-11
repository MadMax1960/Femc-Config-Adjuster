using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections._3D;

public class Hair : ISection
{
    public string Name { get; } = Localisation.LocalisationResources.Resources.Hair;

    public string Description { get; } = Localisation.LocalisationResources.Resources.HairDesc;

    public SectionCategory Category { get; } = SectionCategory.ThreeD;

    public ModOption[] Options { get; }

    public Hair(AppService app)
    {
        var ctx = app.GetContext();
        this.Options =
        [
            new ModOption(ctx)
            {
                InternalName = "hair_default",
                Name = "Default",
                Authors = [Author.Mudkip],
                Enable = ctx => ctx.FemcConfig.Settings.HairTrue = Models.FemcModConfig.HairType.MudkipsHair,
                IsEnabledFunc = ctx => ctx.FemcConfig.Settings.HairTrue == Models.FemcModConfig.HairType.MudkipsHair,
            },
            new ModOption(ctx)
            {
                InternalName = "hair_bean",
                Name = "Kotone Bean",
                Authors = [Author.Mudkip],
                Enable = ctx => ctx.FemcConfig.Settings.HairTrue = Models.FemcModConfig.HairType.KotoneBeanHair,
                IsEnabledFunc = ctx => ctx.FemcConfig.Settings.HairTrue == Models.FemcModConfig.HairType.KotoneBeanHair,
            },
        ];
    }
}
