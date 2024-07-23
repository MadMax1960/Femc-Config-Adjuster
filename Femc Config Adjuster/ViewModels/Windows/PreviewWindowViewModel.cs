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
    }

    public ModOption Option { get; }

    public string Title { get; }

    public string ImagePath { get; }
}
