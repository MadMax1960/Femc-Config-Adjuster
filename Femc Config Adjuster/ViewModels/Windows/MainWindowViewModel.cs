﻿// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Wpf.Ui.Controls;

namespace Femc_Config_Adjuster.ViewModels.Windows
{
	public partial class MainWindowViewModel : ObservableObject
	{
		[ObservableProperty]
		private string _applicationTitle = "WPF UI - Femc_Config_Adjuster";

		[ObservableProperty]
		private ObservableCollection<object> _menuItems = new()
		{
			new NavigationViewItem()
			{
				Content = "2D",
				Icon = new SymbolIcon { Symbol = SymbolRegular.PaintBrush16 },
				TargetPageType = typeof(Views.Pages.DashboardPage)
			},
			new NavigationViewItem()
			{
				Content = "Music",
				Icon = new SymbolIcon { Symbol = SymbolRegular.MusicNote120 },
				TargetPageType = typeof(Views.Pages.DataPage)
			}
        };

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
	}
}
