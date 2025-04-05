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

			new ModOption(ctx)
			{
				InternalName = "bustup_Strelko",
				Authors = [Author.Strelko],
				Enable = (ctx) => ctx.FemcConfig.Settings.BustupTrue = Models.FemcModConfig.BustupType.Strelko,
				IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.BustupTrue == Models.FemcModConfig.BustupType.Strelko,
			},

			new ModOption(ctx)
			{
				InternalName = "bustup_gackt",
				Authors = [Author.Gacktenzo],
				Enable = (ctx) => ctx.FemcConfig.Settings.BustupTrue = Models.FemcModConfig.BustupType.gackt,
				IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.BustupTrue == Models.FemcModConfig.BustupType.gackt,
			},

			new ModOption(ctx)
			{
				InternalName = "bustup_Jackie",
				Authors = [Author.Jackie],
				Enable = (ctx) => ctx.FemcConfig.Settings.BustupTrue = Models.FemcModConfig.BustupType.Jackie,
				IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.BustupTrue == Models.FemcModConfig.BustupType.Jackie,
			},

			new ModOption(ctx)
			{
				InternalName = "bustup_Lisa",
				Authors = [Author.Lisa9388],
				Enable = (ctx) => ctx.FemcConfig.Settings.BustupTrue = Models.FemcModConfig.BustupType.Lisa,
				IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.BustupTrue == Models.FemcModConfig.BustupType.Lisa,
			},

			new ModOption(ctx)
			{
				InternalName = "bustup_BetaFemcByMae",
				Authors = [Author.Mae],
				Enable = (ctx) => ctx.FemcConfig.Settings.BustupTrue = Models.FemcModConfig.BustupType.BetaFemcByMae,
				IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.BustupTrue == Models.FemcModConfig.BustupType.BetaFemcByMae,
			},
            new ModOption(ctx)
            {
                InternalName = "bustup_chitu",
                Authors = [Author.Chitu],
                Enable = (ctx) => ctx.FemcConfig.Settings.BustupTrue = Models.FemcModConfig.BustupType.chitu,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.BustupTrue == Models.FemcModConfig.BustupType.chitu,
            },
            new ModOption(ctx)
            {
                InternalName = "bustup_angie",
                Authors = [Author.AngieDaGorl],
                Enable = (ctx) => ctx.FemcConfig.Settings.BustupTrue = Models.FemcModConfig.BustupType.AngieDaGorl,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.BustupTrue == Models.FemcModConfig.BustupType.AngieDaGorl,
            },
            new ModOption(ctx)
            {
                InternalName = "bustup_crezz",
                Authors = [Author.Crezzstar],
                Enable = (ctx) => ctx.FemcConfig.Settings.BustupTrue = Models.FemcModConfig.BustupType.crezzstar,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.BustupTrue == Models.FemcModConfig.BustupType.crezzstar,
            },
			new ModOption(ctx)
			{
				InternalName = "bustup_crezzalt",
                Name = "Crezz star (Alt)",
                Authors = [Author.Crezzstar],
				Enable = (ctx) => ctx.FemcConfig.Settings.BustupTrue = Models.FemcModConfig.BustupType.crezzstarAlt,
				IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.BustupTrue == Models.FemcModConfig.BustupType.crezzstarAlt,
			},
			new ModOption(ctx)
            {
                InternalName = "bustup_namiweiko",
                Authors = [Author.namiweiko],
                Enable = (ctx) => ctx.FemcConfig.Settings.BustupTrue = Models.FemcModConfig.BustupType.namiweiko,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.BustupTrue == Models.FemcModConfig.BustupType.namiweiko,
            },
			new ModOption(ctx)
			{
				InternalName = "bustup_shiosakana",
				Authors = [Author.Shiosakana],
				Enable = (ctx) => ctx.FemcConfig.Settings.BustupTrue = Models.FemcModConfig.BustupType.shiosakana,
				IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.BustupTrue == Models.FemcModConfig.BustupType.shiosakana,
			},
            new ModOption(ctx)
            {
                InternalName = "bustup_samythecoolkid",
                Authors = [Author.samythecoolkid],
                Enable = (ctx) => ctx.FemcConfig.Settings.BustupTrue = Models.FemcModConfig.BustupType.samythecoolkid,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.BustupTrue == Models.FemcModConfig.BustupType.samythecoolkid,
            },
            new ModOption(ctx)
            {
                InternalName = "bustup_Mixi_xiMi",
                Authors = [Author.Mixi_xiMi],
                Enable = (ctx) => ctx.FemcConfig.Settings.BustupTrue = Models.FemcModConfig.BustupType.Mixi_xiMi,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.BustupTrue == Models.FemcModConfig.BustupType.Mixi_xiMi,
            },
        ];
    }
}
