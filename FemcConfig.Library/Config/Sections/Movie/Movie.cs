using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections;

public class MovieSection : ISection
{
    /// <summary>
    /// Section name. Sets the text that appears on the side and title of page.
    /// </summary>
    public string Name { get; } = "Intro Movies";

    public string Description { get; } = "Example description.";

    /// <summary>
    /// Section category, such as 2D, 3D, Audio, etc.
    /// </summary>
    public SectionCategory Category { get; } = SectionCategory.Movie;

    /// <summary>
    /// Contains all the options that appear in the section.
    /// Set it in the constructor below.
    /// </summary>
    public ModOption[] Options { get; }

    public MovieSection(AppService app)
    {
        var ctx = app.GetContext();

        // Set all the options available.
        this.Options =
        [
            // Example for a bool setting.
            new ModOption(ctx)
            {
                InternalName = "example",
                Name = "Bool Option",
                Authors = [Author.Missing],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.ModConfig.Settings.EnableBustup = true,
                Disable = (ctx) => ctx.ModConfig.Settings.EnableBustup = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.ModConfig.Settings.EnableBustup,
            },
        ];
    }
}
