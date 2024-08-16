// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using CommunityToolkit.Mvvm.ComponentModel;
using FemcConfig.Library.Config;
using FemcConfig.Library.Utils;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Automation;
using Wpf.Ui.Controls;
using FemcConfig.Library.Utils;
using FemcConfig.Library.Config.Models;

namespace Femc_Config_Adjuster.ViewModels.Windows;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
	private string _applicationTitle = "FEMC Config";

	[ObservableProperty]
	private ObservableCollection<object> _footerMenuItems = new()
	{
		new NavigationViewItem()
		{
			Content = "Settings",
			Icon = new SymbolIcon { Symbol = SymbolRegular.Settings24 },
			TargetPageType = typeof(Views.Pages.SettingsPage)
		}
	};

	[ObservableProperty]
	private ObservableCollection<MenuItem> _trayMenuItems = new()
	{
		new MenuItem { Header = "Home", Tag = "tray_home" }
    };

    public NavigationViewItem[] MenuItems { get; } =
    [
        new NavigationViewItem()
        {
            Content = "2D",
            Icon = new SymbolIcon { Symbol = SymbolRegular.PaintBrush16 },
            TargetPageType = typeof(Views.Pages.Categories.Category_2D),
        },
        new NavigationViewItem()
        {
            Content = "3D",
            Icon = new SymbolIcon { Symbol = SymbolRegular.Cube16 },
            TargetPageType = typeof(Views.Pages.Categories.Category_3D),
        },
        new NavigationViewItem()
        {
            Content = "Audio",
            Icon = new SymbolIcon { Symbol = SymbolRegular.Speaker216 },
            TargetPageType = typeof(Views.Pages.Categories.Category_Audio),
        },
        new NavigationViewItem()
        {
            Content = "Movie",
            Icon = new SymbolIcon { Symbol = SymbolRegular.MoviesAndTv16},
            Visibility=(CheckModExistence("Persona_3_Reload_Intro_Movies")) ? Visibility.Visible :  Visibility.Collapsed,
            TargetPageType = typeof(Views.Pages.Categories.Category_Movie),
        },
        new NavigationViewItem()
        {
            Content = "Addons",
            Icon = new SymbolIcon { Symbol = SymbolRegular.Library28},
            TargetPageType = typeof(Views.Pages.Categories.Category_Addon),
        },
    ];
    private static bool CheckModExistence(string id)
    {
        return JsonUtils.DeserializeFile<EnabledModConfiguration>(Path.Join(Path.GetDirectoryName(Environment.GetEnvironmentVariable("RELOADEDIIMODS"))!, "Apps", "p3r.exe", "AppConfig.json")).EnabledMods.Contains(id) ? true : false;
    }
    public class EnabledModConfiguration
    {
        public List<string> EnabledMods { get; set; }
    }

}
