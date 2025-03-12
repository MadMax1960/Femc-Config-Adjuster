// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using CommunityToolkit.Mvvm.ComponentModel;
using Femc_Config_Adjuster.Views.Pages;
using System.Collections.ObjectModel;
using Wpf.Ui.Controls;
using Femc_Config_Adjuster.LocalisationResources;

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
            Content = Resources.Home,
            Icon = new SymbolIcon { Symbol = SymbolRegular.Home16 },
            TargetPageType = typeof(Views.Pages.Categories.Category_Main),
        },
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
            Content = Resources.Audio,
            Icon = new SymbolIcon { Symbol = SymbolRegular.Speaker216 },
			TargetPageType = typeof(Views.Pages.Categories.Category_Audio),
        },
		new NavigationViewItem()
		{
            Content = "Theo",
            Icon = new SymbolIcon { Symbol = SymbolRegular.PlayingCards20 },
			TargetPageType = typeof(Views.Pages.Categories.Category_Theo),
        },
        new NavigationViewItem()
        {
            Content = Resources.UI,
            Icon = new SymbolIcon { Symbol = SymbolRegular.Color16},
            TargetPageType = typeof(UiPage),
        },
    ];
}
