// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using Femc_Config_Adjuster.Properties;
using Femc_Config_Adjuster.Services;
using Femc_Config_Adjuster.ViewModels.Pages;
using Femc_Config_Adjuster.ViewModels.Windows;
using Femc_Config_Adjuster.Views.Windows;
using FemcConfig.Library.Config;
using FemcConfig.Library.Config.Sections;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Windows;
using System.Windows.Threading;
using Wpf.Ui;

namespace Femc_Config_Adjuster;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    // The.NET Generic Host provides dependency injection, configuration, logging, and other services.
    // https://docs.microsoft.com/dotnet/core/extensions/generic-host
    // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
    // https://docs.microsoft.com/dotnet/core/extensions/configuration
    // https://docs.microsoft.com/dotnet/core/extensions/logging
    public const string APP_VERSION = "1.3.5"; // Should always be update after every update and needs to match the release tagname.
    private static readonly IHost _host = Host
        .CreateDefaultBuilder()
        .ConfigureAppConfiguration(c =>
        {
            c.SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!);
        })
        .ConfigureServices((context, services) =>
        {
            services.AddHostedService<ApplicationHostService>();

            // Page resolver service
            services.AddSingleton<IPageService, PageService>();

            // Theme manipulation
            services.AddSingleton<IThemeService, ThemeService>();

            // TaskBar manipulation
            services.AddSingleton<ITaskBarService, TaskBarService>();

            // Service containing navigation, same as INavigationWindow... but without window
            services.AddSingleton<INavigationService, NavigationService>();

            // Main window with navigation
            services.AddSingleton<INavigationWindow, MainWindow>();
            services.AddSingleton<MainWindowViewModel>();

            // Auto-register pages.
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsClass);
            foreach (var type in types)
            {
                if (type.Namespace?.StartsWith("Femc_Config_Adjuster.Views.Pages") == true)
                {
                    services.AddSingleton(type);
                }
            }

            services.AddSingleton<SettingsViewModel>();
            services.AddSingleton<UiPageViewModel>();

            // FEMC config library.
            services.AddSingleton<AppService>();

            // Register setting sections.
            services.AddSingleton(s =>
            {
                var app = s.GetRequiredService<AppService>();

                var sectionType = typeof(ISection);
                var sectionTypes = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(x => x.GetTypes())
                    .Where(x => sectionType.IsAssignableFrom(x) && x.IsClass)
                    .ToArray();

                var sections = new List<ISection>();
                foreach (var section in sectionTypes)
                {
                    var instance = (ISection)Activator.CreateInstance(section, app)!;
                    sections.Add(instance);
                }

                return sections.ToArray();
            });

            // Register UpdateChecker
            services.AddSingleton<UpdateChecker>();
        }).Build();

    /// <summary>
    /// Gets registered service.
    /// </summary>
    /// <typeparam name="T">Type of the service to get.</typeparam>
    /// <returns>Instance of the service or <see langword="null"/>.</returns>
    public static T GetService<T>()
        where T : class
    {
        return (_host.Services.GetService(typeof(T)) as T)!;
    }

    private void SetupCulture()
    {
        string setCulture = Settings.Default.SelectedLanguage;
        if (new List<string>{"ja", "en-US", "zh-CN", "ru", "pl", "es"}.Contains(setCulture))
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.SelectedLanguage);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Settings.Default.SelectedLanguage);

        }
        else
        {
            Settings.Default.SelectedLanguage = "en-US";
            Settings.Default.Save();
            SetupCulture();
        }
    }

    /// <summary>
    /// Occurs when the application is loading.
    /// </summary>
    private void OnStartup(object sender, StartupEventArgs e)
    {
        SetupCulture();
        _host.Start();
        // Check for updates
        if (!Debugger.IsAttached)
        {
            var updateChecker = GetService<UpdateChecker>();
            _ = updateChecker?.CheckForUpdatesAsync(APP_VERSION);
        }
	}

    /// <summary>
    /// Occurs when the application is closing.
    /// </summary>
    private async void OnExit(object sender, ExitEventArgs e)
    {
        await _host.StopAsync();
        _host.Dispose();
    }

    /// <summary>
    /// Occurs when an exception is thrown by an application but not handled.
    /// </summary>
    private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        // For more info see https://docs.microsoft.com/en-us/dotnet/api/system.windows.application.dispatcherunhandledexception?view=windowsdesktop-6.0
        Log.Error(e.Exception, e.Exception.Message);

        var exceptionWin = new ExceptionWindow(e.Exception);
        exceptionWin.Show();
    }
}
