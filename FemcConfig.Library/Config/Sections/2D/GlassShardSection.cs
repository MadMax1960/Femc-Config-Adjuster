using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections;

public class GlassShardSection : ISection
{
    public string Name { get; } = "Glass Shard";

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
                Name = "Ely's Glass Shards",
                Authors = [Author.Ely],
                Enable = (ctx) => ctx.FemcConfig.Settings.ShardTrue = Models.FemcModConfig.ShardType.Ely,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.ShardTrue == Models.FemcModConfig.ShardType.Ely,
            },
            new ModOption(ctx)
            {
                InternalName = "shard_esa",
                Name="Esa's Glass Shards",
                Authors = [Author.Esa],
                Enable = (ctx) => ctx.FemcConfig.Settings.ShardTrue = Models.FemcModConfig.ShardType.Esa,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.ShardTrue == Models.FemcModConfig.ShardType.Esa,
            },
			new ModOption(ctx)
			{
				InternalName = "shard_elyalt",
				Name="Ely's Alt Glass Shards",
				Authors = [Author.Ely],
				Enable = (ctx) => ctx.FemcConfig.Settings.ShardTrue = Models.FemcModConfig.ShardType.ElyAlt,
				IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.ShardTrue == Models.FemcModConfig.ShardType.ElyAlt,
			},

			new ModOption(ctx)
			{
				InternalName = "shard_Shiosakana",
				Name="Shiosakana's Glass Shard",
				Authors = [Author.Shiosakana],
				Enable = (ctx) => ctx.FemcConfig.Settings.ShardTrue = Models.FemcModConfig.ShardType.Shiosakana,
				IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.ShardTrue == Models.FemcModConfig.ShardType.Shiosakana,
			},
		];
    }
}
