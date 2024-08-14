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
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.Wayoflife = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.Wayoflife = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.Wayoflife,
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
        ];
    }
}
