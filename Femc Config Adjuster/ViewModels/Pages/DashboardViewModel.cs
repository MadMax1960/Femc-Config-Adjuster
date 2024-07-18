using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FemcConfig.Library.Config;
using FemcConfig.Library.Config.Options;

namespace Femc_Config_Adjuster.ViewModels.Pages;

public partial class DashboardViewModel : ObservableObject
{
    private readonly ConfigService configService;

    public DashboardViewModel(ConfigService configService)
    {
        this.configService = configService;
    }

    public List<ModOption> Booleans => this.configService.BoolSettings;


    [RelayCommand]
    public void Save()
    {
        try
        {
            this.configService.SaveConfig();
        }
        catch (Exception)
        {
            // TODO: Display an error message.
        }
    }
}
