using FemcConfig.Library.Config.Sections;
using FemcConfig.Localisation.LocalisationResources;

namespace Femc_Config_Adjuster.Views.Pages.Categories;

public class Category_Music : CategoryView
{
    public Category_Music(ISection[] sections)
        : base(FemcConfig.Localisation.LocalisationResources.Resources.Music, sections.Where(x => x.Category == SectionCategory.Music).ToArray())
    {
    }
}
