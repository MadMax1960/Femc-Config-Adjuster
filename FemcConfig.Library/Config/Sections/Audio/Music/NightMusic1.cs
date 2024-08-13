using FemcConfig.Library.Config.Options;
namespace FemcConfig.Library.Config.Sections.Audio.Music;

public class NightMusic_1 : ISection
{
    public string Name { get; } = "Night Music (Outside) 1";

    public string Description { get; } = "Music used at night outside the dorm before September.";

    public SectionCategory Category { get; } = SectionCategory.Audio;

    public ModOption[] Options { get; }

    public NightMusic_1(AppService app)
    {
        var ctx = app.GetContext();
        this.Options =
        [
            new ModOption(ctx)
            {
                InternalName = "music_mosq_nighttime",
                Name = "Time -Night Version (Mosq Remix)",
                Authors = [Author.Mosq],
                Enable = ctx => ctx.FemcConfig.Settings.Nighttrue1 = Models.FemcModConfig.nightmusic1.TimeNightVersionByMosq,
                IsEnabledFunc = ctx => ctx.FemcConfig.Settings.Nighttrue1 == Models.FemcModConfig.nightmusic1.TimeNightVersionByMosq,
            },
            new ModOption(ctx)
            {
                InternalName = "music_gabi_nighttime",
                Name = "Time -Night Version (GabiShy Remix)",
                Authors = [Author.GabiShy, Author.Mosq],
                Enable = ctx => ctx.FemcConfig.Settings.Nighttrue1 = Models.FemcModConfig.nightmusic1.TimeNightByMosqGabiVer,
                IsEnabledFunc = ctx => ctx.FemcConfig.Settings.Nighttrue1 == Models.FemcModConfig.nightmusic1.TimeNightByMosqGabiVer,
            },
            new ModOption(ctx)
            {
                InternalName = "music_mineformer_midnight",
                Name = "Midnight Reverie",
                Authors = [Author.Mineformer],
                Enable = ctx => ctx.FemcConfig.Settings.Nighttrue1 = Models.FemcModConfig.nightmusic1.MidnightReverieByMineformer,
                IsEnabledFunc = ctx => ctx.FemcConfig.Settings.Nighttrue1 == Models.FemcModConfig.nightmusic1.MidnightReverieByMineformer,
            },
            new ModOption(ctx)
            {
                InternalName = "music_mosq_nightwanderer",
                Name = "Night Wanderer",
                Authors = [Author.Mosq],
                Enable = ctx => ctx.FemcConfig.Settings.Nighttrue1 = Models.FemcModConfig.nightmusic1.NightWanderer,
                IsEnabledFunc = ctx => ctx.FemcConfig.Settings.Nighttrue1 == Models.FemcModConfig.nightmusic1.NightWanderer,
            },
            new ModOption(ctx)
            {
                InternalName = "music_color_your_night",
                Name = "Color Your Night (Reload)",
                Authors = [Author.Atlus],
                Enable = ctx => ctx.FemcConfig.Settings.Nighttrue1 = Models.FemcModConfig.nightmusic1.ColorYourNightReload,
                IsEnabledFunc = ctx => ctx.FemcConfig.Settings.Nighttrue1 == Models.FemcModConfig.nightmusic1.ColorYourNightReload,
            },
        ];
    }
}
