using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections._3D;

public class Naginata : ISection
{
    public string Name { get; } = Localisation.LocalisationResources.Resources.Naginata;

    public string Description { get; } = Localisation.LocalisationResources.Resources.NaginataDesc;

    public SectionCategory Category { get; } = SectionCategory.ThreeD;

    public ModOption[] Options { get; }

    public Naginata(AppService app)
    {
        var ctx = app.GetContext();
        this.Options =
        [
            new ModOption(ctx)
            {
                InternalName = "naginata_default",
                Name = "Naginata",
                Authors = [Author.Femc], // fix
                Enable = ctx => ctx.FemcConfig.Settings.NagiWeap = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.NagiWeap = false,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.NagiWeap,
            }
        ];
    }
}
