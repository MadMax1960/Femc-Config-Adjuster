﻿using FemcConfig.Library.Config.Options;
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
                Enable = ctx => ctx.FemcConfig.Settings.Dayintrue2 = Models.FemcModConfig.dayinmusic2.SunByMosq,
                IsEnabledFunc = ctx => ctx.FemcConfig.Settings.Dayintrue2 == Models.FemcModConfig.dayinmusic2.SunByMosq,
            },
            new ModOption(ctx)
            {
                InternalName = "music_atlus_seasons",
                Name = "Changing Seasons (Reload)",
                Authors = [Author.Atlus],
                Enable = ctx => ctx.FemcConfig.Settings.Dayintrue2 = Models.FemcModConfig.dayinmusic2.ChangingSeasonsReload,
                IsEnabledFunc = ctx => ctx.FemcConfig.Settings.Dayintrue2 == Models.FemcModConfig.dayinmusic2.ChangingSeasonsReload,
            },
        ];
    }
}
