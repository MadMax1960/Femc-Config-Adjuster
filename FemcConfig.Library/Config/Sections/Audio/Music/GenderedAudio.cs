using FemcConfig.Library.Config.Options;
namespace FemcConfig.Library.Config.Sections.Audio.Music;

public class GenderedAudioMusic : ISection
{
    public string Name { get; } = "Social Link Music";

    public string Description { get; } = "Music used during social link events.";

    public SectionCategory Category { get; } = SectionCategory.Audio;

    public ModOption[] Options { get; }

    public GenderedAudioMusic(AppService app)
    {
        var ctx = app.GetContext();
        this.Options =
        [
            new ModOption(ctx)
            {
                InternalName = "audio_giowni_gender",
                Name = "Giowni's Gendered Audio",
                Authors = [Author.Femc],
                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.Bluehairandpronounce = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.Bluehairandpronounce = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.Bluehairandpronounce,
            },
        ];
    }
}
