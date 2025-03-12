using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections;

public class CutinSection : ISection
{
    /// <summary>
    /// Section name. Sets the text that appears on the side and title of page.
    /// </summary>
    public string Name { get; } = Localisation.LocalisationResources.Resources.Cutin;

    public string Description { get; } = Localisation.LocalisationResources.Resources.CutinDesc;

    /// <summary>
    /// Section category, such as 2D, 3D, Audio, etc.
    /// </summary>
    public SectionCategory Category { get; } = SectionCategory.TwoD;

    /// <summary>
    /// Contains all the options that appear in the section.
    /// Set it in the constructor below.
    /// </summary>
    public ModOption[] Options { get; }

    public CutinSection(AppService app)
    {
        var ctx = app.GetContext();

        // Set all the options available.
        this.Options =
        [
            new ModOption(ctx)
            {
                InternalName = "cutin_berry",
                Authors = [Author.Berrycha],
                Enable = ctx => ctx.FemcConfig.Settings.CutinTrue = Models.FemcModConfig.CutinType.berrycha,
                IsEnabledFunc = ctx => ctx.FemcConfig.Settings.CutinTrue == Models.FemcModConfig.CutinType.berrycha,
            },
            new ModOption(ctx)
            {
                InternalName = "cutin_elypat",
                Authors = [Author.Ely, Author.PatMandDX],
                Enable = ctx => ctx.FemcConfig.Settings.CutinTrue = Models.FemcModConfig.CutinType.ElyandPatmandx,
                IsEnabledFunc = ctx => ctx.FemcConfig.Settings.CutinTrue == Models.FemcModConfig.CutinType.ElyandPatmandx,
            },
            new ModOption(ctx)
            {
                InternalName = "cutin_mekki",
                Authors = [Author.Mekki],
                Enable = ctx => ctx.FemcConfig.Settings.CutinTrue = Models.FemcModConfig.CutinType.Mekki,
                IsEnabledFunc = ctx => ctx.FemcConfig.Settings.CutinTrue == Models.FemcModConfig.CutinType.Mekki,
            },
            new ModOption(ctx)
            {
                InternalName = "cutin_shiosakana",
                Authors = [Author.Shiosakana],
                Enable = ctx => ctx.FemcConfig.Settings.CutinTrue = Models.FemcModConfig.CutinType.shiosakana,
                IsEnabledFunc = ctx => ctx.FemcConfig.Settings.CutinTrue == Models.FemcModConfig.CutinType.shiosakana,
            },
        ];
    }
}
