using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections;

public class ExampleSection : ISection
{
    /// <summary>
    /// Section name. Sets the text that appears on the side and title of page.
    /// </summary>
    public string Name { get; } = "Section Name";

    public string Description { get; } = "Example description.";

    /// <summary>
    /// Section category, such as 2D, 3D, Audio, etc.
    /// </summary>
    public SectionCategory Category { get; } = SectionCategory.Example;

    /// <summary>
    /// Contains all the options that appear in the section.
    /// Set it in the constructor below.
    /// </summary>
    public ModOption[] Options { get; }

    public ExampleSection(AppService app)
    {
        var ctx = app.GetContext();

        // Set all the options available.
        this.Options =
        [
            // Create a new option.
            new ModOption(ctx)
            {
                // Sets the name used to find extra files, like screenshots and audio.
                InternalName = "example",

                // Name displayed for option.
                Name = "Enum Option",

                // Add authors.
                Authors = [new Author("Author w/o Link"), new Author("Author", "https://google.com")],

                // What to do when option is enabled.
                // Usually just setting a value in the ModConfig.
                Enable = (ctx) => ctx.ModConfig.Settings.Nighttrue1 = Models.ReloadedModConfig.nightmusic1.ColorYourNightReload,

                // What determines if this option is enabled.
                // For bools it's just getting the setting value. For enums, like above, it's the same line but == instead of =.
                IsEnabledFunc = (ctx) => ctx.ModConfig.Settings.Nighttrue1 == Models.ReloadedModConfig.nightmusic1.ColorYourNightReload,
            },

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
