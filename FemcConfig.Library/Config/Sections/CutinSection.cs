﻿using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections;

public class CutinSection : ISection
{
    /// <summary>
    /// Section name. Sets the text that appears on the side and title of page.
    /// </summary>
    public string Name { get; } = "Cutin";

    /// <summary>
    /// Section category, such as 2D, 3D, Audio, etc.
    /// </summary>
    public SectionCategory Category { get; } = SectionCategory.TwoD;

    /// <summary>
    /// Contains all the options that appear in the section.
    /// Set it in the constructor below.
    /// </summary>
    public ModOption[] Options { get; }

    public CutinSection(AppService app)
    {
        var ctx = app.GetContext();

        // Set all the options available.
        this.Options =
        [
            new ModOption(ctx)
            {
                InternalName = "cutin_berrycha",
                Authors = [Author.Berrycha],
                Enable = ctx => ctx.ModConfig.Settings.CutinTrue = Models.ReloadedModConfig.CutinType.berrycha,
                IsEnabledFunc = ctx => ctx.ModConfig.Settings.CutinTrue == Models.ReloadedModConfig.CutinType.berrycha,
            },
            new ModOption(ctx)
            {
                InternalName = "cutin_ely_pat",
                Authors = [Author.Ely, Author.PatMandDX],
                Enable = ctx => ctx.ModConfig.Settings.CutinTrue = Models.ReloadedModConfig.CutinType.ElyandPatmandx,
                IsEnabledFunc = ctx => ctx.ModConfig.Settings.CutinTrue == Models.ReloadedModConfig.CutinType.ElyandPatmandx,
            },
        ];
    }
}