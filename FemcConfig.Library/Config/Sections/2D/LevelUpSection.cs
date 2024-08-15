using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections;

public class LevelUpSection : ISection
{
    public string Name { get; } = "Level Up Screen";

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
                Name = "Ely's Level Up Screen",
                Authors = [Author.Ely],
                Enable = (ctx) => ctx.FemcConfig.Settings.LevelUpTrue = Models.FemcModConfig.LevelUpType.Ely,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.LevelUpTrue == Models.FemcModConfig.LevelUpType.Ely,
            },
            new ModOption(ctx)
            {
                InternalName = "level_esa",
                Name="Esa's Level Up Screen",
                Authors = [Author.Esa],
                Enable = (ctx) => ctx.FemcConfig.Settings.LevelUpTrue = Models.FemcModConfig.LevelUpType.Esa,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.LevelUpTrue == Models.FemcModConfig.LevelUpType.Esa,
            },
        ];
    }
}
