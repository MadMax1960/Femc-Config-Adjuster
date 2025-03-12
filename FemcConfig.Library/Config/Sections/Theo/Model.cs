using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections._Theo;

public class Model : ISection
{
	public string Name { get; } = Localisation.LocalisationResources.Resources.Model;

	public string Description { get; } = "Theo Model";

	public SectionCategory Category { get; } = SectionCategory.Theo;

	public ModOption[] Options { get; }

	public Model(AppService app)
	{
		var ctx = app.GetContext();
		this.Options =
		[
			new ModOption(ctx)
			{
                InternalName = "theodore",
                Name = "Theodore Model",
                Authors = [Author.Femc],

                // When option is enabled set the bool setting to true.
                Enable = (ctx) => ctx.FemcConfig.Settings.TheodorefromAlvinandTheChipmunks = true,
                Disable = (ctx) => ctx.FemcConfig.Settings.TheodorefromAlvinandTheChipmunks = false,

                // Simpler than enums, just get the current bool value.
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.TheodorefromAlvinandTheChipmunks,
            }
		];
	}
}
