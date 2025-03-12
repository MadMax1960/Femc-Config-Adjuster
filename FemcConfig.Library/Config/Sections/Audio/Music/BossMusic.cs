using FemcConfig.Library.Config.Options;
namespace FemcConfig.Library.Config.Sections.Audio.Music;

public class BossMusic : ISection
{
    public string Name { get; } = Localisation.LocalisationResources.Resources.Boss_Battle_Music;

    public string Description { get; } = Localisation.LocalisationResources.Resources.BossDesc;

    public SectionCategory Category { get; } = SectionCategory.Audio;

    public ModOption[] Options { get; }

    public BossMusic(AppService app)
    {
        var ctx = app.GetContext();
        this.Options =
        [
            new ModOption(ctx)
            {
                InternalName = "music_atlus_ms",
                Name = "Master Of Shadow Reload",
                Authors = [Author.Atlus],
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.BMS = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.BMS = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.BMS,
            },
            new ModOption(ctx)
            {
                InternalName = "music_mosq_ms",
                Name = "Master Of Shadow Fate Mix",
                Authors = [Author.Mosq],
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.BMSF = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.BMSF = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.BMSF,
            },
        ];
    }
}
