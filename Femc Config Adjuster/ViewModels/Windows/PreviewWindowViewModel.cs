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
            // Direct workaround: Load the actual YouTube video page instead of the embed player.
            // This bypasses the "Error 153" restriction by treating the view like a standard browser.
            this.YoutubeEmbedUrl = this.YoutubeUrl;
            this.UseWebView = true;
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
