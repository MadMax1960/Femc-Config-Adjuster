using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections.Music;

public class DisadvantageMusicSection : ISection
{
    /// <summary>
    /// Section name. Sets the text that appears on the side and title of page.
    /// </summary>
    public string Name { get; } = string.IsNullOrEmpty(Localisation.LocalisationResources.Resources.Disadvantage_Battle_Music)
    ? Localisation.LocalisationResources.Resources.ResourceManager.GetString("Disadvantage Battle Music", System.Globalization.CultureInfo.InvariantCulture) ?? string.Empty
    : Localisation.LocalisationResources.Resources.Disadvantage_Battle_Music;

    public string Description { get; } = string.IsNullOrEmpty(Localisation.LocalisationResources.Resources.DisadvantageDesc)
    ? Localisation.LocalisationResources.Resources.ResourceManager.GetString("DisadvantageDesc", System.Globalization.CultureInfo.InvariantCulture) ?? string.Empty
    : Localisation.LocalisationResources.Resources.DisadvantageDesc;

    /// <summary>
    /// Section category, such as 2D, 3D, Audio, etc.
    /// </summary>
    public SectionCategory Category { get; } = SectionCategory.Music;

    /// <summary>
    /// Contains all the options that appear in the section.
    /// Set it in the constructor below.
    /// </summary>
    public ModOption[] Options { get; }

    public DisadvantageMusicSection(AppService app)
    {
        var ctx = app.GetContext();

        // Set all the options available.
        Options =
        [
            // Example for a bool setting.
           new ModOption(ctx)
            {
                InternalName = "music_atlus_mst",
                Name = "Master of Tartarus -reload-",
                Authors = [Author.Atlus],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.MasterTar = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.MasterTar = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.MasterTar,
            },
           new ModOption(ctx)
            {
                InternalName = "music_atlus_dz",
                Name = "Danger Zone",
                Authors = [Author.Atlus],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.P3pDis = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.P3pDis = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.P3pDis,
            },
           new ModOption(ctx)
            {
                InternalName = "music_mosq_dz",
                Name = "Danger Zone -Reload-",
                Authors = [Author.Mosq],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.MosqDis = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.MosqDis = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.MosqDis,
            },
           new ModOption(ctx)
            {
                InternalName = "music_karma_dz",
                Name = "Danger Zone (P3P Cover)",
                Authors = [Author.Karma],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.KarmaDis = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.KarmaDis = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.KarmaDis,
            },
            new ModOption(ctx)
            {
                InternalName = "music_stella_dz",
                Name = "Danger Zone (GillStudio remix)",
                Authors = [Author.GillStudio],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.SgDis = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.SgDis = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.SgDis,
            },
            new ModOption(ctx)
            {
                InternalName = "music_restless_dz",
                Name = "Danger Zone (RestlessArtist Remix)",
                Authors = [Author.RestlessArtist],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.RestlessDis = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.RestlessDis = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.RestlessDis,
            }
        ];
    }
}
