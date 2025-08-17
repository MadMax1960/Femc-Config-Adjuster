using Femc_Config_Adjuster.Helpers;
using FemcConfig.Library.Config.Options;
using System.Windows;

namespace Femc_Config_Adjuster.ViewModels.Windows;

internal class PreviewWindowViewModel
{
    public PreviewWindowViewModel(ModOption option)
    {
        this.Option = option;
        this.Title = option.Name ?? string.Join(", ", option.Authors.Select(x => x.Name));
        this.ImagePath = ResourceUtils.GetOptionImagePath(option, true);
        this.YoutubeUrl = ResourceUtils.GetOptionYoutubeUrl(option);
        this.Category = option.Category;
        if (!string.IsNullOrEmpty(this.YoutubeUrl) && 
    Environment.OSVersion.Platform == PlatformID.Win32NT)
{
    if (Uri.TryCreate(this.YoutubeUrl, UriKind.Absolute, out var uri))
    {
        string? youtubeId = null;
        if (uri.Host.Contains("youtube.com", StringComparison.OrdinalIgnoreCase))
        {
            var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
            youtubeId = query["v"];
        }
        else if (uri.Host.Contains("youtu.be", StringComparison.OrdinalIgnoreCase))
        {
            youtubeId = uri.AbsolutePath.Trim('/'); 
        }

        if (!string.IsNullOrEmpty(youtubeId))
        {
            this.YoutubeEmbedUrl = $"https://www.youtube.com/embed/{youtubeId}";
            this.UseWebView = true;
        }
    }
}
    }

    public ModOption Option { get; }

    public string Title { get; }

    public string ImagePath { get; }

    public string? YoutubeUrl { get; }

    public string? YoutubeEmbedUrl { get; }

    public bool UseWebView { get; }

    public string? Category { get; }
}
