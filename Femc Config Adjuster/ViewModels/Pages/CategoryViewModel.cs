using CommunityToolkit.Mvvm.ComponentModel;
using Femc_Config_Adjuster.ViewModels.Components;
using FemcConfig.Library.Config.Sections;

namespace Femc_Config_Adjuster.ViewModels.Pages;

public partial class CategoryViewModel : ObservableObject
{
    [ObservableProperty]
    private OptionsSection? selectedSection;

    public CategoryViewModel(string name, ISection[] sections)
    {
        this.Name = name;
        this.Sections = sections.OrderBy(x => x.Name == "The Femc Mod" ? 0 : 1).Select(x => new OptionsSection(x.Name, x.Description, new(x.Options))).ToArray();
        this.SelectedSection = this.Sections.FirstOrDefault();
    }

    public OptionsSection[] Sections { get; }

    public string Name { get; }

    public record OptionsSection(string Name, string Description, OptionsGalleryViewModel OptionsGallery);
}
