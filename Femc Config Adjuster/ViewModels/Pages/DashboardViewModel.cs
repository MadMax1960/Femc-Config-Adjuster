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
using Femc_Config_Adjuster.Helpers;
using Femc_Config_Adjuster.Views.Pages;
using Femc_Config_Adjuster.Views.Windows;
using Wpf.Ui.Controls;

namespace Femc_Config_Adjuster.ViewModels.Pages
{
    public partial class DashboardViewModel : ObservableObject
	{
		string urllocal = "https://raw.githubusercontent.com/MadMax1960/Femc-Config-Adjuster/master/pc007_08_top01_ShC.png";
        private DashboardPage _mainWindow;
        private Config _config;
		private string _selectedOptionChoose;
		private string _selectedOptionInit;
		private string _selectedOptionNameInit;
        private ICommand _buttonPressCommand;
        //public ObservableCollection<string> Url = new ObservableCollection<string> { "https://raw.githubusercontent.com/MadMax1960/Femc-Config-Adjuster/master/pc007_08_top01_ShC.png" };
        public ObservableCollection<Uri> selurl=new ObservableCollection<Uri> { new Uri("https://raw.githubusercontent.com/MadMax1960/Femc-Config-Adjuster/master/pc007_08_top01_ShC.png",UriKind.Absolute)};
        public Uri Url
        {
            get
            {
                return new Uri(urllocal, UriKind.Absolute);
            }
        }

        public ICommand ButtonPressCommand
        {
            get => _buttonPressCommand;
            set
            {
                _buttonPressCommand = value;
                OnPropertyChanged();
            }
        }

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
            GenValRam();
			SelectedOptionNameInit = _config.JsonFilePath;
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
					}
				}
			}
		}
		
			private bool CheckOptionExistance(string opt) { 
			foreach(KeyValuePair<string, Tuple<string, List<string>>> item in OptionComboSuffix)
			{
                foreach (var iteminlist in OptionComboSuffix[SelectedOptionInit].Item2)
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
			foreach(KeyValuePair<string,string> item in valram)
			{
                var jsonDocument = JsonDocument.Parse(JsonContent);
                var root = jsonDocument.RootElement;
                string SelectedOptionInConf = root.GetProperty(item.Key).GetString();
                valram[item.Key] = SelectedOptionInConf;
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
			jsonObject["AOATrue"] = "TestVal";
            string modifiedJsonString = jsonObject.ToJsonString(new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_config.JsonFilePath, modifiedJsonString);
        }

        private void UpdateSelectionCombo()
		{
			try
			{
                selurl = new ObservableCollection<Uri> { new Uri("https://raw.githubusercontent.com/MadMax1960/Femc-Reloaded-Project/main/img/readmelogo.png", UriKind.Absolute) };
                optionchoose.Clear();
				foreach (var item in OptionComboSuffix[SelectedOptionInit].Item2)
				{
					optionchoose.Add(item);
				}
                _mainWindow.ChangeValue.SelectedIndex = _mainWindow.ChangeValue.Items.IndexOf(valram[(SelectedOptionInit+OptionComboSuffix[SelectedOptionInit].Item1).ToString()]);
				SelectedOptionNameInit = valram[SelectedOptionInit + OptionComboSuffix[SelectedOptionInit].Item1];
            }
			catch (Exception ex)
			{
				//Left Blank Temporarily while i figure out a more refined way of showing error messages
			}
            }
		}
	}