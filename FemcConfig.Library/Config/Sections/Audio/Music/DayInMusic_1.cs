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
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.Timeschool = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.Timeschool = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.Timeschool,
            },
            new ModOption(ctx)
            {
                InternalName = "music_gabi_time",
                Name = "Time (GabiShy Remix)",
                Authors = [Author.GabiShy, Author.Mosq],
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.Gabitimeschool = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.Gabitimeschool = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.Gabitimeschool,
            },
            new ModOption(ctx)
            {
                InternalName = "music_atlus_beclose",
                Name = "Want to Be Close (Reload)",
                Authors = [Author.Atlus],
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.Wantclose = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.Wantclose = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.Wantclose,
            },
        ];
    }
}
