﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using Femc_Config_Adjuster.Views.Windows;
using Serilog;

namespace Femc_Config_Adjuster
{
	/// <summary>
	/// A class to check for updates from the latest GitHub release and apply them.
	/// </summary>
	public class UpdateChecker
	{
		private const string GitHubApiUrl = "https://api.github.com/repos/MadMax1960/Femc-Config-Adjuster/releases/latest";
		private const string DownloadDirectory = "Updates";

		/// <summary>
		/// Checks the latest GitHub release and compares it with the current version.
		/// </summary>
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
							title: FemcConfig.Localisation.LocalisationResources.Resources.Update_Notify_Title+release.tag_name,
							content: FemcConfig.Localisation.LocalisationResources.Resources.Update_Notify
						);
						promptWin.ShowDialog();

						if (promptWin.Result)
						{
							await DownloadAndApplyUpdate(release.assets_url, promptWin, release.tag_name);
						}
						else
						{
							var infoWin = new InfoWindow(
								FemcConfig.Localisation.LocalisationResources.Resources.Update_Later_Title,
								FemcConfig.Localisation.LocalisationResources.Resources.Update_Later
							);
							infoWin.ShowDialog();
						}
					}
				}
			}
			catch (Exception ex)
			{
				Log.Error(ex, "Failed to check for updates.");
				var infoWin = new InfoWindow("Update Error", FemcConfig.Localisation.LocalisationResources.Resources.Update_Check_Fail);
				infoWin.ShowDialog();
			}
		}

		private async Task DownloadAndApplyUpdate(string assetsUrl, PromptWindow promptWindow, string version)
		{
			try
			{
				using HttpClient client = new HttpClient();
				client.DefaultRequestHeaders.Add("User-Agent", "FemcConfigAdjuster");

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

					ApplyUpdateFromExtractedFiles(extractPath, version);
				}
			}
			catch (Exception ex)
			{
				Log.Error(ex, "Failed to download or apply the update.");
				var errorWin = new InfoWindow("Update Error", $"An error occurred while applying the update: {ex.Message}");
				errorWin.ShowDialog();
			}
		}

		private void ApplyUpdateFromExtractedFiles(string extractedPath, string version)
		{
			string currentDirectory = Directory.GetCurrentDirectory();
			string newFolderPath = Path.Combine(Directory.GetParent(currentDirectory)?.FullName ?? currentDirectory, $"FemcConfigAdjuster_{version}");
			string newExePath = Path.Combine(newFolderPath, "Femc Config Adjuster.exe");

			try
			{
				if (Directory.Exists(newFolderPath))
					Directory.Delete(newFolderPath, true);

				Directory.CreateDirectory(newFolderPath);
				foreach (var file in Directory.GetFiles(extractedPath, "*", SearchOption.AllDirectories))
				{
					var relativePath = Path.GetRelativePath(extractedPath, file);
					var destinationPath = Path.Combine(newFolderPath, relativePath);
					// dtissa
					var destinationDir = Path.GetDirectoryName(destinationPath);
					if (!Directory.Exists(destinationDir))
						Directory.CreateDirectory(destinationDir);

					File.Copy(file, destinationPath, true);
				}

				if (File.Exists(newExePath))
				{
					System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
					{
						FileName = newExePath,
						UseShellExecute = true
					});

					Application.Current.Shutdown();
				}
				else
				{
					throw new FileNotFoundException($"The main executable was not found in the new version's folder: \"{newExePath}\"");
				}
			}
			catch (Exception ex)
			{
				Log.Error(ex, "Failed to apply the update.");
				var errorWin = new InfoWindow("Update Error", $"An error occurred: {ex.Message}");
				errorWin.ShowDialog();
			}
		}


		private bool IsNewerVersion(string latestVersion, string currentVersion)
		{
			Version latest = new Version(latestVersion.TrimStart('v'));
			Version current = new Version(currentVersion);
			return latest > current;
		}

		private class GitHubRelease
		{
			public string tag_name { get; set; } = string.Empty;
			public string assets_url { get; set; } = string.Empty;
		}

		private class GitHubAsset
		{
			public string name { get; set; } = string.Empty;
			public string browser_download_url { get; set; } = string.Empty;
		}
	}
}
