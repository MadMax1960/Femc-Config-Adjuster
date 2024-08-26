using FemcConfig.Library.Config.Sections;

namespace Femc_Config_Adjuster.Views.Pages.Categories;

public class Category_Main : CategoryView
{
    public Category_Main(ISection[] sections)
        : base("Main", sections.Where(x => x.Category == SectionCategory.MainPage).ToArray())
    {
    }
}
