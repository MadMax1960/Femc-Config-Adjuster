using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections;

public class NormalMusicSection : ISection
{
    /// <summary>
    /// Section name. Sets the text that appears on the side and title of page.
    /// </summary>
    public string Name { get; } = "Normal Battle Music";

    public string Description { get; } = "Select what music should be played when you are in a normal battle. Multiple songs can be chosen for randomisation!";

    /// <summary>
    /// Section category, such as 2D, 3D, Audio, etc.
    /// </summary>
    public SectionCategory Category { get; } = SectionCategory.Audio;

    /// <summary>
    /// Contains all the options that appear in the section.
    /// Set it in the constructor below.
    /// </summary>
    public ModOption[] Options { get; }

    public NormalMusicSection(AppService app)
    {
        var ctx = app.GetContext();

        // Set all the options available.
        this.Options =
        [
            // Example for a bool setting.
           new ModOption(ctx)
            {
                InternalName = "music_atlus_msd",
                Name = "Mass Destruction -reload-",
                Authors = [Author.Atlus],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.Massdes = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.Massdes = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.Massdes,
            },
           new ModOption(ctx)
            {
                InternalName = "music_mosq_wao",
                Name = "Wiping All Out -Reload-",
                Authors = [Author.Mosq],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.Mosqnom = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.Mosqnom = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.Mosqnom,
            },
           new ModOption(ctx)
            {
                InternalName = "music_karma_wao",
                Name = "Wiping All Out -Reloaded- (P3P Cover)",
                Authors = [Author.Karma],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.Karmanom = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.Karmanom = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.Karmanom,
            },
            new ModOption(ctx)
            {
                InternalName = "music_stella_wao",
                Name = "Wiping All Out (Satella remix)",
                Authors = [Author.Stella],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.Sgdis = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.Sgdis = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.Sgdis,
            }
        ];
    }
}
