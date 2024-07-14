using System;
using System.IO;
using System.Text.Json;
using Femc_Config_Adjuster.Helpers;
namespace Femc_Config_Adjuster.ViewModels.Pages
{
	public partial class DashboardViewModel : ObservableObject
	{
		[ObservableProperty]
		private int _counter = 0;

		[ObservableProperty]
		private string _jsonContent = string.Empty;

		public DashboardViewModel()
		{
			LoadJsonFile();
		}

		private void LoadJsonFile()
		{
			var config = Config.LoadConfig("config.json");
			var jsonFilePath = config.JsonFilePath;

			if (File.Exists(jsonFilePath))
			{
				JsonContent = File.ReadAllText(jsonFilePath);
			}
			else
			{
				JsonContent = "JSON file not found.";
			}
		}

		[RelayCommand]
		private void OnCounterIncrement()
		{
			Counter++;
		}
	}
}
