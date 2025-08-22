using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections;

public class NormalMusicSection : ISection
{
    /// <summary>
    /// Section name. Sets the text that appears on the side and title of page.
    /// </summary>
    public string Name { get; } = Localisation.LocalisationResources.Resources.Normal_Battle_Music;

    public string Description { get; } = Localisation.LocalisationResources.Resources.NormalDesc;

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
                Enable = (ctx) => ctx.FemcConfig.Settings.MassDes = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.MassDes = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.MassDes,
            },
           new ModOption(ctx)
            {
                InternalName = "music_atlus_wao",
                Name = "Wiping All Out",
                Authors = [Author.Atlus],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.P3pNom = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.P3pNom = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.P3pNom,
            },
           new ModOption(ctx)
            {
                InternalName = "music_mosq_wao",
                Name = "Wiping All Out -Reload-",
                Authors = [Author.Mosq],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.MosqNom = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.MosqNom = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.MosqNom,
            },
           new ModOption(ctx)
            {
                InternalName = "music_karma_wao",
                Name = "Wiping All Out -Reloaded- (P3P Cover)",
                Authors = [Author.Karma],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.KarmaNom = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.KarmaNom = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.KarmaNom,
            },
            new ModOption(ctx)
            {
                InternalName = "music_stella_wao",
                Name = "Wiping All Out (Satella remix)",
                Authors = [Author.Stella],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.SgDis = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.SgDis = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.SgDis,
            },
            new ModOption(ctx)
            {
                InternalName = "music_atlus_wao_p3d",
                Name = "Wiping All Out ATLUS Kozuka Remix",
                Authors = [Author.Atlus],
                Enable = (ctx) => ctx.FemcConfig.Settings.P3MidNomF = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.P3MidNomF = false,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.P3MidNomF,
            }
        ];
    }
}
