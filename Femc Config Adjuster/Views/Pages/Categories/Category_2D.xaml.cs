using Femc_Config_Adjuster.ViewModels.Pages;
using FemcConfig.Library.Config.Sections;
using System.Windows.Controls;

namespace Femc_Config_Adjuster.Views.Pages.Categories;

/// <summary>
/// Interaction logic for Category_2D.xaml
/// </summary>
public partial class Category_2D : Page
{
    public Category_2D(ISection[] sections)
    {
        InitializeComponent();
        this.DataContext = new CategoryViewModel(sections.Where(x => x.Category == SectionCategory.TwoD).ToArray());
    }
}
