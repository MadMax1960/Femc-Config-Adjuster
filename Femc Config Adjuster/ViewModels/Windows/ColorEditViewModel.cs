using CommunityToolkit.Mvvm.ComponentModel;
using Femc_Config_Adjuster.ViewModels.Pages;
using FemcConfig.Library.Config.Models;

namespace Femc_Config_Adjuster.ViewModels.Windows;

internal class ColorEditViewModel(UiOption option) : ObservableObject
{
    private UiOption Option = option;
   
    public string Title => $"Edit {Name}";
    
    public string Name => Option.Name;

    public ConfigColor Color
    {
        get => Option.Color;
        set
        {
            Option.Color = value;
            OnPropertyChanged();
        }
    }
}