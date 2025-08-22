using FemcConfig.Library.Config.Sections;

namespace Femc_Config_Adjuster.Views.Pages.Categories;

internal class Category_Misc : CategoryView
{
    public Category_Misc(ISection[] sections)
        : base(/*FemcConfig.Localisation.LocalisationResources.Resources.Misc*/"Misc", sections.Where(x => x.Category == SectionCategory.Misc).ToArray())
    {
    }
}
