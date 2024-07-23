using Femc_Config_Adjuster.ViewModels.Components;
using Femc_Config_Adjuster.ViewModels.Windows;
using Femc_Config_Adjuster.Views.Windows;
using System.Windows.Controls;

namespace Femc_Config_Adjuster.Views.Components;

/// <summary>
/// Interaction logic for OptionView.xaml
/// </summary>
public partial class OptionView : UserControl
{
    public OptionView()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        if (this.DataContext is OptionViewModel optionViewModel)
        {
            var previewWindow = new PreviewWindow()
            {
                DataContext = new PreviewWindowViewModel(optionViewModel.Option),
            };

            previewWindow.ShowDialog();
        }
    }
}
