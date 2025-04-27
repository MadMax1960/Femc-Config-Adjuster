using FemcConfig.Library.Config.Options;
namespace FemcConfig.Library.Config.Sections.Audio.Music;

public class DayInMusic_1 : ISection
{
    public string Name { get; } = Localisation.LocalisationResources.Resources.Daytime_School_Music__Phase_1_;

    public string Description { get; } = Localisation.LocalisationResources.Resources.DayInMusic1Desc;

    public SectionCategory Category { get; } = SectionCategory.Audio;

    public ModOption[] Options { get; }

    public DayInMusic_1(AppService app)
    {
        var ctx = app.GetContext();
        this.Options =
        [
            new ModOption(ctx)
            {
                InternalName = "music_mosq_time",
                Name = "Time (Mosq Remix)",
                Authors = [Author.Mosq],
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.TimeSchool = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.TimeSchool = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.TimeSchool,
            },
            new ModOption(ctx)
            {
                InternalName = "music_gabi_time",
                Name = "Time (GabiShy Remix)",
                Authors = [Author.GabiShy, Author.Mosq],
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.GabiTimeSchool = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.GabiTimeSchool = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.GabiTimeSchool,
            },
            new ModOption(ctx)
            {
                InternalName = "music_atlus_beclose",
                Name = "Want to Be Close (Reload)",
                Authors = [Author.Atlus],
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.WantClose = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.WantClose = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.WantClose,
            },
            new ModOption(ctx)
            {
                InternalName = "music_atlus_time",
                Name = "Time",
                Authors = [Author.Atlus],
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.TimeSchoolP3P = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.TimeSchoolP3P = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.TimeSchoolP3P,
            },
        ];
    }
}
