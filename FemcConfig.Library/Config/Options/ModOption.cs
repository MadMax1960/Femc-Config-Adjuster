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
