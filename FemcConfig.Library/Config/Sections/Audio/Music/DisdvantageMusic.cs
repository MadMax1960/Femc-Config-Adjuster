using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections;

public class DisadvantageMusicSection : ISection
{
    /// <summary>
    /// Section name. Sets the text that appears on the side and title of page.
    /// </summary>
    public string Name { get; } = "Disadvantage Battle Music";

    public string Description { get; } = "Select what music should be played when you are in a normal battle (Party Disadvantage). Multiple songs can be chosen for randomisation!";

    /// <summary>
    /// Section category, such as 2D, 3D, Audio, etc.
    /// </summary>
    public SectionCategory Category { get; } = SectionCategory.Audio;

    /// <summary>
    /// Contains all the options that appear in the section.
    /// Set it in the constructor below.
    /// </summary>
    public ModOption[] Options { get; }

    public DisadvantageMusicSection(AppService app)
    {
        var ctx = app.GetContext();

        // Set all the options available.
        this.Options =
        [
            // Example for a bool setting.
           new ModOption(ctx)
            {
                InternalName = "music_atlus_mst",
                Name = "Master of Tartarus -reload-",
                Authors = [Author.Atlus],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.Mastertar = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.Mastertar = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.Mastertar,
            },
           new ModOption(ctx)
            {
                InternalName = "music_mosq_dz",
                Name = "Danger Zone -Reload-",
                Authors = [Author.Mosq],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.Mosqdis = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.Mosqdis = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.Mosqdis,
            },
           new ModOption(ctx)
            {
                InternalName = "music_karma_dz",
                Name = "Danger Zone (P3P Cover)",
                Authors = [Author.Karma],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.Karmadis = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.Karmadis = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.Karmadis,
            },
            new ModOption(ctx)
            {
                InternalName = "music_stella_dz",
                Name = "Danger Zone (GillStudio remix)",
                Authors = [Author.GillStudio],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.Sgdis = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.Sgdis = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.Sgdis,
            },
            new ModOption(ctx)
            {
                InternalName = "music_eidie_dz",
                Name = "Danger Zone (EidieK87 Remix)",
                Authors = [Author.EidieK87],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.Eddis = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.Eddis = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.Eddis,
            }
        ];
    }
}
