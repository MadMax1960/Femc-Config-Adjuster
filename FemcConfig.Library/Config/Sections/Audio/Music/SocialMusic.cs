using FemcConfig.Library.Config.Options;
namespace FemcConfig.Library.Config.Sections.Audio.Music;

public class SocialMusic : ISection
{
    public string Name { get; } = "Social Link Music";

    public string Description { get; } = "Music used during social link events.";

    public SectionCategory Category { get; } = SectionCategory.Audio;

    public ModOption[] Options { get; }

    public SocialMusic(AppService app)
    {
        var ctx = app.GetContext();
        this.Options =
        [
            new ModOption(ctx)
            {
                InternalName = "music_atlus_joy",
                Name = "Joy (Reload)",
                Authors = [Author.Atlus],
                Enable = ctx => ctx.FemcConfig.Settings.Socialmusictrue = Models.FemcModConfig.socialmusic.JoyReload,
                IsEnabledFunc = ctx => ctx.FemcConfig.Settings.Socialmusictrue == Models.FemcModConfig.socialmusic.JoyReload,
            },
            new ModOption(ctx)
            {
                InternalName = "music_mosq_afterschool",
                Name = "After School",
                Authors = [Author.Mosq],
                Enable = ctx => ctx.FemcConfig.Settings.Socialmusictrue = Models.FemcModConfig.socialmusic.AfterSchoolByMosq,
                IsEnabledFunc = ctx => ctx.FemcConfig.Settings.Socialmusictrue == Models.FemcModConfig.socialmusic.AfterSchoolByMosq, 
            }
        ];
    }
}
