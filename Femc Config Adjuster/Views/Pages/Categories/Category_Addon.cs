using FemcConfig.Library.Config.Sections;
namespace Femc_Config_Adjuster.Views.Pages.Categories;

public class Category_Addon : CategoryView
{
    public Category_Addon(ISection[] sections)
        : base("Addon", sections.Where(x => x.Category == SectionCategory.Addon).ToArray())
    {
    }
}
