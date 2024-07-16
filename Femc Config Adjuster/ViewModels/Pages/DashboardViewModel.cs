using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Femc_Config_Adjuster.Helpers;
using Femc_Config_Adjuster.Views.Pages;
using Femc_Config_Adjuster.Views.Windows;
using Wpf.Ui.Controls;
using MessageBox = System.Windows.MessageBox;

namespace Femc_Config_Adjuster.ViewModels.Pages
{
	public partial class DashboardViewModel : ObservableObject
	{
		private DashboardPage _mainWindow;
		private Config _config;
		private string _selectedOptionChoose;
		private string _selectedOptionInit;
		private string _selectedOptionNameInit;
		private ICommand _buttonPressCommand;

		// Define Options array
		public string[] OptionsInit { get; } = { "Bustup", "AOA", "AOAText", "LevelUp", "Shard", "Cutin" };
		public ObservableCollection<string> optionchoose { get; } = new ObservableCollection<string> { "Please select a Category to Continue" };

		Dictionary<string, Tuple<string, List<string>>> OptionComboSuffix =
			 new Dictionary<string, Tuple<string, List<string>>>(){
             //Entry format {"Option Name", new Tuple<string, List<string>>("Suffix in json file, [Enter all possible options in this list])}
             {"Bustup",new Tuple<string, List<string>>("True",["Neptune","Ely","Esa","Betina","Anniversary","JustBlue","Sav","Doodled","RonaldReagan","ElyAlt"])},
			 {"AOA", new Tuple<string,List<string>>("True",["Ely","Chrysanthie","Fernando","Monica","RonaldReagan"])},
			 {"AOAText", new Tuple<string, List<string>>("",["DontLookBack","SorryBoutThat"])},
			 {"LevelUp", new Tuple<string, List<string>>("True",["Esa","Ely"])},
			 {"Shard", new Tuple<string, List<string>>("True",["Esa","Ely"])},
			 {"Cutin", new Tuple<string, List<string>>("True",["berrycha","ElyandPatmandx"])}
		};

		Dictionary<string, string> valram = new Dictionary<string, string>()
		{
			{"BustupTrue",""},
			{"AOATrue",""},
			{"AOAText",""},
			{"LevelUpTrue",""},
			{"ShardTrue",""},
			{"CutinTrue",""}
		};

		// Define SelectedOption property
		public string SelectedOptionInit
		{
			get => _selectedOptionInit;
			set
			{
				_selectedOptionInit = value;
				OnPropertyChanged(nameof(SelectedOptionInit));
				UpdateSelectionCombo();
			}
		}

		public void OnSaveButtonPress()
		{
			// Handle button press
			WriteValRam();
		}

		public string SelectedOptionChoose
		{
			get => _selectedOptionChoose;
			set
			{
				_selectedOptionChoose = value;
				OnPropertyChanged(nameof(SelectedOptionChoose));
				if (SelectedOptionChoose != null)
				{
					if (CheckOptionExistance(SelectedOptionChoose))
					{
						valram[(SelectedOptionInit + OptionComboSuffix[SelectedOptionInit].Item1).ToString()] = SelectedOptionChoose;
						SelectedOptionNameInit = valram[SelectedOptionInit + OptionComboSuffix[SelectedOptionInit].Item1];
					}
				}
			}
		}

		private bool CheckOptionExistance(string opt)
		{
			foreach (KeyValuePair<string, Tuple<string, List<string>>> item in OptionComboSuffix)
			{
				foreach (var iteminlist in OptionComboSuffix[item.Key].Item2)
				{
					if (iteminlist == opt)
					{
						return true;
					}
				}
			}
			return false;

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
			GenValRam();
			// Set the default selected option to "Bustup"
			SelectedOptionInit = "Bustup";
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

		private void GenValRam()
		{
			foreach (KeyValuePair<string, string> item in valram)
			{
				var jsonDocument = JsonDocument.Parse(JsonContent);
				var root = jsonDocument.RootElement;
				string SelectedOptionInConf = root.GetProperty(item.Key).GetString();
				if (CheckOptionExistance(SelectedOptionInConf))
				{
					valram[item.Key] = SelectedOptionInConf;
				}
				else
				{
					string suffrem = item.Key.Replace("True", "");
					valram[item.Key] = OptionComboSuffix[suffrem].Item2[1];
				}
			}
		}

		private void WriteValRam()
		{
			string jsonString = File.ReadAllText(_config.JsonFilePath);
			JsonNode jsonObject = JsonNode.Parse(jsonString);
			foreach (KeyValuePair<string, string> item in valram)
			{
				jsonObject[item.Key.ToString()] = item.Value.ToString();
			}
			string modifiedJsonString = jsonObject.ToJsonString(new JsonSerializerOptions { WriteIndented = true });
			File.WriteAllText(_config.JsonFilePath, modifiedJsonString);
			MessageBox.Show("Game added and JSON data saved!");
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
				if (SelectedOptionInit is null)
				{
					optionchoose.Add("Generation of Options failed. Please contact Mudkip for help");
					_mainWindow.ChangeValue.SelectedIndex = _mainWindow.ChangeValue.Items.IndexOf("Generation of Options failed. Please contact Mudkip for help");
				}
				else
				{
					_mainWindow.ChangeValue.SelectedIndex = _mainWindow.ChangeValue.Items.IndexOf(valram[(SelectedOptionInit + OptionComboSuffix[SelectedOptionInit].Item1).ToString()]);
				}
				SelectedOptionNameInit = valram[SelectedOptionInit + OptionComboSuffix[SelectedOptionInit].Item1];
			}
			catch (Exception ex)
			{
				// Left Blank Temporarily while I figure out a more refined way of showing error messages
			}
		}
	}
}
