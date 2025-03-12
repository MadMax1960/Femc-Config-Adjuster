using FemcConfig.Library.Config.Sections;
using Femc_Config_Adjuster.LocalisationResources;

namespace Femc_Config_Adjuster.Views.Pages.Categories;

public class Category_Audio : CategoryView
{
    public Category_Audio(ISection[] sections)
        : base(Femc_Config_Adjuster.LocalisationResources.Resources.Audio, sections.Where(x => x.Category == SectionCategory.Audio).ToArray())
    {
    }
}
