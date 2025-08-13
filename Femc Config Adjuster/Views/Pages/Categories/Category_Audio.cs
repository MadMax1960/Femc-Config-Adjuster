using FemcConfig.Library.Config.Sections;
using FemcConfig.Localisation.LocalisationResources;

namespace Femc_Config_Adjuster.Views.Pages.Categories;

public class Category_Audio : CategoryView
{
    public Category_Audio(ISection[] sections)
        : base(FemcConfig.Localisation.LocalisationResources.Resources.Audio, sections.Where(x => x.Category == SectionCategory.Audio).ToArray())
    {
    }
}
