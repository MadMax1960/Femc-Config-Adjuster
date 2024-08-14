using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections;

public class AdvantageMusicSection : ISection
{
    /// <summary>
    /// Section name. Sets the text that appears on the side and title of page.
    /// </summary>
    public string Name { get; } = "Advantage Battle Music";

    public string Description { get; } = "Select what music should be played when you are in a normal battle (Party Advantage). Multiple songs can be chosen for randomisation!";

    /// <summary>
    /// Section category, such as 2D, 3D, Audio, etc.
    /// </summary>
    public SectionCategory Category { get; } = SectionCategory.Audio;

    /// <summary>
    /// Contains all the options that appear in the section.
    /// Set it in the constructor below.
    /// </summary>
    public ModOption[] Options { get; }

    public AdvantageMusicSection(AppService app)
    {
        var ctx = app.GetContext();

        // Set all the options available.
        this.Options =
        [
            // Example for a bool setting.
           new ModOption(ctx)
            {
                InternalName = "music_atlus_ign",
                Name = "It's Going Down Now",
                Authors = [Author.Atlus],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.Itgoingdown = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.Itgoingdown = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.Itgoingdown,
            },
                       new ModOption(ctx)
            {
                InternalName = "music_mosq_ptr",
                Name = "Pull the Trigger -Reload-",
                Authors = [Author.Mosq],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.Mosqadv = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.Mosqadv = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.Mosqadv,
            },
           new ModOption(ctx)
            {
                InternalName = "music_karma_ptr",
                Name = "Pull the Trigger (P3P Arrange)",
                Authors = [Author.Karma],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.Karmaadv = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.Karmaadv = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.Karmaadv,
            },
            new ModOption(ctx)
            {
                InternalName = "music_eidie_ptr",
                Name = "Pull the Trigger (EidieK87 Remix)",
                Authors = [Author.EidieK87],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.Eidadv = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.Eidadv = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.Eidadv,
            },
        ];
    }
}
