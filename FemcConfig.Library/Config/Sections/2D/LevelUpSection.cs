using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections;

public class LevelUpSection : ISection
{
    public string Name { get; } = Localisation.LocalisationResources.Resources.Level_Up_Screen;

    public string Description { get; } = "Select the level up screen that is shown.";

    public SectionCategory Category { get; } = SectionCategory.TwoD;

    public ModOption[] Options { get; }

    public LevelUpSection(AppService app)
    {
        var ctx = app.GetContext();
        this.Options =
        [
            new ModOption(ctx)
            {
                InternalName = "level_ely",
                Authors = [Author.Ely],
                Enable = (ctx) => ctx.FemcConfig.Settings.LevelUpTrue = Models.FemcModConfig.LevelUpType.Ely,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.LevelUpTrue == Models.FemcModConfig.LevelUpType.Ely,
            },
            new ModOption(ctx)
            {
                InternalName = "level_esa",
                Authors = [Author.Esa],
                Enable = (ctx) => ctx.FemcConfig.Settings.LevelUpTrue = Models.FemcModConfig.LevelUpType.Esa,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.LevelUpTrue == Models.FemcModConfig.LevelUpType.Esa,
            },
			new ModOption(ctx)
			{
				InternalName = "level_shiosakana",
				Authors = [Author.Shiosakana],
				Enable = (ctx) => ctx.FemcConfig.Settings.LevelUpTrue = Models.FemcModConfig.LevelUpType.shiosakana,
				IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.LevelUpTrue == Models.FemcModConfig.LevelUpType.shiosakana,
			},
            new ModOption(ctx)
            {
                InternalName = "level_ElyAlt",
                Name = "Ely (Alt)",
                Authors = [Author.Ely],
                Enable = (ctx) => ctx.FemcConfig.Settings.LevelUpTrue = Models.FemcModConfig.LevelUpType.ElyAlt,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.LevelUpTrue == Models.FemcModConfig.LevelUpType.ElyAlt,
            },
            new ModOption(ctx)
            {
                InternalName = "level_angie",
                Authors = [Author.AngieDaGorl],
                Enable = (ctx) => ctx.FemcConfig.Settings.LevelUpTrue = Models.FemcModConfig.LevelUpType.AngieDaGorl,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.LevelUpTrue == Models.FemcModConfig.LevelUpType.AngieDaGorl,
            },

        ];
    }
}
