using FemcConfig.Library.Config.Sections;

namespace Femc_Config_Adjuster.ViewModels.Pages;

public class CategoryViewModel
{
    public CategoryViewModel(ISection[] sections)
    {
        this.Sections = sections;
    }

    public ISection[] Sections { get; }
}
