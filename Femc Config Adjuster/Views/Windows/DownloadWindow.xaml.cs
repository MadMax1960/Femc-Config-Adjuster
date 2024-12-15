using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text.Json;
using Wpf.Ui.Controls;
using System.Diagnostics;
using System.Windows;
using System.Text.RegularExpressions;

namespace Femc_Config_Adjuster.Views.Windows;

/// <summary>
/// Interaction logic for DownloadWindow.xaml
/// </summary>
public partial class DownloadWindow : FluentWindow
{
    public DownloadWindow()
    {
        InitializeComponent();
        InitializeAsync();
    }

    private async void InitializeAsync()
    {
        try
        {
            Version.Text = "Fetching version...";
            var versionTag = await GetLatestVersionTag();
            Version.Text = versionTag;            
            if (Version.Text != "Unable to fetch the latest version.")
            {
                DownloadButton.Visibility = Visibility.Visible;
            }
        }
        catch (Exception ex)
        {
            var infoWin = new InfoWindow("Initialization Error",ex.Message);
            infoWin.ShowDialog();
        }
    }

    private void DownloadButton_Clicked(object sender, RoutedEventArgs e)
    {
        if (Version.Text != "Unable to fetch the latest version.")
        {
            GithubR2Direct7z(_owner,_repo,null);
            var infoWin = new InfoWindow("Mod Download Initiated", "The mod information has been beamed over to Reloaded-II and your download has begun. Once the download is complete click on the Close button and then restart the app.");
            infoWin.ShowDialog();
        }
    }
    
    private void Exit_Clicked(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private static readonly HttpClient client = new HttpClient()
    {
        Timeout = TimeSpan.FromSeconds(30) // Set timeout to avoid hanging indefinitely
    };
    static string _owner = "MadMax1960";
    static string _repo = "Femc-Reloaded-Project";

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
                    FileName = $"r2:{matchingAsset.DownloadUrl}",
                    UseShellExecute = true
                }
            };
            proc.Start();
        }
        catch (Exception ex)
        {
            var infoWin = new InfoWindow(
                "Failed to get 7z URL",
                "The app was unable to fetch the release info of this mod. Please try again later or try installing the mod manually.",
                "Installation Failed"
            );
            infoWin.ShowDialog();
        }
    }


    /// <summary>
    /// Gets the version (tag) of the latest release from a GitHub repository.
    /// </summary>
    /// <returns>The tag name of the latest release.</returns>
    public static async Task<string> GetLatestVersionTag()
    {
        var releaseInfo = await GetLatestReleaseInfo(_owner, _repo);
        return "Github Download Version: "+releaseInfo.TagName ?? "Unable to fetch the latest version.";
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

    // Helper class to deserialize release info
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

}