using System.Windows;
using System.Windows.Controls;
using Femc_Config_Adjuster.ViewModels.Pages;
using Femc_Config_Adjuster.ViewModels.Windows;
using Femc_Config_Adjuster.Views.Windows;

namespace Femc_Config_Adjuster.Views.Components;

public partial class ColorView : UserControl
{
    public ColorView()
    {
        InitializeComponent();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        if (DataContext is UiOption uiOption)
        {
            var colorWindow = new ColorEditWindow()
            {
                DataContext = new ColorEditViewModel(uiOption),
            };
            colorWindow.ShowDialog();
        }
    }
}