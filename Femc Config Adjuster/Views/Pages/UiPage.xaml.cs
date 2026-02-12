using System.Windows;
using Femc_Config_Adjuster.ViewModels.Pages;
using FemcConfig.Library.Config;
using System.Windows.Controls;

namespace Femc_Config_Adjuster.Views.Pages;

/// <summary>
/// Interaction logic for UiPage.xaml
/// </summary>
public partial class UiPage : UserControl
{
    public UiPage(UiPageViewModel vm)
    {
        InitializeComponent();
        this.DataContext = vm;
    }
}
