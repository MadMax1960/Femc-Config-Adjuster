using FemcConfig.Library.Config.Options;
namespace FemcConfig.Library.Config.Sections.Music;

public class NightMusic_1 : ISection
{
    public string Name { get; } = Localisation.LocalisationResources.Resources.Night_Outside_Music;

    public string Description { get; } = Localisation.LocalisationResources.Resources.NightMusic1Desc;

    public SectionCategory Category { get; } = SectionCategory.Music;

    public ModOption[] Options { get; }

    public NightMusic_1(AppService app)
    {
        var ctx = app.GetContext();
        Options =
        [
            new ModOption(ctx)
            {
                InternalName = "music_mosq_nighttime",
                Name = "Time -Night Version (Mosq Remix)",
                Authors = [Author.Mosq],
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.FemNight = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.FemNight = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.FemNight,
            },
            new ModOption(ctx)
            {
                InternalName = "music_gabi_nighttime",
                Name = "Time -Night Version (GabiShy Remix)",
                Authors = [Author.GabiShy, Author.Mosq],
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.GabiFemNight = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.GabiFemNight = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.GabiFemNight,
            },
            new ModOption(ctx)
            {
                InternalName = "music_mineformer_midnight",
                Name = "Midnight Reverie",
                Authors = [Author.Mineformer],
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.MidNight = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.MidNight = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.MidNight,
            },
            new ModOption(ctx)
            {
                InternalName = "music_mosq_nightwanderer",
                Name = "Night Wanderer",
                Authors = [Author.Mosq],
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.NightWand = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.NightWand = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.NightWand,
            },
            new ModOption(ctx)
            {
                InternalName = "music_atlus_color_your_night",
                Name = "Color Your Night (Reload)",
                Authors = [Author.Atlus],
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.ColNight = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.ColNight = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.ColNight,
            }
        ];
    }
}
