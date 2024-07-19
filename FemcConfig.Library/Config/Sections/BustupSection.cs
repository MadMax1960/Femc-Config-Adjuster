using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections;

public class BustupSection : ISection
{
    public string Name { get; } = "Bustup";

    public SectionCategory Category { get; } = SectionCategory.TwoD;

    public ModOption[] Options { get; }

    public BustupSection(AppService app)
    {
        var ctx = app.GetContext();
        this.Options =
        [
            new ModOption(ctx)
            {
                InternalName = "bustup_neptune",
                Authors = [Author.Neptune],
                Enable = (ctx) => ctx.ModConfig.Settings.BustupTrue = Models.ReloadedModConfig.BustupType.Neptune,
                IsEnabledFunc = (ctx) => ctx.ModConfig.Settings.BustupTrue == Models.ReloadedModConfig.BustupType.Neptune,
            },
            new ModOption(ctx)
            {
                InternalName = "bustup_ely",
                Authors = [Author.Ely],
                Enable = (ctx) => ctx.ModConfig.Settings.BustupTrue = Models.ReloadedModConfig.BustupType.Ely,
                IsEnabledFunc = (ctx) => ctx.ModConfig.Settings.BustupTrue == Models.ReloadedModConfig.BustupType.Ely,
            },
            new ModOption(ctx)
            {
                InternalName = "bustup_esa",
                Authors = [Author.Esa],
                Enable = (ctx) => ctx.ModConfig.Settings.BustupTrue = Models.ReloadedModConfig.BustupType.Esa,
                IsEnabledFunc = (ctx) => ctx.ModConfig.Settings.BustupTrue == Models.ReloadedModConfig.BustupType.Esa,
            },
            new ModOption(ctx)
            {
                InternalName = "bustup_betina",
                Authors = [Author.Betina],
                Enable = (ctx) => ctx.ModConfig.Settings.BustupTrue = Models.ReloadedModConfig.BustupType.Betina,
                IsEnabledFunc = (ctx) => ctx.ModConfig.Settings.BustupTrue == Models.ReloadedModConfig.BustupType.Betina,
            },
            new ModOption(ctx)
            {
                InternalName = "bustup_anniversary",
                Authors = [Author.Anniversary],
                Enable = (ctx) => ctx.ModConfig.Settings.BustupTrue = Models.ReloadedModConfig.BustupType.Anniversary,
                IsEnabledFunc = (ctx) => ctx.ModConfig.Settings.BustupTrue == Models.ReloadedModConfig.BustupType.Anniversary,
            },
            new ModOption(ctx)
            {
                InternalName = "bustup_justblue",
                Authors = [Author.JustBlue],
                Enable = (ctx) => ctx.ModConfig.Settings.BustupTrue = Models.ReloadedModConfig.BustupType.JustBlue,
                IsEnabledFunc = (ctx) => ctx.ModConfig.Settings.BustupTrue == Models.ReloadedModConfig.BustupType.JustBlue,
            },
            new ModOption(ctx)
            {
                InternalName = "bustup_sav",
                Authors = [Author.Sav],
                Enable = (ctx) => ctx.ModConfig.Settings.BustupTrue = Models.ReloadedModConfig.BustupType.Sav,
                IsEnabledFunc = (ctx) => ctx.ModConfig.Settings.BustupTrue == Models.ReloadedModConfig.BustupType.Sav,
            },
            new ModOption(ctx)
            {
                InternalName = "bustup_doodled",
                Authors = [Author.Doodled],
                Enable = (ctx) => ctx.ModConfig.Settings.BustupTrue = Models.ReloadedModConfig.BustupType.Doodled,
                IsEnabledFunc = (ctx) => ctx.ModConfig.Settings.BustupTrue == Models.ReloadedModConfig.BustupType.Doodled,
            },
            new ModOption(ctx)
            {
                InternalName = "bustup_ronald",
                Authors = [Author.Ronald],
                Enable = (ctx) => ctx.ModConfig.Settings.BustupTrue = Models.ReloadedModConfig.BustupType.RonaldReagan,
                IsEnabledFunc = (ctx) => ctx.ModConfig.Settings.BustupTrue == Models.ReloadedModConfig.BustupType.RonaldReagan,
            },
            new ModOption(ctx)
            {
                InternalName = "bustup_elyalt",
                Name = "Ely (Alt)",
                Authors = [Author.Ely],
                Enable = (ctx) => ctx.ModConfig.Settings.BustupTrue = Models.ReloadedModConfig.BustupType.ElyAlt,
                IsEnabledFunc = (ctx) => ctx.ModConfig.Settings.BustupTrue == Models.ReloadedModConfig.BustupType.ElyAlt,
            },
            new ModOption(ctx)
            {
                InternalName = "bustup_yuunagi",
                Authors = [Author.Yuunagi],
                Enable = (ctx) => ctx.ModConfig.Settings.BustupTrue = Models.ReloadedModConfig.BustupType.Yuunagi,
                IsEnabledFunc = (ctx) => ctx.ModConfig.Settings.BustupTrue == Models.ReloadedModConfig.BustupType.Yuunagi,
            },
        ];
    }
}
