using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections;

public class BustupSection : ISection
{
    public string Name { get; } = "Bustup";
    public string Description { get; } = "Character portrait used in textboxes.";

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
                Enable = (ctx) => ctx.FemcConfig.Settings.BustupTrue = Models.FemcModConfig.BustupType.Neptune,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.BustupTrue == Models.FemcModConfig.BustupType.Neptune,
            },
            new ModOption(ctx)
            {
                InternalName = "bustup_ely",
                Authors = [Author.Ely],
                Enable = (ctx) => ctx.FemcConfig.Settings.BustupTrue = Models.FemcModConfig.BustupType.Ely,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.BustupTrue == Models.FemcModConfig.BustupType.Ely,
            },
            new ModOption(ctx)
            {
                InternalName = "bustup_esa",
                Authors = [Author.Esa],
                Enable = (ctx) => ctx.FemcConfig.Settings.BustupTrue = Models.FemcModConfig.BustupType.Esa,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.BustupTrue == Models.FemcModConfig.BustupType.Esa,
            },
            new ModOption(ctx)
            {
                InternalName = "bustup_betina",
                Authors = [Author.Betina],
                Enable = (ctx) => ctx.FemcConfig.Settings.BustupTrue = Models.FemcModConfig.BustupType.Betina,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.BustupTrue == Models.FemcModConfig.BustupType.Betina,
            },
            new ModOption(ctx)
            {
                InternalName = "bustup_anniversary",
                Authors = [Author.Anniversary],
                Enable = (ctx) => ctx.FemcConfig.Settings.BustupTrue = Models.FemcModConfig.BustupType.Anniversary,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.BustupTrue == Models.FemcModConfig.BustupType.Anniversary,
            },
            new ModOption(ctx)
            {
                InternalName = "bustup_justblue",
                Authors = [Author.JustBlue],
                Enable = (ctx) => ctx.FemcConfig.Settings.BustupTrue = Models.FemcModConfig.BustupType.JustBlue,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.BustupTrue == Models.FemcModConfig.BustupType.JustBlue,
            },
            new ModOption(ctx)
            {
                InternalName = "bustup_sav",
                Authors = [Author.Sav],
                Enable = (ctx) => ctx.FemcConfig.Settings.BustupTrue = Models.FemcModConfig.BustupType.Sav,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.BustupTrue == Models.FemcModConfig.BustupType.Sav,
            },
            new ModOption(ctx)
            {
                InternalName = "bustup_doodled",
                Authors = [Author.Doodled],
                Enable = (ctx) => ctx.FemcConfig.Settings.BustupTrue = Models.FemcModConfig.BustupType.Doodled,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.BustupTrue == Models.FemcModConfig.BustupType.Doodled,
            },
            new ModOption(ctx)
            {
                InternalName = "bustup_ronald",
                Authors = [Author.Ronald],
                Enable = (ctx) => ctx.FemcConfig.Settings.BustupTrue = Models.FemcModConfig.BustupType.RonaldReagan,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.BustupTrue == Models.FemcModConfig.BustupType.RonaldReagan,
            },
            new ModOption(ctx)
            {
                InternalName = "bustup_elyalt",
                Name = "Ely (Alt)",
                Authors = [Author.Ely],
                Enable = (ctx) => ctx.FemcConfig.Settings.BustupTrue = Models.FemcModConfig.BustupType.ElyAlt,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.BustupTrue == Models.FemcModConfig.BustupType.ElyAlt,
            },
            new ModOption(ctx)
            {
                InternalName = "bustup_yuunagi",
                Authors = [Author.Yuunagi],
                Enable = (ctx) => ctx.FemcConfig.Settings.BustupTrue = Models.FemcModConfig.BustupType.Yuunagi,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.BustupTrue == Models.FemcModConfig.BustupType.Yuunagi,
            },
			new ModOption(ctx)
			{
				InternalName = "bustup_ghostedtoast",
				Authors = [Author.GhostedToast],
				Enable = (ctx) => ctx.FemcConfig.Settings.BustupTrue = Models.FemcModConfig.BustupType.ghostedtoast,
				IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.BustupTrue == Models.FemcModConfig.BustupType.ghostedtoast,
			},
			new ModOption(ctx)
			{
				InternalName = "bustup_axolotl",
				Authors = [Author.Axolotl],
				Enable = (ctx) => ctx.FemcConfig.Settings.BustupTrue = Models.FemcModConfig.BustupType.axolotl,
				IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.BustupTrue == Models.FemcModConfig.BustupType.axolotl,
			},

			new ModOption(ctx)
			{
				InternalName = "bustup_cielbell",
				Authors = [Author.Cielbell],
				Enable = (ctx) => ctx.FemcConfig.Settings.BustupTrue = Models.FemcModConfig.BustupType.cielbell,
				IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.BustupTrue == Models.FemcModConfig.BustupType.cielbell,
			},

		];
    }
}
