using System.Windows.Input;
using Wpf.Ui.Appearance;
using Microsoft.Win32;
using Femc_Config_Adjuster.Helpers;
using Wpf.Ui.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Femc_Config_Adjuster.ViewModels.Pages;

public partial class SettingsViewModel : ObservableObject, INavigationAware
{
    private bool _isInitialized = false;
    
    [ObservableProperty]
	private string _appVersion = "1.0.1";
    public const string APP_UPDATE_ENDPOINT = "https://api.github.com/repos/MadMax1960/Femc-Config-Adjuster/releases";

    [ObservableProperty]
    private ApplicationTheme _currentTheme = ApplicationTheme.Unknown;

    public void OnNavigatedTo()
    {
        if (!_isInitialized)
            InitializeViewModel();
    }

    public void OnNavigatedFrom() { }

    private void InitializeViewModel()
    {
        CurrentTheme = ApplicationThemeManager.GetAppTheme();
        AppVersion = $"1.0.1 - Addons, Musics and Portable Release Compatibility Update";
        _isInitialized = true;
    }

    
	[RelayCommand]
	private void OnChangeTheme(string parameter)
	{
		switch (parameter)
		{
			case "theme_light":
				if (CurrentTheme == ApplicationTheme.Light)
					break;

                ApplicationThemeManager.Apply(ApplicationTheme.Light);
                CurrentTheme = ApplicationTheme.Light;

                break;

            default:
                if (CurrentTheme == ApplicationTheme.Dark)
                    break;

                ApplicationThemeManager.Apply(ApplicationTheme.Dark);
                CurrentTheme = ApplicationTheme.Dark;

                break;
        }
    }
}