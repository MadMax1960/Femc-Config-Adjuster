using FemcConfig.Library.Config.Sections;
namespace Femc_Config_Adjuster.Views.Pages.Categories;

public class Category_Movie : CategoryView
{
    public Category_Movie(ISection[] sections)
        : base("Movie", sections.Where(x => x.Category == SectionCategory.Movie).ToArray())
    {
    }
}
