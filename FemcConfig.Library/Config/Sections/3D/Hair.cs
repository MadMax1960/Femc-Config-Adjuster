using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections._3D;

public class Hair : ISection
{
    public string Name { get; } = "Hair";

    public string Description { get; } = "FEMC's hair model.";

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
                Enable = ctx => ctx.ModConfig.Settings.HairTrue = Models.ReloadedModConfig.HairType.MudkipsHair,
                IsEnabledFunc = ctx => ctx.ModConfig.Settings.HairTrue == Models.ReloadedModConfig.HairType.MudkipsHair,
            },
            new ModOption(ctx)
            {
                InternalName = "hair_bean",
                Name = "Kotone Bean",
                Authors = [Author.Mudkip],
                Enable = ctx => ctx.ModConfig.Settings.HairTrue = Models.ReloadedModConfig.HairType.KotoneBeanHair,
                IsEnabledFunc = ctx => ctx.ModConfig.Settings.HairTrue == Models.ReloadedModConfig.HairType.KotoneBeanHair,
            },
        ];
    }
}
