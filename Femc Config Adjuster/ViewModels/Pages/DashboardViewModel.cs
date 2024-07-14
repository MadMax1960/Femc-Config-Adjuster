using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows.Controls;
using Femc_Config_Adjuster.Helpers;

namespace Femc_Config_Adjuster.ViewModels.Pages
{
	public partial class DashboardViewModel : ObservableObject
	{
		private Config _config;
		private string _selectedOptionInit;
		private string _selectedOptionNameInit;

		// Define Options array
		public string[] OptionsInit { get; } = { "Bustup", "AOA", "AOAText", "LevelUp" };
		Dictionary<string, string> OptionSuffix =
			 new Dictionary<string, string>(){
			 {"Bustup", "True"},
			 {"AOA", "True"},
			 {"AOAText", ""},
			 {"LevelUp","True"}
		};
			                   
        // Define SelectedOption property
        public string SelectedOptionInit
		{
			get => _selectedOptionInit;
			set
			{
				_selectedOptionInit = value;

				OnPropertyChanged(nameof(SelectedOptionInit));
				DisplaySelectedOptionName();
			}
		}

		// Define SelectedOptionName property
		public string SelectedOptionNameInit
		{
			get => _selectedOptionNameInit;
			set
			{
				_selectedOptionNameInit = value;
				OnPropertyChanged(nameof(SelectedOptionNameInit));
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
				SelectedOptionNameInit = root.GetProperty($"{SelectedOptionInit}" + OptionSuffix[SelectedOptionInit]).GetString();
			}
			catch (Exception ex)
			{
				SelectedOptionNameInit = $"Error: {ex.Message}";
			}
		}
	}
}
