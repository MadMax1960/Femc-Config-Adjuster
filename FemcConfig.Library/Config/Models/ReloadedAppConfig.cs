using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FemcConfig.Library.Config.Models;
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
    private List<string> enabledMods;

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