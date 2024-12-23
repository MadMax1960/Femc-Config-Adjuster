// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

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
    public const string APP_VERSION = "1.3.0"; // Should always be update after every update and needs to match the release tagname.
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

    /// <summary>
    /// Occurs when the application is loading.
    /// </summary>
    private void OnStartup(object sender, StartupEventArgs e)
    {
        _host.Start();

        // Check for updates
        var updateChecker = GetService<UpdateChecker>();
        _ = updateChecker?.CheckForUpdatesAsync(APP_VERSION);
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

/// <summary>
/// A class to check for updates from the latest GitHub release.
/// </summary>
public class UpdateChecker
{
	private const string GitHubApiUrl = "https://api.github.com/repos/MadMax1960/Femc-Config-Adjuster/releases/latest";
	private const string DownloadDirectory = "Updates";

	/// <summary>
	/// Checks the latest GitHub release and compares it with the current version.
	/// </summary>
	/// <param name="currentVersion">The current application version.</param>
	public async Task CheckForUpdatesAsync(string currentVersion)
	{
		try
		{
			using HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Add("User-Agent", "FemcConfigAdjuster");

			var response = await client.GetAsync(GitHubApiUrl);
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				var release = JsonSerializer.Deserialize<GitHubRelease>(content);

				if (release != null && IsNewerVersion(release.tag_name, currentVersion))
				{
					var promptWin = new PromptWindow(
						title: "Update Available",
						content: $"A new version ({release.tag_name}) is available. Would you like to update?"
					);
					promptWin.ShowDialog();

					if (promptWin.Result)
					{
						// Pass the PromptWindow instance to show progress updates
						await DownloadAndApplyUpdate(release.assets_url, promptWin);
					}
					else
					{
						var infoWin = new InfoWindow(
							"Update Skipped",
							"You can update later from the settings or when the application restarts."
						);
						infoWin.ShowDialog();
					}
				}
			}
		}
		catch (Exception ex)
		{
			Log.Error(ex, "Failed to check for updates.");
			var infoWin = new InfoWindow("Update Error", "An error occurred while checking for updates.");
			infoWin.ShowDialog();
		}
	}

	/// <summary>
	/// Downloads and applies the update.
	/// </summary>
	/// <param name="assetsUrl">The URL to the release assets.</param>
	private async Task DownloadAndApplyUpdate(string assetsUrl, PromptWindow promptWindow)
	{
		try
		{
			using HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Add("User-Agent", "FemcConfigAdjuster");

			// Fetch asset information
			var response = await client.GetAsync(assetsUrl);
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				var assets = JsonSerializer.Deserialize<List<GitHubAsset>>(content);

				var zipAsset = assets?.FirstOrDefault(asset => asset.name.EndsWith(".zip", StringComparison.OrdinalIgnoreCase));
				if (zipAsset == null)
				{
					throw new Exception("No valid update file found in the release assets.");
				}

				string downloadPath = Path.Combine(Directory.GetCurrentDirectory(), DownloadDirectory);
				Directory.CreateDirectory(downloadPath);
				string zipFilePath = Path.Combine(downloadPath, zipAsset.name);

				using (var downloadStream = await client.GetStreamAsync(zipAsset.browser_download_url))
				using (var fileStream = new FileStream(zipFilePath, FileMode.Create, FileAccess.Write))
				{
					var buffer = new byte[8192];
					int bytesRead;
					long totalBytesRead = 0;
					var totalBytes = Convert.ToInt64(response.Content.Headers.ContentLength);

					while ((bytesRead = await downloadStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
					{
						await fileStream.WriteAsync(buffer, 0, bytesRead);
						totalBytesRead += bytesRead;

						double progress = (double)totalBytesRead / totalBytes * 100;
						promptWindow.UpdateProgress(progress);
					}
				}

				string extractPath = Path.Combine(downloadPath, "Extracted");
				if (Directory.Exists(extractPath))
					Directory.Delete(extractPath, true);
				System.IO.Compression.ZipFile.ExtractToDirectory(zipFilePath, extractPath);

				ApplyUpdateFromExtractedFiles(extractPath);
			}
		}
		catch (Exception ex)
		{
			Log.Error(ex, "Failed to download or apply the update.");
			var errorWin = new InfoWindow("Update Error", $"An error occurred while applying the update: {ex.Message}");
			errorWin.ShowDialog();
		}
	}

	/// <summary>
	/// Applies the update by launching the new version and scheduling deletion of the old one.
	/// </summary>
	/// <param name="extractedPath">The path to the extracted files.</param>
	private void ApplyUpdateFromExtractedFiles(string extractedPath)
	{
		string currentDirectory = Directory.GetCurrentDirectory();
		string newFolderPath = Path.Combine(Directory.GetParent(currentDirectory)?.FullName ?? currentDirectory, "FemcConfigAdjuster_New");
		string newExePath = Path.Combine(newFolderPath, "Femc Config Adjuster.exe");

		try
		{
			// Move extracted files to the new folder
			if (Directory.Exists(newFolderPath))
				Directory.Delete(newFolderPath, true);

			Directory.CreateDirectory(newFolderPath);
			foreach (var file in Directory.GetFiles(extractedPath, "*", SearchOption.AllDirectories))
			{
				var relativePath = Path.GetRelativePath(extractedPath, file);
				var destinationPath = Path.Combine(newFolderPath, relativePath);

				var destinationDir = Path.GetDirectoryName(destinationPath);
				if (!Directory.Exists(destinationDir))
					Directory.CreateDirectory(destinationDir);

				File.Copy(file, destinationPath, true);
			}

			// Launch the new executable
			if (File.Exists(newExePath))
			{
				System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
				{
					FileName = newExePath,
					UseShellExecute = true
				});

				// Schedule deletion of the old version
				DeleteOldVersion(currentDirectory);
				Application.Current.Shutdown();
			}
			else
			{
				throw new FileNotFoundException($"The main executable was not found in the new version's folder: {newExePath}");
			}
		}
		catch (Exception ex)
		{
			Log.Error(ex, "Failed to apply the update.");
			var errorWin = new InfoWindow("Update Error", $"An error occurred: {ex.Message}");
			errorWin.ShowDialog();
		}
	}

	/// <summary>
	/// Deletes the old application folder after launching the new version.
	/// </summary>
	/// <param name="oldFolderPath">Path to the old folder.</param>
	private void DeleteOldVersion(string oldFolderPath)
	{
		try
		{
			var deleteScript = Path.Combine(Directory.GetParent(oldFolderPath)?.FullName ?? oldFolderPath, "delete_old.bat");

			var batchContent = $@"
                    @echo off
                    timeout /t 2 > nul
                    rmdir /s /q ""{oldFolderPath}""
                    del ""%~f0""
                ";

			File.WriteAllText(deleteScript, batchContent);

			System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
			{
				FileName = deleteScript,
				UseShellExecute = true
			});
		}
		catch (Exception ex)
		{
			Log.Error(ex, "Failed to schedule deletion of the old version.");
		}
	}

	/// <summary>
	/// Compares the latest version with the current version.
	/// </summary>
	private bool IsNewerVersion(string latestVersion, string currentVersion)
	{
		Version latest = new Version(latestVersion.TrimStart('v'));
		Version current = new Version(currentVersion);
		return latest > current;
	}

	/// <summary>
	/// Represents the structure of a GitHub release.
	/// </summary>
	private class GitHubRelease
	{
		public string tag_name { get; set; } = string.Empty;
		public string assets_url { get; set; } = string.Empty;
	}

	/// <summary>
	/// Represents a GitHub release asset.
	/// </summary>
	private class GitHubAsset
	{
		public string name { get; set; } = string.Empty;
		public string browser_download_url { get; set; } = string.Empty;
	}
}