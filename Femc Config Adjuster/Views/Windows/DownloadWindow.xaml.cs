using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text.Json;
using Wpf.Ui.Controls;
using System.Diagnostics;
using System.Windows;
using System;

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
            System.Windows.MessageBox.Show($"Initialization Error: {ex.Message}");
        }
    }

    private void DownloadButton_Clicked(object sender, RoutedEventArgs e)
    {
        if (Version.Text != "Unable to fetch the latest version.")
        {
            GetLatestRelease7zUrl();
            System.Windows.MessageBox.Show("Mod Download initiated. Once the download is complete click on the Close button to proceed.");
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

    /// <summary>
    /// Downloads the latest release ZIP file from a GitHub repository.
    /// </summary>
    public static async void GetLatestRelease7zUrl()
    {
        try
        {
            // Get the latest release info from GitHub
            var releaseInfo = await GetLatestReleaseInfo();

            // Find the first ZIP asset from the release's assets
            var firstZipAsset = releaseInfo.Assets.FirstOrDefault(a => a.Name.EndsWith("7z"));
            if (firstZipAsset == null)
            {
                throw new Exception("No 7z file found in the latest release.");
            }

            // Downloads the file using the r2 protocol
            var proc = new Process() { StartInfo = new ProcessStartInfo() { FileName = $"r2:{firstZipAsset.DownloadUrl}", UseShellExecute = true } };
            proc.Start();
        }
        catch (Exception ex)
        {
            System.Windows.MessageBox.Show($"Failed to get 7z URL: {ex.Message}");
            App.Current.Shutdown();
        }
    }


    /// <summary>
    /// Gets the version (tag) of the latest release from a GitHub repository.
    /// </summary>
    /// <returns>The tag name of the latest release.</returns>
    public static async Task<string> GetLatestVersionTag()
    {
        var releaseInfo = await GetLatestReleaseInfo();
        return "Github Download Version: "+releaseInfo.TagName ?? "Unable to fetch the latest version.";
    }
    
    /// <summary>
    /// Fetches the latest release information from the GitHub API.
    /// </summary>
    /// <returns>The latest release information.</returns>
    private static async Task<ReleaseInfo> GetLatestReleaseInfo()
    {
        string apiUrl = $"https://api.github.com/repos/{_owner}/{_repo}/releases/latest";

        // Ensure only one User-Agent header is added
        if (!client.DefaultRequestHeaders.UserAgent.Any())
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppName/1.0");
        }

        try
        {
            // Fetch the latest release info from GitHub
            var response = await client.GetAsync(apiUrl).ConfigureAwait(false);

            // Handle API errors gracefully
            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                var remaining = response.Headers.TryGetValues("X-RateLimit-Remaining", out var values)
                    ? values.FirstOrDefault()
                    : "0";
                throw new Exception($"API rate limit exceeded. Remaining: {remaining}");
            }

            response.EnsureSuccessStatusCode(); // Throw if the request failed

            // Read and deserialize the response body
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