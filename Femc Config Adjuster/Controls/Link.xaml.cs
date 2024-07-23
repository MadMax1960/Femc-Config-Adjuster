using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Femc_Config_Adjuster.Controls;

/// <summary>
/// Interaction logic for Link.xaml
/// </summary>
public partial class Link : UserControl
{
    public Link()
    {
        InitializeComponent();
    }

    public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(Link));
    public static readonly DependencyProperty UrlProperty = DependencyProperty.Register("Url", typeof(string), typeof(Link));

    public string? Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public string? Url
    {
        get => (string)GetValue(UrlProperty);
        set => SetValue(UrlProperty, value);
    }

    private void UserControl_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        if (this.Url != null)
        {
            Process.Start(new ProcessStartInfo(this.Url)
            {
                UseShellExecute = true,
            });
        }
    }
}
