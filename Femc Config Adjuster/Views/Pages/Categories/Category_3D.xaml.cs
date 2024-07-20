using Femc_Config_Adjuster.ViewModels.Pages;
using FemcConfig.Library.Config.Sections;
using System.Windows.Controls;

namespace Femc_Config_Adjuster.Views.Pages.Categories;

/// <summary>
/// Interaction logic for Category_3D.xaml
/// </summary>
public partial class Category_3D : Page
{
    public Category_3D(ISection[] sections)
    {
        InitializeComponent();
        this.DataContext = new CategoryViewModel(sections.Where(x => x.Category == SectionCategory.ThreeD).ToArray());
    }
}
