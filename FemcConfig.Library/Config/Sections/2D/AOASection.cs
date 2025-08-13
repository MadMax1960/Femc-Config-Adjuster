﻿using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections;

public class AOASection : ISection
{
    public string Name { get; } = Localisation.LocalisationResources.Resources.AOA;

    public string Description { get; } = Localisation.LocalisationResources.Resources.AOADesc;

    public SectionCategory Category { get; } = SectionCategory.TwoD;

    public ModOption[] Options { get; }

    public AOASection(AppService app)
    {
        var ctx = app.GetContext();
        this.Options =
        [
            new ModOption(ctx)
            {
                InternalName = "aoa_ely",
                Authors = [Author.Ely],
                Enable = (ctx) => ctx.FemcConfig.Settings.AOATrue = Models.FemcModConfig.AOAType.Ely,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.AOATrue == Models.FemcModConfig.AOAType.Ely,
            },
            new ModOption(ctx)
            {
                InternalName = "aoa_fernando",
                Authors = [Author.Fernando],
                Enable = (ctx) => ctx.FemcConfig.Settings.AOATrue = Models.FemcModConfig.AOAType.Fernando,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.AOATrue == Models.FemcModConfig.AOAType.Fernando,
            },
            new ModOption(ctx)
            {
                InternalName = "aoa_ronald",
                Authors = [Author.Ronald],
                Enable = (ctx) => ctx.FemcConfig.Settings.AOATrue = Models.FemcModConfig.AOAType.RonaldReagan,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.AOATrue == Models.FemcModConfig.AOAType.RonaldReagan,
            },
            new ModOption(ctx)
            {
                InternalName = "aoa_monica",
                Authors = [Author.Monica],
                Enable = (ctx) => ctx.FemcConfig.Settings.AOATrue = Models.FemcModConfig.AOAType.Monica,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.AOATrue == Models.FemcModConfig.AOAType.Monica,
            },
            new ModOption(ctx)
            {
                InternalName = "aoa_chrysanthie",
                Authors = [Author.Chrysanthie],
                Enable = (ctx) => ctx.FemcConfig.Settings.AOATrue = Models.FemcModConfig.AOAType.Chrysanthie,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.AOATrue == Models.FemcModConfig.AOAType.Chrysanthie,
            },
			new ModOption(ctx)
			{
				InternalName = "aoa_esaadrien",
				Authors = [Author.Esa, Author.Adrien],
				Enable = (ctx) => ctx.FemcConfig.Settings.AOATrue = Models.FemcModConfig.AOAType.esaadrien,
				IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.AOATrue == Models.FemcModConfig.AOAType.esaadrien,
			},
			new ModOption(ctx)
			{
				InternalName = "aoa_mekki",
				Authors = [Author.Mekki],
				Enable = (ctx) => ctx.FemcConfig.Settings.AOATrue = Models.FemcModConfig.AOAType.mekki,
				IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.AOATrue == Models.FemcModConfig.AOAType.mekki,
			},
			new ModOption(ctx)
			{
				InternalName = "aoa_shiosakana",
				Authors = [Author.Shiosakana],
				Enable = (ctx) => ctx.FemcConfig.Settings.AOATrue = Models.FemcModConfig.AOAType.shiosakana,
				IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.AOATrue == Models.FemcModConfig.AOAType.shiosakana,
			},
			new ModOption(ctx)
			{
				InternalName = "aoa_shiosakanaAlt",
				Authors = [Author.Shiosakana],
				Enable = (ctx) => ctx.FemcConfig.Settings.AOATrue = Models.FemcModConfig.AOAType.shiosakanaAlt,
				IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.AOATrue == Models.FemcModConfig.AOAType.shiosakanaAlt,
			},
            new ModOption(ctx)
            {
                InternalName = "aoa_nami",
                Authors = [Author.namiweiko],
                Enable = (ctx) => ctx.FemcConfig.Settings.AOATrue = Models.FemcModConfig.AOAType.Nami,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.AOATrue == Models.FemcModConfig.AOAType.Nami,
            },
            new ModOption(ctx)
            {
                InternalName = "aoa_angie",
                Authors = [Author.AngieDaGorl],
                Enable = (ctx) => ctx.FemcConfig.Settings.AOATrue = Models.FemcModConfig.AOAType.AngieDaGorl,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.AOATrue == Models.FemcModConfig.AOAType.AngieDaGorl,
            },
            new ModOption(ctx)
            {
                InternalName = "aoa_StupidAle",
                Authors = [Author.StupidAle],
                Enable = (ctx) => ctx.FemcConfig.Settings.AOATrue = Models.FemcModConfig.AOAType.StupidAle,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.AOATrue == Models.FemcModConfig.AOAType.StupidAle,
            },
        ];
    }
}
