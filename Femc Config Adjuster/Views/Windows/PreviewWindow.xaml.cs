using Femc_Config_Adjuster.ViewModels.Components;
using Femc_Config_Adjuster.ViewModels.Windows;
using FemcConfig.Library.Config.Models;
using FemcConfig.Library.Config.Options;
using FemcConfig.Library.Config.Sections;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
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
            switch (vm.Option.InternalName)
            {
                case "femcdepend":
                    MessageBox.Show("The app will now install the Femc Mod. To install its depndencies go to the dependencies page in the addons category.");
                    LaunchR2Protocol("r2: https://github.com/MadMax1960/Femc-Reloaded-Project/releases/latest");
                    break;
                case "ryo":
                    LaunchR2Protocol("r2:https://gamebanana.com/mods/495507");
                    break;
                case "costume":
                    LaunchR2Protocol("r2:https://gamebanana.com/mods/501833");
                    break;
                case "object":
                    LaunchR2Protocol("r2:https://gamebanana.com/mods/500638");
                    break;
                case "p3re":
                    LaunchR2Protocol("r2:https://gamebanana.com/mods/494020");
                    break;
                case "bgme":
                    LaunchR2Protocol("r2:https://gamebanana.com/mods/495456");
                    break;
                case "battletheme":
                    LaunchR2Protocol("r2:https://gamebanana.com/mods/495458");
                    break;
                case "ue":
                    LaunchR2Protocol("r2:https://github.com/AnimatedSwine37/UnrealEssentials/releases/latest");
                    break;
                case "movieaddon":
                    System.Windows.MessageBox.Show("Installation not supported yet");
                    break;
                case "colorarm":
                    System.Windows.MessageBox.Show("armcolor");
                    LaunchR2Protocol("r2:https://gamebanana.com/mods/525920");
                    break;
                default:
                    System.Windows.MessageBox.Show("Installation not added yet");
                    break;
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
