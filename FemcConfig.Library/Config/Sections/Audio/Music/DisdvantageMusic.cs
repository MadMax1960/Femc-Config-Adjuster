﻿using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections;

public class DisadvantageMusicSection : ISection
{
    /// <summary>
    /// Section name. Sets the text that appears on the side and title of page.
    /// </summary>
    public string Name { get; } = Localisation.LocalisationResources.Resources.Disadvantage_Battle_Music;

    public string Description { get; } = Localisation.LocalisationResources.Resources.DisadvantageDesc;

    /// <summary>
    /// Section category, such as 2D, 3D, Audio, etc.
    /// </summary>
    public SectionCategory Category { get; } = SectionCategory.Audio;

    /// <summary>
    /// Contains all the options that appear in the section.
    /// Set it in the constructor below.
    /// </summary>
    public ModOption[] Options { get; }

    public DisadvantageMusicSection(AppService app)
    {
        var ctx = app.GetContext();

        // Set all the options available.
        this.Options =
        [
            // Example for a bool setting.
           new ModOption(ctx)
            {
                InternalName = "music_atlus_mst",
                Name = "Master of Tartarus -reload-",
                Authors = [Author.Atlus],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.MasterTar = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.MasterTar = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.MasterTar,
            },
           new ModOption(ctx)
            {
                InternalName = "music_atlus_dz",
                Name = "Danger Zone",
                Authors = [Author.Atlus],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.P3pDis = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.P3pDis = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.P3pDis,
            },
           new ModOption(ctx)
            {
                InternalName = "music_mosq_dz",
                Name = "Danger Zone -Reload-",
                Authors = [Author.Mosq],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.MosqDis = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.MosqDis = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.MosqDis,
            },
           new ModOption(ctx)
            {
                InternalName = "music_karma_dz",
                Name = "Danger Zone (P3P Cover)",
                Authors = [Author.Karma],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.KarmaDis = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.KarmaDis = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.KarmaDis,
            },
            new ModOption(ctx)
            {
                InternalName = "music_stella_dz",
                Name = "Danger Zone (GillStudio remix)",
                Authors = [Author.GillStudio],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.SgDis = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.SgDis = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.SgDis,
            },
            new ModOption(ctx)
            {
                InternalName = "music_eidie_dz",
                Name = "Danger Zone (EidieK87 Remix)",
                Authors = [Author.EidieK87],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.EdDis = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.EdDis = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.EdDis,
            }
        ];
    }
}
