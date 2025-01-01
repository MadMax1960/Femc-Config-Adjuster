using Microsoft.Web.WebView2.Core;
using System.Windows;
using Wpf.Ui.Controls;
namespace Femc_Config_Adjuster.Views.Windows;

/// <summary>
/// Interaction logic for WebViewWindow.xaml
/// </summary>
public partial class WebViewWindow : FluentWindow
{
    public WebViewWindow(string url, string WindowTitle="Femc Config Web Viewer", string AcceptButtonContent="OK", string RejectButtonContent="Deny", bool EnableRejectButton = false)
    {
        InitializeComponent();
        WebViewer.Source = new Uri(url, UriKind.RelativeOrAbsolute);
        this.Title = WindowTitle;
        this.TitleBar.Title = WindowTitle;
        this.AcceptButton.HorizontalAlignment = EnableRejectButton ? HorizontalAlignment.Left : HorizontalAlignment.Stretch;
        this.RejectButton.Visibility = EnableRejectButton ? Visibility.Visible : Visibility.Collapsed;
        this.AcceptButton.Content = AcceptButtonContent;
        this.RejectButton.Content = RejectButtonContent;
    }

    private void Accept_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void Reject_Click(object sender, RoutedEventArgs e)
    {
        App.Current.Shutdown();
    }
}
