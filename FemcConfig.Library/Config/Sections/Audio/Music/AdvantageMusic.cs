using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections;

public class AdvantageMusicSection : ISection
{
    /// <summary>
    /// Section name. Sets the text that appears on the side and title of page.
    /// </summary>
    public string Name { get; } = Localisation.LocalisationResources.Resources.Advantage_Battle_Music;

    public string Description { get; } = Localisation.LocalisationResources.Resources.AdvantageDesc;

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
                Enable = (ctx) => ctx.FemcConfig.Settings.ItGoingDown = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.ItGoingDown = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.ItGoingDown,
            },
            new ModOption(ctx)
            {
                InternalName = "music_jen_ign",
                Name = "It's Going Down Now (Jen Remix)",
                Authors = [Author.Jen],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.JenAdv = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.JenAdv = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.JenAdv,
            },
           new ModOption(ctx)
            {
                InternalName = "music_mosq_ptr",
                Name = "Pull the Trigger -Reload-",
                Authors = [Author.Mosq],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.MosqAdv = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.MosqAdv = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.MosqAdv,
            },
           new ModOption(ctx)
            {
                InternalName = "music_karma_ptr",
                Name = "Pull the Trigger (P3P Arrange)",
                Authors = [Author.Karma],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.KarmaAdv = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.KarmaAdv = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.KarmaAdv,
            },
            new ModOption(ctx)
            {
                InternalName = "music_eidie_ptr",
                Name = "Pull the Trigger (EidieK87 Remix)",
                Authors = [Author.EidieK87],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.EidAdv = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.EidAdv = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.EidAdv,
            }
        ];
    }
}
