using FemcConfig.Library.Config.Options;

namespace Femc_Config_Adjuster.ViewModels.Components;

public class OptionsGalleryViewModel
{
    public OptionsGalleryViewModel(IEnumerable<ModOption> options)
    {
        this.Options = options.Select(x => new OptionViewModel(x)).ToArray();
    }

    public OptionViewModel[] Options { get; }
}
