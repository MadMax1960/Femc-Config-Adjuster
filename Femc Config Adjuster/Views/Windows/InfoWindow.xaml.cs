using System.Windows;
using Wpf.Ui.Controls;
namespace Femc_Config_Adjuster.Views.Windows;

/// <summary>
/// Interaction logic for InfoWindow.xaml
/// </summary>
public partial class InfoWindow : FluentWindow
{
    public InfoWindow(string Title= "Information Title", string Content= "This is example content that will wrap.", string WindowTitle="Femc Config Info", string ButtonContent="OK")
    {
        InitializeComponent();
        this.Title = WindowTitle;
        this.TitleBar.Title = WindowTitle;
        this.InfoTitle.Text = Title;
        this.InfoContent.Text = Content;
        this.CloseButton.Content = ButtonContent;
    }

    private void Close_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
