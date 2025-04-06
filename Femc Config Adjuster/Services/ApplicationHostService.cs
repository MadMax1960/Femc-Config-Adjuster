// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using Femc_Config_Adjuster.Views.Windows;
using FemcConfig.Library.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.IO;
using System.Windows;
using Wpf.Ui;

namespace Femc_Config_Adjuster.Services;

/// <summary>
/// Managed host of the application.
/// </summary>
public class ApplicationHostService : IHostedService
{
	private readonly IServiceProvider _serviceProvider;
	private readonly AppService _app;

	private INavigationWindow? _navigationWindow;

	public ApplicationHostService(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;
		_app = _serviceProvider.GetRequiredService<AppService>();

        this.SetupLogger();
	}

    private void SetupLogger()
    {	
		var logFile = Path.Join(_app.AppDataDir, "log.txt");
		if (File.Exists(logFile))
		{
			File.Delete(logFile);
		}

        Log.Logger = new LoggerConfiguration()
            .WriteTo.File(logFile)
            .CreateLogger();
    }

    /// <summary>
    /// Triggered when the application host is ready to start the service.
    /// </summary>
    /// <param name="cancellationToken">Indicates that the start process has been aborted.</param>
    public async Task StartAsync(CancellationToken cancellationToken)
	{
		await HandleActivationAsync();
	}

    private void HandleInit()
    {
        try
        {
            // Verify context was set before
            // starting main window.
            _ = _app.GetContext();
            this.OpenMainWindow();
            CheckModCompatibility(_app);
        }
        catch (Exception)
        {
            var setupWindow = new SetupWindow(_app, this.OpenMainWindow);
            setupWindow.ShowDialog();
        }
    }

    public void CheckModCompatibility(AppService app)
    {
        var context = app.GetContext();
        if (context.FemcModVersion == "UNSUPPORTED")
        {
            var infoWin = new InfoWindow(FemcConfig.Localisation.LocalisationResources.Resources.Mod_Ver_Mismatch_Title, FemcConfig.Localisation.LocalisationResources.Resources.Mod_Ver_Mismatch);
            infoWin.ShowDialog();
        }
        else if (context.FemcModVersion == "404FILENOTFOUND")
        {
            var infoWin = new InfoWindow(FemcConfig.Localisation.LocalisationResources.Resources.Mod_Corrupt_Title, FemcConfig.Localisation.LocalisationResources.Resources.Mod_Corrupt);
            infoWin.ShowDialog();
        }
        else if (context.FemcModVersion == "NotExecError")
        {
            var infoWin = new InfoWindow(FemcConfig.Localisation.LocalisationResources.Resources.UnexpectedErr_Title, FemcConfig.Localisation.LocalisationResources.Resources.UnexpectedErr);
            infoWin.ShowDialog();
        }
    }

    /// <summary>
    /// Triggered when the application host is performing a graceful shutdown.
    /// </summary>
    /// <param name="cancellationToken">Indicates that the shutdown process should no longer be graceful.</param>
    public async Task StopAsync(CancellationToken cancellationToken)
	{
		await Task.CompletedTask;
	}

	/// <summary>
	/// Creates main window during activation.
	/// </summary>
	private async Task HandleActivationAsync()
	{
		if (!Application.Current.Windows.OfType<MainWindow>().Any())
		{
			this.HandleInit();
		}

		await Task.CompletedTask;
	}

	private void OpenMainWindow()
    {
        _navigationWindow = _serviceProvider.GetRequiredService<INavigationWindow>();

        _navigationWindow.ShowWindow();
        _navigationWindow.Navigate(typeof(Views.Pages.Categories.Category_Main));
    }
}
