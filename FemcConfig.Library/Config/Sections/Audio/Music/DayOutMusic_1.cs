using FemcConfig.Library.Config.Options;
namespace FemcConfig.Library.Config.Sections.Audio.Music;

public class DayOutMusic_1 : ISection
{
    public string Name { get; } = Localisation.LocalisationResources.Resources.Daytime_Outside_Music;

    public string Description { get; } = Localisation.LocalisationResources.Resources.DayOutMusic1Desc;

    public SectionCategory Category { get; } = SectionCategory.Audio;

    public ModOption[] Options { get; }

    public DayOutMusic_1(AppService app)
    {
        var ctx = app.GetContext();
        this.Options =
        [
            new ModOption(ctx)
            {
                InternalName = "music_mosq_wayoflife",
                Name = "Way of Life (Mosq Remix)",
                Authors = [Author.Mosq],
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.WayOfLife = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.WayOfLife = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.WayOfLife,
            },
            new ModOption(ctx)
            {
                InternalName = "music_jen_wayoflife",
                Name = "Way of Life (Jen Remix)",
                Authors = [Author.Jen],
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.WayOfLifeJen = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.WayOfLifeJen = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.WayOfLifeJen,
            },
            new ModOption(ctx)
            {
                InternalName = "music_atlus_whenthemoon",
                Name = "When the Moon's Reaching Out Stars (Reload)",
                Authors = [Author.Atlus],
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.Moon = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.Moon = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.Moon,
            },
            new ModOption(ctx)
            {
                InternalName = "music_atlus_wayoflife",
                Name = "A Way of Life",
                Authors = [Author.Atlus],
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.WayOfLifeP3P = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.WayOfLifeP3P = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.WayOfLifeP3P,
            },
            new ModOption(ctx)
            {
                InternalName = "music_atlus_wayofliferemix",
                Name = "A Way of Life -Deep inside my mind Remix-",
                Authors = [Author.Atlus],
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.WayOfLifeRemix = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.WayOfLifeRemix = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.WayOfLifeRemix,
            },
        ];
    }
}
