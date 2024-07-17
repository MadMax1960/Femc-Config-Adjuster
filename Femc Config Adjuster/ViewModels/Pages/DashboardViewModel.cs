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
using System.Windows.Media.Imaging;
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
		private Uri socialurl = new Uri("https://raw.githubusercontent.com/MadMax1960/Femc-Config-Adjuster/master/ui/Cutin/ElyandPatmandx.jpg", UriKind.Absolute);

        // Define Options array
        public string[] OptionsInit { get; } = { "Bustup", "AOA", "AOAText", "LevelUp", "Shard", "Cutin" };
		public ObservableCollection<string> optionchoose { get; } = new ObservableCollection<string> { "Please select a Category to Continue" };

		Dictionary<string, Tuple<string, List<string>>> OptionComboSuffix =
			 new Dictionary<string, Tuple<string, List<string>>>()
			 {
				 {"Bustup",new Tuple<string, List<string>>("True",new List<string>{"Neptune","Ely","Esa","Betina","Anniversary","JustBlue","Sav","Doodled","RonaldReagan","ElyAlt", "Yuunagi"})},
				 {"AOA", new Tuple<string,List<string>>("True",new List<string>{"Ely","Chrysanthie","Fernando","Monica","RonaldReagan"})},
				 {"AOAText", new Tuple<string, List<string>>("",new List<string>{"DontLookBack","SorryBoutThat"})},
				 {"LevelUp", new Tuple<string, List<string>>("True",new List<string>{"Esa","Ely"})},
				 {"Shard", new Tuple<string, List<string>>("True",new List<string>{"Esa","Ely"})},
				 {"Cutin", new Tuple<string, List<string>>("True",new List<string>{"berrycha","ElyandPatmandx"})}
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

		Dictionary<string, Tuple<string, string, string>> multimediadict = new Dictionary<string, Tuple<string, string, string>>()
		{
			//{Category+Author, new Tuple<string, string, string>("Description","Image URL", "Social Page URL (LEAVE BLANK IF NONE)")}
			{"BustupEly",new Tuple<string, string, string>("This was made by @Ely", "https://github.com/MadMax1960/Femc-Config-Adjuster/blob/master/ui/bustup/Screenshot_305.png?raw=true", "https://github.com/MadMax1960/Femc-Reloaded-Project")},
			{"BustupNeptune",new Tuple< string, string, string >("This was made by @Neptune_NPN013", "https://github.com/MadMax1960/Femc-Config-Adjuster/blob/master/ui/bustup/Screenshot_304.png?raw=true", "https://github.com/MadMax1960/Femc-Reloaded-Project")},
			{"BustupEsa",new Tuple< string, string, string >("This was made by @EsaBlythe", "https://github.com/MadMax1960/Femc-Config-Adjuster/blob/master/ui/bustup/Screenshot_306.png?raw=true", "https://github.com/MadMax1960/Femc-Reloaded-Project")},
			{"BustupBetina",new Tuple<string, string, string>("This was made by @Betina_Mascenon", "https://github.com/MadMax1960/Femc-Config-Adjuster/blob/master/ui/bustup/betina.png?raw=true", "https://github.com/MadMax1960/Femc-Reloaded-Project")},
			{"BustupAnniversary",new Tuple< string, string, string >("Official P25 Art edited by @EsaBlythe", "https://github.com/MadMax1960/Femc-Config-Adjuster/blob/master/ui/bustup/anniversary.png?raw=true", "https://github.com/MadMax1960/Femc-Reloaded-Project")},
			{"BustupJustBlue",new Tuple< string, string, string >("This was made by justblueowo", "https://github.com/MadMax1960/Femc-Config-Adjuster/blob/master/ui/bustup/just%20blue.png?raw=true", "https://github.com/MadMax1960/Femc-Reloaded-Project")},
			{"BustupSav",new Tuple< string, string, string >("This was made by @fugoluv3r", "https://github.com/MadMax1960/Femc-Config-Adjuster/blob/master/ui/bustup/sav.png?raw=true", "https://github.com/MadMax1960/Femc-Reloaded-Project")},
			{"BustupDoodled",new Tuple< string, string, string >("This was made by @NotDoodled", "https://github.com/MadMax1960/Femc-Config-Adjuster/blob/master/ui/bustup/doodled.png?raw=true", "https://github.com/MadMax1960/Femc-Reloaded-Project")},
			{"BustupRonaldReagan",new Tuple< string, string, string >("This was made by @CatboyRonReagan", "https://github.com/MadMax1960/Femc-Config-Adjuster/blob/master/ui/bustup/ronaldreagen.png?raw=true", "https://github.com/MadMax1960/Femc-Reloaded-Project")},
			{"BustupElyAlt",new Tuple< string, string, string >("This was made by Ely", "https://github.com/MadMax1960/Femc-Config-Adjuster/blob/master/ui/bustup/elyalt.png?raw=true", "https://github.com/MadMax1960/Femc-Reloaded-Project")},
			{"BustupYuunagi",new Tuple< string, string, string >("This was made by Yuunagi", "https://github.com/MadMax1960/Femc-Config-Adjuster/blob/master/ui/bustup/Yuunagi.png?raw=true", "https://github.com/MadMax1960/Femc-Reloaded-Project")},
			{"AOAEly",new Tuple< string, string, string >("Dummy Description", "https://raw.githubusercontent.com/MadMax1960/Femc-Reloaded-Project/main/img/readmelogo.png", "https://github.com/MadMax1960/Femc-Reloaded-Project")},
			{"AOAChrysanthie",new Tuple< string, string, string >("Dummy Description", "https://raw.githubusercontent.com/MadMax1960/Femc-Reloaded-Project/main/img/readmelogo.png", "https://github.com/MadMax1960/Femc-Reloaded-Project")},
			{"AOAFernando",new Tuple< string, string, string >("Dummy Description", "https://raw.githubusercontent.com/MadMax1960/Femc-Reloaded-Project/main/img/readmelogo.png", "https://github.com/MadMax1960/Femc-Reloaded-Project")},
			{"AOAMonica",new Tuple< string, string, string >("Dummy Description", "https://raw.githubusercontent.com/MadMax1960/Femc-Reloaded-Project/main/img/readmelogo.png", "https://github.com/MadMax1960/Femc-Reloaded-Project")},
			{"AOARonaldReagan",new Tuple< string, string, string >("Dummy Description", "https://raw.githubusercontent.com/MadMax1960/Femc-Reloaded-Project/main/img/readmelogo.png", "https://github.com/MadMax1960/Femc-Reloaded-Project")},
			{"AOATextDontLookBack",new Tuple< string, string, string >("Dummy Description", "https://raw.githubusercontent.com/MadMax1960/Femc-Reloaded-Project/main/img/readmelogo.png", "https://github.com/MadMax1960/Femc-Reloaded-Project")},
			{"AOATextSorryBoutThat",new Tuple< string, string, string >("Dummy Description", "https://raw.githubusercontent.com/MadMax1960/Femc-Reloaded-Project/main/img/readmelogo.png", "https://github.com/MadMax1960/Femc-Reloaded-Project")},
			{"LevelUpEsa",new Tuple< string, string, string >("Dummy Description", "https://raw.githubusercontent.com/MadMax1960/Femc-Reloaded-Project/main/img/readmelogo.png", "https://github.com/MadMax1960/Femc-Reloaded-Project")},
			{"LevelUpEly",new Tuple< string, string, string >("Dummy Description", "https://raw.githubusercontent.com/MadMax1960/Femc-Reloaded-Project/main/img/readmelogo.png", "https://github.com/MadMax1960/Femc-Reloaded-Project")},
			{"ShardEsa",new Tuple< string, string, string >("Dummy Description", "https://raw.githubusercontent.com/MadMax1960/Femc-Reloaded-Project/main/img/readmelogo.png", "https://github.com/MadMax1960/Femc-Reloaded-Project")},
			{"ShardEly",new Tuple< string, string, string >("Dummy Description", "https://raw.githubusercontent.com/MadMax1960/Femc-Reloaded-Project/main/img/readmelogo.png", "https://github.com/MadMax1960/Femc-Reloaded-Project")},
			{"Cutinberrycha",new Tuple< string, string, string >("Dummy Description", "https://raw.githubusercontent.com/MadMax1960/Femc-Reloaded-Project/main/img/readmelogo.png","")},
			{"CutinElyandPatmandx",new Tuple< string, string, string >("This Cutin was made by @Ely and @PatManDx", "https://raw.githubusercontent.com/MadMax1960/Femc-Config-Adjuster/master/ui/Cutin/ElyandPatmandx.jpg", "https://github.com/MadMax1960/Femc-Reloaded-Project")},
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

        public void OnSocialButtonPress()
        {
			// Handle button press
            Process.Start(new ProcessStartInfo(socialurl.AbsoluteUri) { UseShellExecute = true });
        }

        public string SelectedOptionChoose
		{
			get => _selectedOptionChoose;
			set
			{
				_selectedOptionChoose = value;
				OnPropertyChanged(nameof(SelectedOptionChoose));
				UpdateSelectionDetails();
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
					valram[item.Key] = OptionComboSuffix[suffrem].Item2[0];
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
				_mainWindow.ChangeValue.SelectedIndex = _mainWindow.ChangeValue.Items.IndexOf(valram[SelectedOptionInit + OptionComboSuffix[SelectedOptionInit].Item1]);
				UpdateSelectionDetails();
			}
			catch (Exception ex)
			{
				// Handle exception
				Debug.WriteLine($"UpdateSelectionCombo Error: {ex.Message}");
			}
		}

		private void UpdateSelectionDetails()
		{
			try
			{
				if (SelectedOptionChoose != null)
				{
					if (CheckOptionExistance(SelectedOptionChoose))
					{
						valram[SelectedOptionInit + OptionComboSuffix[SelectedOptionInit].Item1] = SelectedOptionChoose;
						SelectedOptionNameInit = multimediadict[SelectedOptionInit + SelectedOptionChoose].Item1;
						_mainWindow.descimage.Source = new BitmapImage(new Uri(multimediadict[SelectedOptionInit + SelectedOptionChoose].Item2));
						if((multimediadict[SelectedOptionInit + SelectedOptionChoose].Item3 == "")){
							_mainWindow.social.Visibility = Visibility.Hidden;

                        }
						else
						{
							_mainWindow.social.Visibility = Visibility.Visible;
                            socialurl = new Uri(multimediadict[SelectedOptionInit + SelectedOptionChoose].Item3, UriKind.Absolute);
                        }
                    }
				}
			}
			catch (Exception ex)
			{
				// Handle exception
				Debug.WriteLine($"UpdateSelectionDetails Error: {ex.Message}");
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
	}
}
