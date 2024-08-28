using Femc_Config_Adjuster.ViewModels.Windows;
using FemcConfig.Library.Config.Models;
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
                this.HandleDownloadUrl(vm.Option.DownloadUrl, vm.Option.Downloader);
            }
        }
    }

    private void HandleDownloadUrl(string url, DownloadHandler handler)
    {
        if (handler == DownloadHandler.Reloaded)
        {
            var proc = new Process() { StartInfo = new ProcessStartInfo() { FileName = $"r2:{url}", UseShellExecute = true } };
            proc.Start();
        }
        else if (handler == DownloadHandler.Browser)
        {
            var proc = new Process() { StartInfo = new ProcessStartInfo() { FileName = url, UseShellExecute = true } };
            proc.Start();
        }
        
        // TODO: Download and install through app directly.
        else if (handler == DownloadHandler.Direct)
        {
            //var uri = new Uri(url);
            var proc = new Process() { StartInfo = new ProcessStartInfo() { FileName = url, UseShellExecute = true } };
            proc.Start();
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
