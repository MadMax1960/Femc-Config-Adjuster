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
	public const string ConfigFilePath = "config.json";
	private bool _isInitialized = false;

	[ObservableProperty]
	private string _appVersion = "1.0.0";
    public const string APP_UPDATE_ENDPOINT = "https://api.github.com/repos/MadMax1960/Femc-Config-Adjuster/releases";

    [ObservableProperty]
	private ApplicationTheme _currentTheme = ApplicationTheme.Unknown;

	[ObservableProperty]
	public string _jsonFilePath = string.Empty;

	public ICommand SelectJsonFileCommand { get; }

	public SettingsViewModel()
	{
		SelectJsonFileCommand = new RelayCommand(SelectJsonFile);

		var config = Config.LoadConfig(ConfigFilePath);
		JsonFilePath = config.JsonFilePath;
	}

	public void OnNavigatedTo()
	{
		if (!_isInitialized)
			InitializeViewModel();
	}

	public void OnNavigatedFrom() { }

	private void InitializeViewModel()
	{
		CurrentTheme = ApplicationThemeManager.GetAppTheme();
		AppVersion = $"0.1 - {GetAssemblyVersion()}";

		_isInitialized = true;
	}

	private string GetAssemblyVersion()
	{
		return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString()
			?? string.Empty;
	}

	public void SelectJsonFile()
	{
		var openFileDialog = new OpenFileDialog
		{
			Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*"
		};

		if (openFileDialog.ShowDialog() == true)
		{
			JsonFilePath = openFileDialog.FileName;

			var config = new Config { JsonFilePath = JsonFilePath };
			config.SaveConfig(ConfigFilePath);
		}
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
