using Femc_Config_Adjuster.ViewModels.Pages;
using FemcConfig.Library.Config.Sections;
using System.Windows.Controls;

namespace Femc_Config_Adjuster.Views.Pages.Categories;

/// <summary>
/// Interaction logic for CategoryView.xaml
/// </summary>
public partial class CategoryView : UserControl
{
    public CategoryView(string name, ISection[] sections)
    {
        InitializeComponent();
        this.DataContext = new CategoryViewModel(name, sections);
    }
}
