using FemcConfig.Library.Config.Options;

namespace FemcConfig.Library.Config.Sections;

public class AOATextSection : ISection
{
    public string Name { get; } = Localisation.LocalisationResources.Resources.AOA_Text;

    public string Description { get; } = Localisation.LocalisationResources.Resources.AOATextDesc;

    public SectionCategory Category { get; } = SectionCategory.TwoD;

    public ModOption[] Options { get; }

    public AOATextSection(AppService app)
    {
        var ctx = app.GetContext();
        this.Options =
        [
            new ModOption(ctx)
            {
                InternalName = "aoatext_srry",
                Name = "Sorry Bout that Bye Bye",
                Authors = [Author.Femc],
                Enable = (ctx) => ctx.FemcConfig.Settings.AOAText = Models.FemcModConfig.AOATextType.SorryBoutThat,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.AOAText == Models.FemcModConfig.AOATextType.SorryBoutThat,
            },
            new ModOption(ctx)
            {
                InternalName = "aoatext_dontlook",
                Name="Don't Look Back",
                Authors = [Author.Femc],
                Enable = (ctx) => ctx.FemcConfig.Settings.AOAText = Models.FemcModConfig.AOATextType.DontLookBack,
                IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.AOAText == Models.FemcModConfig.AOATextType.DontLookBack,
            },
			new ModOption(ctx)
			{
				InternalName = "aoatext_PerfectlyAccomplished",
				Name="Pefectly Accomplished !!",
				Authors = [Author.Shiosakana],
				Enable = (ctx) => ctx.FemcConfig.Settings.AOAText = Models.FemcModConfig.AOATextType.PerfectlyAccomplished,
				IsEnabledFunc = (ctx) => ctx.FemcConfig.Settings.AOAText == Models.FemcModConfig.AOATextType.PerfectlyAccomplished,
			},
		];
    }
}
