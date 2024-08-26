using Femc_Config_Adjuster.ViewModels.Components;
using Femc_Config_Adjuster.ViewModels.Windows;
using FemcConfig.Library.Config.Models;
using FemcConfig.Library.Config.Options;
using FemcConfig.Library.Config.Sections;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Policy;
using System.Windows;
using System.Windows.Media.Imaging;
using Wpf.Ui.Controls;
using static System.Net.WebRequestMethods;
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
        if (this.DataContext is PreviewWindowViewModel vm)
        {
            if (vm.Option.InternalName == "movieaddon")
            {
                System.Windows.MessageBox.Show("Installation not supported yet");
            }
            else if(vm.Option.InternalName == "femcdepend")
            {
                MessageBox.Show("The app will now install the Femc Mod and its dependencies. After installation go to reloaded and try updating the femc mod.");
                LaunchR2Protocol("r2:https://gamebanana.com/mods/495507");
                LaunchR2Protocol("r2:https://gamebanana.com/mods/501833");
                LaunchR2Protocol("r2:https://gamebanana.com/mods/500638");
                LaunchR2Protocol("r2:https://gamebanana.com/mods/494020");
                LaunchR2Protocol("r2:https://gamebanana.com/mods/495456");
                LaunchR2Protocol("r2:https://gamebanana.com/mods/495458");
                LaunchR2Protocol("r2: https://github.com/MadMax1960/Femc-Reloaded-Project/releases/latest");
                LaunchR2Protocol("r2:https://github.com/AnimatedSwine37/UnrealEssentials/releases/latest");
            }
        }
    }

    private void LaunchR2Protocol(string url)
    {
        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
        catch (System.ComponentModel.Win32Exception ex)
        {
            MessageBox.Show($"Failed to launch the protocol: {ex.Message}", "Error");
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
