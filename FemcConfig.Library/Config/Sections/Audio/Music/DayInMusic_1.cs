using FemcConfig.Library.Config.Options;
namespace FemcConfig.Library.Config.Sections.Audio.Music;

public class DayInMusic_1 : ISection
{
    public string Name { get; } = "Daytime Music (School) 1";

    public string Description { get; } = "Music used inside of school between April and August.";

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
                Enable = ctx => ctx.FemcConfig.Settings.Dayintrue1 = Models.FemcModConfig.dayinmusic1.TimeByMosq,
                IsEnabledFunc = ctx => ctx.FemcConfig.Settings.Dayintrue1 == Models.FemcModConfig.dayinmusic1.TimeByMosq,
            },
            new ModOption(ctx)
            {
                InternalName = "music_gabi_time",
                Name = "Time (GabiShy Remix)",
                Authors = [Author.GabiShy, Author.Mosq],
                Enable = ctx => ctx.FemcConfig.Settings.Dayintrue1 = Models.FemcModConfig.dayinmusic1.TimeByMosqGabiVer,
                IsEnabledFunc = ctx => ctx.FemcConfig.Settings.Dayintrue1 == Models.FemcModConfig.dayinmusic1.TimeByMosqGabiVer,
            },
            new ModOption(ctx)
            {
                InternalName = "music_atlus_beclose",
                Name = "Want to Be Close (Reload)",
                Authors = [Author.Atlus],
                Enable = ctx => ctx.FemcConfig.Settings.Dayintrue1 = Models.FemcModConfig.dayinmusic1.WantToBeCloseReload,
                IsEnabledFunc = ctx => ctx.FemcConfig.Settings.Dayintrue1 == Models.FemcModConfig.dayinmusic1.WantToBeCloseReload,
            },
        ];
    }
}
