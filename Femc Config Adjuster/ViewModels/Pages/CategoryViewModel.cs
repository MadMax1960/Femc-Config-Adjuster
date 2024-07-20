using CommunityToolkit.Mvvm.ComponentModel;
using FemcConfig.Library.Config.Sections;

namespace Femc_Config_Adjuster.ViewModels.Pages;

public partial class CategoryViewModel : ObservableObject
{
    [ObservableProperty]
    private ISection? selectedSection;

    public CategoryViewModel(string name, ISection[] sections)
    {
        this.Name = name;
        this.Sections = sections;
        this.selectedSection = sections.FirstOrDefault();
    }

    public ISection[] Sections { get; }

    public string Name { get; }
}
