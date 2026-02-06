// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using CommunityToolkit.Mvvm.ComponentModel;
using Femc_Config_Adjuster.Views.Pages;
using System.Collections.ObjectModel;
using Wpf.Ui.Controls;
using FemcConfig.Localisation.LocalisationResources;

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
			Content = Resources.Settings,
			Icon = new SymbolIcon { Symbol = SymbolRegular.Settings24 },
			TargetPageType = typeof(Views.Pages.SettingsPage),
            ToolTip = Resources.Settings
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
            Content = Resources.Home,
            Icon = new SymbolIcon { Symbol = SymbolRegular.Home16 },
            TargetPageType = typeof(Views.Pages.Categories.Category_Main),
            ToolTip = Resources.Home
        },
        new NavigationViewItem()
        {
            Content = "2D",
            Icon = new SymbolIcon { Symbol = SymbolRegular.PaintBrush16 },
            TargetPageType = typeof(Views.Pages.Categories.Category_2D),
            ToolTip = "2D"
        },
        new NavigationViewItem()
        {
            Content = "3D",
            Icon = new SymbolIcon { Symbol = SymbolRegular.Cube16 },
            TargetPageType = typeof(Views.Pages.Categories.Category_3D),
            ToolTip = "3D"
        },
        new NavigationViewItem()
        {
            Content = Resources.Audio,
            Icon = new SymbolIcon { Symbol = SymbolRegular.Speaker216 },
			TargetPageType = typeof(Views.Pages.Categories.Category_Audio),
            ToolTip = Resources.Audio
        },
        new NavigationViewItem()
        {
            Content = Resources.Music,
            Icon = new SymbolIcon { Symbol = SymbolRegular.Speaker216 },
            TargetPageType = typeof(Views.Pages.Categories.Category_Music),
            ToolTip = Resources.Music
        },
        new NavigationViewItem()
		{
            Content = Resources.Theo,
            Icon = new SymbolIcon { Symbol = SymbolRegular.PlayingCards20 },
			TargetPageType = typeof(Views.Pages.Categories.Category_Theo),
            ToolTip = Resources.Theo
        },
        new NavigationViewItem()
        {
            Content = string.IsNullOrEmpty(Resources.Misc)
            ? Resources.ResourceManager.GetString("Misc", System.Globalization.CultureInfo.InvariantCulture) ?? string.Empty
            : Resources.Misc,
            Icon = new SymbolIcon { Symbol = SymbolRegular.Library16 },
            TargetPageType = typeof(Views.Pages.Categories.Category_Misc),
            ToolTip = Resources.Misc
        },
        new NavigationViewItem()
        {
            Content = Resources.UI,
            Icon = new SymbolIcon { Symbol = SymbolRegular.Color16},
            TargetPageType = typeof(UiPage),
            ToolTip = Resources.UI
        },
    ];
}
