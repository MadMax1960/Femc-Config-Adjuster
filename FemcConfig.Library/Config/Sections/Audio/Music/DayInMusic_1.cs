using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections.Audio.Music;

public class DayInMusic_1 : ISection
{
    public string Name { get; } = "Daytime Music (School): April to August";

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
                Enable = ctx => ctx.ModConfig.Settings.Dayintrue1 = Models.ReloadedModConfig.dayinmusic1.TimeByMosq,
                IsEnabledFunc = ctx => ctx.ModConfig.Settings.Dayintrue1 == Models.ReloadedModConfig.dayinmusic1.TimeByMosq,
            },
            new ModOption(ctx)
            {
                InternalName = "music_atlus_beclose",
                Name = "Want to Be Close (Reload)",
                Authors = [Author.Atlus],
                Enable = ctx => ctx.ModConfig.Settings.Dayintrue1 = Models.ReloadedModConfig.dayinmusic1.WantToBeCloseReload,
                IsEnabledFunc = ctx => ctx.ModConfig.Settings.Dayintrue1 == Models.ReloadedModConfig.dayinmusic1.WantToBeCloseReload,
            },
        ];
    }
}
