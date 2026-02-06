using FemcConfig.Library.Config.Options;
namespace FemcConfig.Library.Config.Sections.Audio;

public class KotoneVoice : ISection
{
    public string Name { get; } = Localisation.LocalisationResources.Resources.Kotone_Voice;

    public string Description { get; } = Localisation.LocalisationResources.Resources.KotoneVoiceDesc;

    public SectionCategory Category { get; } = SectionCategory.Audio;

    public ModOption[] Options { get; }

    public KotoneVoice(AppService app)
    {
        var ctx = app.GetContext();
        Options =
        [
            new ModOption(ctx)
            {
                InternalName = "voice_mellodi",
                Name = "Mellodi",
                Authors = [Author.Mellodi],
                Enable = (ctx) => ctx.FemcConfig.Settings.VoiceTrue = Models.FemcModConfig.VoiceType.Mellodi,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.VoiceTrue == Models.FemcModConfig.VoiceType.Mellodi,
            },
            new ModOption(ctx)
            {
                InternalName = "audio_mellodi_silly",
                Name = "Mellodi (Silly)",
                Authors = [Author.Mellodi],
                Enable = (ctx) => ctx.FemcConfig.Settings.VoiceTrue = Models.FemcModConfig.VoiceType.MellodiSilly,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.VoiceTrue == Models.FemcModConfig.VoiceType.MellodiSilly,
            },
            new ModOption(ctx)
            {
                InternalName = "voice_lantana",
                Name = "Lantana",
                Authors = [Author.Lantana],
                Enable = (ctx) => ctx.FemcConfig.Settings.VoiceTrue = Models.FemcModConfig.VoiceType.Lantana,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.VoiceTrue == Models.FemcModConfig.VoiceType.Lantana,
            },
            new ModOption(ctx)
            {
                InternalName = "audio_japanese",
                Name = "Japanese Kotone",
                Authors = [Author.Femc], // oml who is the jpn va i cant find it anywhere
                Enable = (ctx) => ctx.FemcConfig.Settings.VoiceTrue = Models.FemcModConfig.VoiceType.Japanese,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.VoiceTrue == Models.FemcModConfig.VoiceType.Japanese,
            },
        ];
    }
}
