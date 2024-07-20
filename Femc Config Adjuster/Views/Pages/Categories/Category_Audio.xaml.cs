using Femc_Config_Adjuster.ViewModels.Pages;
using FemcConfig.Library.Config.Sections;
using System.Windows.Controls;

namespace Femc_Config_Adjuster.Views.Pages.Categories;

/// <summary>
/// Interaction logic for Category_Audio.xaml
/// </summary>
public partial class Category_Audio : Page
{
    public Category_Audio(ISection[] sections)
    {
        InitializeComponent();
        this.DataContext = new CategoryViewModel(sections.Where(x => x.Category == SectionCategory.Audio).ToArray());
    }
}
