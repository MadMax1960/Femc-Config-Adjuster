using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace FemcConfig.Library.Config.Models;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public partial class ReloadedAppConfig : ObservableObject
{
    [ObservableProperty]
    private string appId;

    [ObservableProperty]
    private string appName;

    [ObservableProperty]
    private string appLocation;

    [ObservableProperty]
    private string appArguments;

    [ObservableProperty]
    private string appIcon;

    [ObservableProperty]
    private bool autoInject;

    [ObservableProperty]
    private ObservableCollection<string> enabledMods;

    [ObservableProperty]
    private string workingDirectory;

    [ObservableProperty]
    private Dictionary<string, Dictionary<string, int>> pluginData;

    [ObservableProperty]
    private List<string> sortedMods;

    [ObservableProperty]
    private bool preserveDisabledModOrder;

    [ObservableProperty]
    private bool dontInject;

    [ObservableProperty]
    private bool isMsStore;
}