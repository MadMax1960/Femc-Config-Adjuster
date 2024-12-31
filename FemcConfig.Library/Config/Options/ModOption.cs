using CommunityToolkit.Mvvm.ComponentModel;
using FemcConfig.Library.Config.Models;

namespace FemcConfig.Library.Config.Options;

/// <summary>
/// Mod option.
/// </summary>
public class ModOption : ObservableObject
{
    private readonly AppContext ctx;

    public ModOption(AppContext ctx)
    {
        this.ctx = ctx;

        // Update IsEnabled state when mod config changes.
        this.ctx.FemcConfig.Settings.PropertyChanged += (sender, args) =>
        {
            OnPropertyChanged(nameof(IsEnabled));
        };

        // Update IsEnabled state when mod config changes.
        if (this.ctx.MovieConfig != null)
        {
            this.ctx.MovieConfig.Settings.PropertyChanged += (sender, args) =>
            {
                OnPropertyChanged(nameof(IsEnabled));
            };
        }

        this.ctx.ReloadedAppConfig.Settings.EnabledMods.CollectionChanged += (sender, args) =>
        {
            OnPropertyChanged(nameof(IsEnabled));
        };
    }

    /// <summary>
    /// The internal name used to find local files.
    /// Maybe something like: APP_FOLDER/assets/INTERNAL_NAME/image.png
    /// </summary>
    public required string InternalName { get; init; }

    /// <summary>
    /// Minimum version of the femc mod required for this option to appear. Allows you to release an update for the app without dooming users to having a broken config. For example "1.7.0".
    /// </summary>
    public string? MinVersion { get; init; }

    /// <summary>
    /// Name of option.
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    /// Description of option.
    /// </summary>
    public string Description { get; init; } = string.Empty;
    
    /// <summary>
    /// Category of option.
    /// </summary>
    public string Category { get; init; } = string.Empty;

    /// <summary>
    /// Download URL of option, if not included with FEMC.
    /// </summary>
    public string? DownloadUrl { get; init; }

    /// <summary>
    /// Owner of the github repo from where the release is to be downloaded. For example: MadMax1960 in https://github.com/MadMax1960/Femc-Reloaded-Project.
    /// </summary>
    public string? GithubOwner { get; init; }

    /// <summary>
    /// Name of the github repo from where the release is to be downloaded. For example: Femc-Reloaded-Project in https://github.com/MadMax1960/Femc-Reloaded-Project.
    /// </summary>
    public string? GithubName { get; init; }

    /// <summary>
    /// Name of the 7z file you want to search for. This option is ONLY REQUIRED for the GithubReloadedDirectDL protocol. For example: UnrealEssentials in UnrealEssentials1.1.5.7z.
    /// </summary>
    public string? Regex { get; init; }

    /// <summary>
    /// Download handler for download URL.
    /// </summary>
    public DownloadHandler Downloader { get; init; } = DownloadHandler.Reloaded;

    /// <summary>
    /// Authors of option.
    /// </summary>
    public required Author[] Authors { get; init; }

    /// <summary>
    /// Func that determines if the option is enabled.
    /// </summary>
    public required Func<AppContext, bool> IsEnabledFunc { get; init; }

    /// <summary>
    /// Enable action, typically just sets a value in the config.
    /// </summary>
    public required Action<AppContext> Enable { get; init; }

    /// <summary>
    /// Disable action, maybe useful for more advanced options?
    /// </summary>
    public Action<AppContext>? Disable { get; init; }

    public bool IsEnabled
    {
        get => IsEnabledFunc(this.ctx);
        set
        {
            if (value)
            {
                Enable(this.ctx);
            }
            else
            {
                Disable?.Invoke(this.ctx);
            }
        }
    }
}
