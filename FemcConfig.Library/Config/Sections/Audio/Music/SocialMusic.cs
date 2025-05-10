using FemcConfig.Library.Config.Options;
namespace FemcConfig.Library.Config.Sections.Audio.Music;

public class SocialMusic : ISection
{
    public string Name { get; } = Localisation.LocalisationResources.Resources.Social_Link_Music;

    public string Description { get; } = Localisation.LocalisationResources.Resources.SocialDesc;

    public SectionCategory Category { get; } = SectionCategory.Audio;

    public ModOption[] Options { get; }

    public SocialMusic(AppService app)
    {
        var ctx = app.GetContext();
        this.Options =
        [
            new ModOption(ctx)
            {
                InternalName = "music_atlus_joy",
                Name = "Joy (Reload)",
                Authors = [Author.Atlus],
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.Joy = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.Joy = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.Joy,
            },
            new ModOption(ctx)
            {
                InternalName = "music_atlus_afterschool",
                Name = "After School",
                Authors = [Author.Atlus],
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.AfterSchoolP3P = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.AfterSchoolP3P = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.AfterSchoolP3P,
            },
            new ModOption(ctx)
            {
                InternalName = "music_mosq_afterschool",
                Name = "After School",
                Authors = [Author.Mosq],
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.AfterSchool = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.AfterSchool = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.AfterSchool,
            }
        ];
    }
}
