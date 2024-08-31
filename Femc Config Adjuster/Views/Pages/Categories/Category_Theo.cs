using FemcConfig.Library.Config.Sections;

namespace Femc_Config_Adjuster.Views.Pages.Categories;


public class Category_Theo : CategoryView
{
	public Category_Theo(ISection[] sections)
		: base("Theo", sections.Where(x => x.Category == SectionCategory.Theo).ToArray())
	{
	}
}
