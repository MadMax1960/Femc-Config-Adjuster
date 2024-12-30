using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FemcConfig.Library.Config;
using FemcConfig.Library.Common;

namespace Femc_Config_Adjuster.ViewModels.Pages;

public partial class SettingsViewModel : ObservableObject, INavigationAware
{
    private bool _isInitialized = false;

    [ObservableProperty]
    private string? _appVersion;

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
        //AppVersion should always match the latest version of the FeMC mod.
        AppVersion = Constants.FEMC_MOD_VER + " - This should match the version of the FeMC mod you have installed on your system.";
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