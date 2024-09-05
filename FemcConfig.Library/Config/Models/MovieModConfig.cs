using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;

namespace FemcConfig.Library.Config.Models;

/// <summary>
/// Should match Config.cs from FEMC mod:
/// https://github.com/MadMax1960/Femc-Reloaded-Project/blob/main/code/p3rpc.femc/p3rpc.femc/Config.cs
/// </summary>
public partial class MovieModConfig : ObservableObject
{
    [Description("View this movie on startup?")]
    [Category("Intro")]
    [DefaultValue(false)]
    [ObservableProperty]
    private bool p3p = true;

    [Description("View this movie on startup?")]
    [DefaultValue(true)]
    [Category("Intro")]
    [ObservableProperty]
    private bool p3pk = true;

    [Description("View this movie on startup?")]
    [DefaultValue(false)]
    [Category("Intro")]
    [ObservableProperty]
    private bool soulmosq = true;

    [Category("Intro")]
    [Description("View this movie on startup?")]
    [DefaultValue(true)]
    [ObservableProperty]
    private bool epag = true;
}