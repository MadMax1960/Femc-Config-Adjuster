using FemcConfig.Library.Config.Options;
namespace FemcConfig.Library.Config.Sections.Audio.Music;

public class FinalMusic : ISection
{
    public string Name { get; } = Localisation.LocalisationResources.Resources.Final_Battle_Music;

    public string Description { get; } = Localisation.LocalisationResources.Resources.FinalDesc;

    public SectionCategory Category { get; } = SectionCategory.Audio;

    public ModOption[] Options { get; }

    public FinalMusic(AppService app)
    {
        var ctx = app.GetContext();
        this.Options =
        [
            new ModOption(ctx)
            {
                InternalName = "music_atlus_bmd",
                Name = "Burn My Dread -Last Battle (Reload)",
                Authors = [Author.Atlus],
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.BMD = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.BMD = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.BMD,
            },
            new ModOption(ctx)
            {
                InternalName = "music_karma_soul",
                Name = "Soul Phrase -Final Battle",
                Authors = [Author.Karma],
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.SoulPK = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.SoulPK = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.SoulPK,
            },
        ];
    }
}
