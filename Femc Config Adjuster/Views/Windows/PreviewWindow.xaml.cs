using Femc_Config_Adjuster.ViewModels.Components;
using Femc_Config_Adjuster.ViewModels.Windows;
using FemcConfig.Library.Config.Models;
using FemcConfig.Library.Config.Options;
using Microsoft.Web.WebView2.Wpf;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Wpf.Ui.Controls;
using MessageBox = System.Windows.MessageBox;

namespace Femc_Config_Adjuster.Views.Windows;

/// <summary>
/// Interaction logic for PreviewWindow.xaml
/// </summary>
public partial class PreviewWindow : FluentWindow
{
    public PreviewWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (this.DataContext is PreviewWindowViewModel vm)
        {
            vm.Option.IsEnabled = true;
        }

        this.Close();
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private async void Button_Click_2(object sender, RoutedEventArgs e)
    {
        //Mudkip this is the cue for u to add the actual installation of the mods
        System.Windows.MessageBox.Show("Functionality to be added");
    }

    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);

        if (this.webviewControl.Content is WebView2 webview)
        {
            webview.Dispose();
        }
    }    
}
