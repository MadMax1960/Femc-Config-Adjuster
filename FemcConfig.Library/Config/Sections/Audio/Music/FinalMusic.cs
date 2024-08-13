﻿using FemcConfig.Library.Config.Options;
namespace FemcConfig.Library.Config.Sections.Audio.Music;

public class FinalMusic : ISection
{
    public string Name { get; } = "Final Battle Music";

    public string Description { get; } = "Music used during the final battle with Nyx's core.";

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
                Enable = ctx => ctx.FemcConfig.Settings.Finalmusictrue = Models.FemcModConfig.finalmusic.BurnMyDreadReload,
                IsEnabledFunc = ctx => ctx.FemcConfig.Settings.Finalmusictrue == Models.FemcModConfig.finalmusic.BurnMyDreadReload,
            },
            new ModOption(ctx)
            {
                InternalName = "music_karma_soul",
                Name = "Soul Phrase -Final Battle",
                Authors = [Author.Karma],
                Enable = ctx => ctx.FemcConfig.Settings.Finalmusictrue = Models.FemcModConfig.finalmusic.SoulPhraseByKarma,
                IsEnabledFunc = ctx => ctx.FemcConfig.Settings.Finalmusictrue == Models.FemcModConfig.finalmusic.SoulPhraseByKarma,
            },
        ];
    }
}