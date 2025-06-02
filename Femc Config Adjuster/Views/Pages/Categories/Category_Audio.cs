using FemcConfig.Library.Config.Sections;

namespace Femc_Config_Adjuster.Views.Pages.Categories;

public class Category_Audio : CategoryView
{
    public Category_Audio(ISection[] sections)
        : base("Audio", sections.Where(x => x.Category == SectionCategory.Audio).ToArray())
    {
    }
}
