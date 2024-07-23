using Femc_Config_Adjuster.Helpers;
using FemcConfig.Library.Config.Options;

namespace Femc_Config_Adjuster.ViewModels.Windows;

internal class PreviewWindowViewModel
{
    public PreviewWindowViewModel(ModOption option)
    {
        this.Option = option;
        this.Title = option.Name ?? string.Join(", ", option.Authors.Select(x => x.Name));
        this.ImagePath = ResourceUtils.GetOptionImagePath(option, true);
        this.YoutubeUrl = ResourceUtils.GetOptionYoutubeUrl(option);

        if (this.YoutubeUrl != null && Environment.OSVersion.Platform == PlatformID.Win32NT)
        {
            var youtubeId = this.YoutubeUrl.Split("watch?v=")[1];
            this.YoutubeEmbedUrl = $@"https://www.youtube.com/embed/{youtubeId}";
            this.UseWebView = true;
        }
    }

    public ModOption Option { get; }

    public string Title { get; }

    public string ImagePath { get; }

    public string? YoutubeUrl { get; }

    public string? YoutubeEmbedUrl { get; }

    public bool UseWebView { get; }
}
