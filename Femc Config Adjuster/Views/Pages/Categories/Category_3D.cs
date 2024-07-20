using FemcConfig.Library.Config.Sections;

namespace Femc_Config_Adjuster.Views.Pages.Categories;

public class Category_3D : CategoryView
{
    public Category_3D(ISection[] sections)
        : base("3D", sections.Where(x => x.Category == SectionCategory.ThreeD).ToArray())
    {
    }
}
