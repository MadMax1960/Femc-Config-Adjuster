using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections;

public class CutinSection : ISection
{
    /// <summary>
    /// Section name. Sets the text that appears on the side and title of page.
    /// </summary>
    public string Name { get; } = "Cutin";

    public string Description { get; } = "Animation that occasionally plays when attacking weaknesses or hitting criticals.";

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
        ];
    }
}
