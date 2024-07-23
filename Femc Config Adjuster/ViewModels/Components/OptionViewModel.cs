using CommunityToolkit.Mvvm.ComponentModel;
using Femc_Config_Adjuster.Helpers;
using FemcConfig.Library.Config.Options;

namespace Femc_Config_Adjuster.ViewModels.Components;

public partial class OptionViewModel : ObservableObject
{
    public OptionViewModel(ModOption option)
    {
        this.Option = option;
        this.ThumbnailPath = ResourceUtils.GetOptionImagePath(option, false);
        this.UseYoutubePreview = ResourceUtils.GetOptionYoutubeUrl(option) != null;
    }

    public ModOption Option { get; }

    public string ThumbnailPath { get; }

    public bool UseYoutubePreview { get; }
}
