using System;
using System.IO;
using System.Text.Json;
using Femc_Config_Adjuster.Helpers;

namespace Femc_Config_Adjuster.ViewModels.Pages
{
	public partial class DashboardViewModel : ObservableObject
	{
		private Config _config;
		private string _selectedOption;
		private string _selectedOptionName;

		// Define Options array
		public string[] Options { get; } = { "Bustup", "Aoa", "LevelUp" };

		// Define SelectedOption property
		public string SelectedOption
		{
			get => _selectedOption;
			set
			{
				_selectedOption = value;
				OnPropertyChanged(nameof(SelectedOption));
				DisplaySelectedOptionName();
			}
		}

		// Define SelectedOptionName property
		public string SelectedOptionName
		{
			get => _selectedOptionName;
			set
			{
				_selectedOptionName = value;
				OnPropertyChanged(nameof(SelectedOptionName));
			}
		}

		public DashboardViewModel()
		{
			LoadConfig();
			LoadJsonFile();
		}

		private void LoadConfig()
		{
			_config = Config.LoadConfig("config.json");
		}

		private void LoadJsonFile()
		{
			if (File.Exists(_config.JsonFilePath))
			{
				JsonContent = File.ReadAllText(_config.JsonFilePath);
			}
			else
			{
				JsonContent = "JSON file not found.";
			}
		}

		private string _jsonContent;
		public string JsonContent
		{
			get => _jsonContent;
			set
			{
				_jsonContent = value;
				OnPropertyChanged(nameof(JsonContent));
			}
		}

		private void DisplaySelectedOptionName()
		{
			try
			{
				// Parse JSON content to find selected option name
				var jsonDocument = JsonDocument.Parse(JsonContent);
				var root = jsonDocument.RootElement;

				// Adjust path and property name as per your JSON structure
				SelectedOptionName = root.GetProperty($"{SelectedOption}True").GetString();
			}
			catch (Exception ex)
			{
				SelectedOptionName = $"Error: {ex.Message}";
			}
		}
	}
}
