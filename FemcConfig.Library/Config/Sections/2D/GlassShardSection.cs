using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections;

public class GlassShardSection : ISection
{
    public string Name { get; } = Localisation.LocalisationResources.Resources.Glass_Shard;

    public string Description { get; } = "Glass Shards used in the config screen.";

    public SectionCategory Category { get; } = SectionCategory.TwoD;

    public ModOption[] Options { get; }

    public GlassShardSection(AppService app)
    {
        var ctx = app.GetContext();
        this.Options =
        [
            new ModOption(ctx)
            {
                InternalName = "shard_ely",
                Authors = [Author.Ely],
                Enable = (ctx) => ctx.FemcConfig.Settings.ShardTrue = Models.FemcModConfig.ShardType.Ely,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.ShardTrue == Models.FemcModConfig.ShardType.Ely,
            },
            new ModOption(ctx)
            {
                InternalName = "shard_esa",
                Authors = [Author.Esa],
                Enable = (ctx) => ctx.FemcConfig.Settings.ShardTrue = Models.FemcModConfig.ShardType.Esa,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.ShardTrue == Models.FemcModConfig.ShardType.Esa,
            },
			new ModOption(ctx)
			{
				InternalName = "shard_elyalt",
				Authors = [Author.Ely],
				Enable = (ctx) => ctx.FemcConfig.Settings.ShardTrue = Models.FemcModConfig.ShardType.ElyAlt,
				IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.ShardTrue == Models.FemcModConfig.ShardType.ElyAlt,
			},

			new ModOption(ctx)
			{
				InternalName = "shard_shiosakana",
				Authors = [Author.Shiosakana],
				Enable = (ctx) => ctx.FemcConfig.Settings.ShardTrue = Models.FemcModConfig.ShardType.Shiosakana,
				IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.ShardTrue == Models.FemcModConfig.ShardType.Shiosakana,
			},
            new ModOption(ctx)
            {
                InternalName = "shard_namiweiko",
                Authors = [Author.namiweiko],
                Enable = (ctx) => ctx.FemcConfig.Settings.ShardTrue = Models.FemcModConfig.ShardType.namiweiko,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.ShardTrue == Models.FemcModConfig.ShardType.namiweiko,
            },
            new ModOption(ctx)
            {
                InternalName = "shard_angie",
                Authors = [Author.AngieDaGorl],
                Enable = (ctx) => ctx.FemcConfig.Settings.ShardTrue = Models.FemcModConfig.ShardType.AngieDaGorl,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.ShardTrue == Models.FemcModConfig.ShardType.AngieDaGorl,
            },
        ];
    }
}
