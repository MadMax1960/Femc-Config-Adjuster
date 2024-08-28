using FemcConfig.Library.Config;
using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace Femc_Config_Adjuster.Views.Windows;

/// <summary>
/// Interaction logic for SetupWindow.xaml
/// </summary>
public partial class SetupWindow : Window
{
    private readonly AppService _app;
    private readonly Action _finishSetup;

    public SetupWindow(AppService app, Action finishSetup)
    {
        InitializeComponent();

        _app = app;
        _finishSetup = finishSetup;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new OpenFileDialog()
        {
            Title = "Select Reloaded II Install",
            Filter = "Reloaded-II.exe|*.exe"
        };

        var result = dialog.ShowDialog();
        if (result == true)
        {
            var path = dialog.FileName;
            var reloadedDir = Path.GetDirectoryName(path)!;
            _app.Initialize(reloadedDir);
            _finishSetup();

            this.Close();
        }
    }
}
