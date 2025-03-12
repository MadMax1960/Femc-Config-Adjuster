using Femc_Config_Adjuster.ViewModels.Windows;
using FemcConfig.Library.Config.Models;
using Microsoft.Web.WebView2.Wpf;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Windows;
using Wpf.Ui.Controls;

namespace Femc_Config_Adjuster.Views.Windows;

/// <summary>
/// Interaction logic for PreviewWindow.xaml
/// </summary>
/// 


public partial class PreviewWindow : FluentWindow
{
    public PreviewWindow()
    {
        InitializeComponent();
    }

    private void Button_Confirm(object sender, RoutedEventArgs e)
    {
        if (this.DataContext is PreviewWindowViewModel vm)
        {
            vm.Option.IsEnabled = true;
        }

        this.Close();
    }

    private void Button_Close(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void Button_Download(object sender, RoutedEventArgs e)
    {
        // Mudkip this is the cue for u to add the actual installation of the mods
        if (this.DataContext is PreviewWindowViewModel vm)
        {
            if (vm.Option.DownloadUrl != null)
            {
                this.HandleDownloadUrl(vm.Option.DownloadUrl, vm.Option.Downloader, vm.Option.GithubOwner, vm.Option.GithubName, vm.Option.Regex);
            }
        }
    }

    private void HandleDownloadUrl(string url, DownloadHandler handler, string? githubowner, string? githubreponame, string? regex)
    {
        if (handler == DownloadHandler.Reloaded)
        {
            var proc = new Process() { StartInfo = new ProcessStartInfo() { FileName = "cmd.exe", Arguments = $"/c start r2:{url}", UseShellExecute = false, CreateNoWindow = true } };
            proc.Start();
        }
        else if (handler == DownloadHandler.Browser)
        {
            var proc = new Process() { StartInfo = new ProcessStartInfo() { FileName = url, UseShellExecute = true } };
            proc.Start();
        }
        
        // TODO: Download and install through app directly.
        else if (handler == DownloadHandler.Direct)
        {
            //var uri = new Uri(url);
            var proc = new Process() { StartInfo = new ProcessStartInfo() { FileName = url, UseShellExecute = true } };
            proc.Start();
        }

        else if (handler == DownloadHandler.GithubReloadedDirectDL)
        {
            if(githubowner  != null && githubreponame != null)
            {
                GithubR2Direct7z(githubowner, githubreponame, regex);
                var infoWin = new InfoWindow("Download Info", FemcConfig.Localisation.LocalisationResources.Resources.Mod_Download_Start);
                infoWin.ShowDialog();
            }
            else
            {
                var infoWin = new InfoWindow("Download Error", FemcConfig.Localisation.LocalisationResources.Resources.Mod_Download_Error);
                infoWin.ShowDialog();
            }
        }
    }



private static readonly HttpClient client = new HttpClient()
{
    Timeout = TimeSpan.FromSeconds(30) // Set timeout to avoid hanging indefinitely
};

public static async void GithubR2Direct7z(string owner, string repo, string? includereg)
{
    try
    {
        // Get the latest release info from GitHub
        var releaseInfo = await GetLatestReleaseInfo(owner, repo);

        var excludeToRegex = new Regex(@"_to_", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        Regex includeToRegex = null;
        if (!string.IsNullOrEmpty(includereg))
        {
            includeToRegex = new Regex(includereg, RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }
        var endsWith7zRegex = new Regex(@"\.7z$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        var matchingAsset = releaseInfo.Assets
        .FirstOrDefault(a => endsWith7zRegex.IsMatch(a.Name) && !excludeToRegex.IsMatch(a.Name) && (includeToRegex == null || includeToRegex.IsMatch(a.Name)));

        if (matchingAsset == null)
        {
            throw new Exception("No suitable 7z file found that meets the criteria.");
        }

        // Downloads the file using the r2 protocol
        var proc = new Process()
        {
            StartInfo = new ProcessStartInfo()
            {
                FileName = "cmd.exe",
                Arguments = $"/c start r2:{matchingAsset.DownloadUrl}",
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };
        proc.Start();
    }
    catch
    {
        var infoWin = new InfoWindow(
            "Failed to get 7z URL",
            FemcConfig.Localisation.LocalisationResources.Resources.ModInfoRetrievalFail,
            "Installation Failed"
        );
        infoWin.ShowDialog();
    }
}
private static async Task<ReleaseInfo> GetLatestReleaseInfo(string owner, string repo)
{
    string apiUrl = $"https://api.github.com/repos/{owner}/{repo}/releases/latest";

    if (!client.DefaultRequestHeaders.UserAgent.Any())
    {
        client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppName/1.0");
    }

    try
    {
        var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

        if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
        {
            var remaining = response.Headers.TryGetValues("X-RateLimit-Remaining", out var values)
                ? values.FirstOrDefault()
                : "0";
            throw new Exception($"API rate limit exceeded. Remaining: {remaining}");
        }

        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        return JsonSerializer.Deserialize<ReleaseInfo>(responseBody)
            ?? throw new Exception("Failed to deserialize release info.");
    }
    catch (TaskCanceledException)
    {
        throw new Exception("The request timed out. Please try again.");
    }
    catch (HttpRequestException ex)
    {
        throw new Exception($"Network error: {ex.Message}");
    }
    catch (Exception ex)
    {
        throw new Exception($"An unexpected error occurred: {ex.Message}");
    }
}

private class ReleaseInfo
{
    [JsonPropertyName("tag_name")]
    public string TagName { get; set; } = string.Empty;

    [JsonPropertyName("zipball_url")]
    public string ZipballUrl { get; set; } = string.Empty;

    [JsonPropertyName("assets")]
    public List<ReleaseAsset> Assets { get; set; } = new();
}
private class ReleaseAsset
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("browser_download_url")]
    public string DownloadUrl { get; set; } = string.Empty;
}

protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);

        if (this.webviewControl.Content is WebView2 webview)
        {
            webview.Dispose();
        }
    }    
}
