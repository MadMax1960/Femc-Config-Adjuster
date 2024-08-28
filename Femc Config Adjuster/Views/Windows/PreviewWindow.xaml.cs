using Femc_Config_Adjuster.ViewModels.Windows;
using Microsoft.Web.WebView2.Wpf;
using System.Diagnostics;
using System.Windows;
using Wpf.Ui.Controls;

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

    private void Button_Confirm(object sender, RoutedEventArgs e)
    {
        if (this.DataContext is PreviewWindowViewModel vm)
        {
            vm.Option.IsEnabled = true;
        }

        this.Close();
    }

    private void Button_Close(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void Button_Download(object sender, RoutedEventArgs e)
    {
        // Mudkip this is the cue for u to add the actual installation of the mods
        if (this.DataContext is PreviewWindowViewModel vm)
        {
            if (vm.Option.DownloadUrl != null)
            {
                this.HandleDownloadUrl(vm.Option.DownloadUrl, (vm.Option.Protocol is not null) ? vm.Option.Protocol : "r2");
            }
        }
    }

    private void HandleDownloadUrl(string url, string protocol="r2")
    {
        if (protocol == "r2")
        {
            url = "r2:" + url;
            var uri = new Uri(url);
            var proc = new Process() { StartInfo = new ProcessStartInfo() { FileName = url, UseShellExecute = true } };
            proc.Start();
        }
        else if(protocol == "femcinstall")
        {
            //Future Femc Mod Installation Code here, currently still gonna be using the r2 method for the next update
        }
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
