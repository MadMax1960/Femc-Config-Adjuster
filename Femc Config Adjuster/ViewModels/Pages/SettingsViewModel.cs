using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FemcConfig.Library.Common;
using Femc_Config_Adjuster.Views.Windows;
using System.Globalization;
using FemcConfig.Localisation.LocalisationResources;
using System.Diagnostics;

namespace Femc_Config_Adjuster.ViewModels.Pages;

public partial class SettingsViewModel : ObservableObject, INavigationAware
{
    public Dictionary<string, string> AvailableLanguages { get; } = new()
    {
        { "English", "en-US" },
        { "简体中文 (Simplified Chinese)", "zh-CN" },
        { "日本語 (Japanese)", "ja" }
    };

    private bool _isInitialized = false;

    [ObservableProperty]
    private string _selectedLanguage;

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
        //AppVersion should always match the latest version of the FeMC mod.
        AppVersion = Constants.FEMC_MOD_VER + " - This should match the version of the FeMC mod you have installed on your system.";
        string savedCulture = Properties.Settings.Default.SelectedLanguage;
        if (!string.IsNullOrEmpty(savedCulture))
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(savedCulture);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(savedCulture);
        }
        _selectedLanguage = AvailableLanguages.FirstOrDefault(x => x.Value == Thread.CurrentThread.CurrentUICulture.Name).Key
                             ?? "English";
        OnPropertyChanged(nameof(SelectedLanguage));
        CurrentTheme = ApplicationThemeManager.GetAppTheme();
        _isInitialized = true;

    }

    partial void OnSelectedLanguageChanged(string value)
    {
        if (!_isInitialized || string.IsNullOrEmpty(value))
            return; // Prevent running ChangeLanguage() on startup

        if (!string.IsNullOrEmpty(value) && AvailableLanguages.ContainsKey(value))
        {
            ChangeLanguage(AvailableLanguages[value]);
        }
        else
        {
            ChangeLanguage("en-US");
        }
    }

    public void ChangeLanguage(string cultureCode)
    {
        Properties.Settings.Default.SelectedLanguage = cultureCode;
        Properties.Settings.Default.Save();
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode);
        Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureCode);

        var langnotify = new InfoWindow("Language Changed!", Resources.LanguageChangeAlert);
        langnotify.ShowDialog();
        Process.Start(Process.GetCurrentProcess().MainModule.FileName);
        App.Current.Shutdown();
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