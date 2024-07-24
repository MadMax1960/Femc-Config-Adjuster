using FemcConfig.Library.Config.Options;
namespace FemcConfig.Library.Config.Sections.Audio.Music;

public class DayOutMusic_1 : ISection
{
    public string Name { get; } = "Daytime Music (Outside) 1";

    public string Description { get; } = "Music used outside of school before September.";

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
                Enable = ctx => ctx.ModConfig.Settings.Dayouttrue1 = Models.ReloadedModConfig.dayoutmusic1.WayOfLifeByMosq,
                IsEnabledFunc = ctx => ctx.ModConfig.Settings.Dayouttrue1 == Models.ReloadedModConfig.dayoutmusic1.WayOfLifeByMosq,
            },
            new ModOption(ctx)
            {
                InternalName = "music_whenthemoon",
                Name = "When the Moon's Reaching Out Stars (Reload)",
                Authors = [Author.Atlus],
                Enable = ctx => ctx.ModConfig.Settings.Dayouttrue1 = Models.ReloadedModConfig.dayoutmusic1.WhenTheMoonsReachingOutStarsReload,
                IsEnabledFunc = ctx => ctx.ModConfig.Settings.Dayouttrue1 == Models.ReloadedModConfig.dayoutmusic1.WhenTheMoonsReachingOutStarsReload,
            },
        ];
    }
}
