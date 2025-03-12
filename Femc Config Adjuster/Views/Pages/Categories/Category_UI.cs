using FemcConfig.Library.Config.Sections;

namespace Femc_Config_Adjuster.Views.Pages.Categories;

internal class Category_UI : CategoryView
{
    public Category_UI(ISection[] sections)
        : base(FemcConfig.Localisation.LocalisationResources.Resources.UI, sections.Where(x => x.Category == SectionCategory.UI).ToArray())
    {
    }
}
