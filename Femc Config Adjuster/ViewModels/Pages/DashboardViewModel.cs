using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using Femc_Config_Adjuster.Helpers;
using Femc_Config_Adjuster.Views.Pages;
using Femc_Config_Adjuster.Views.Windows;
using Wpf.Ui.Controls;

namespace Femc_Config_Adjuster.ViewModels.Pages
{
    public partial class DashboardViewModel : ObservableObject
	{
        private DashboardPage _mainWindow;
        private Config _config;
		private string _selectedOptionInit;
		private string _selectedOptionNameInit;
		// Define Options array
		public string[] OptionsInit { get; } = { "Bustup", "AOA", "AOAText", "LevelUp", "Shard", "Cutin"};
		public ObservableCollection<string> optionchoose { get; } = new ObservableCollection<string> {"Hello"};

        Dictionary<string, Tuple<string, List<string>>> OptionComboSuffix =
			 new Dictionary<string,Tuple<string,List<string>>>(){
			 //Entry format {"Option Name", new Tuple<string, List<string>>("Suffix in json file, [Enter all possible options in this list])}
			 {"Bustup",new Tuple<string, List<string>>("True",["Neptune","Ely","Esa","Betina","Anniversary","JustBlue","Sav","Doodled","RonaldReagan","ElyAlt"])},
			 {"AOA", new Tuple<string,List<string>>("True",["Ely","Chrysanthie","Fernando","Monica","RonaldReagan"])},
			 {"AOAText", new Tuple<string, List<string>>("",["DontLookBack","SorryBoutThat"])},
			 {"LevelUp", new Tuple<string, List<string>>("True",["Esa","Ely"])},
			 {"Shard", new Tuple<string, List<string>>("True",["Esa","Ely"])},
			 {"Cutin", new Tuple<string, List<string>>("True",["berrycha","ElyandPatmandx"])}
		};
			                   
        // Define SelectedOption property
        public string SelectedOptionInit
		{
			get => _selectedOptionInit;
			set
			{
				_selectedOptionInit = value;
				UpdateSelectionCombo();
				OnPropertyChanged(nameof(SelectedOptionInit));   
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

		public DashboardViewModel(DashboardPage mainWindow)
		{
			LoadConfig();
			LoadJsonFile();
            _mainWindow = mainWindow;
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

        private void UpdateSelectionCombo()
		{
			try
			{
                optionchoose.Clear();
				foreach (var item in OptionComboSuffix[SelectedOptionInit].Item2)
				{
					optionchoose.Add(item);
				}
                // Parse JSON content to find selected option name
                var jsonDocument = JsonDocument.Parse(JsonContent);
                var root = jsonDocument.RootElement;
                // Adjust path and property name as per your JSON structure
                string SelectedOptionInConf = root.GetProperty($"{SelectedOptionInit}" + OptionComboSuffix[SelectedOptionInit].Item1).GetString();
                _mainWindow.ChangeValue.SelectedIndex = _mainWindow.ChangeValue.Items.IndexOf(SelectedOptionInConf);
            }
			catch (Exception ex)
			{
				//Left Blank Temporarily while i figure out a more refined way of showing error messages
			}
            }
		}
	}