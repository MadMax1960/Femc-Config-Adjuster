using FemcConfig.Library.Config.Options;
namespace FemcConfig.Library.Config.Sections.Audio.Music;

public class DayInMusic_2 : ISection
{
    public string Name { get; } = "Daytime Music (School) 2";

    public string Description { get; } = "Music used inside of school September onwards.";

    public SectionCategory Category { get; } = SectionCategory.Audio;

    public ModOption[] Options { get; }

    public DayInMusic_2(AppService app)
    {
        var ctx = app.GetContext();
        this.Options =
        [
            new ModOption(ctx)
            {
                InternalName = "music_mosq_sun",
                Name = "Sun (Mosq Remix)",
                Authors = [Author.Mosq],
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.Sun = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.Sun = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.Sun,
            },
            new ModOption(ctx)
            {
                InternalName = "music_mineformer_sun",
                Name = "Sun (Mineformer Remix)",
                Authors = [Author.Mineformer],
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.SunMForm = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.SunMForm = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.SunMForm,
            },
            new ModOption(ctx)
            {
                InternalName = "music_atlus_seasons",
                Name = "Changing Seasons (Reload)",
                Authors = [Author.Atlus],
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.Seasons = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.Seasons = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.Seasons,
            },
            new ModOption(ctx)
            {
                InternalName = "music_atlus_sun",
                Name = "Sun",
                Authors = [Author.Atlus],
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.SunP3P = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.SunP3P = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.SunP3P,
            },
        ];
    }
}
