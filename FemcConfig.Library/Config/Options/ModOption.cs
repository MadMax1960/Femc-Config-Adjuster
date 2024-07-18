using CommunityToolkit.Mvvm.ComponentModel;

namespace FemcConfig.Library.Config.Options;

/// <summary>
/// Mod option.
/// </summary>
public class ModOption : ObservableObject
{
    private readonly ModContext modContext;

    public ModOption(ModContext ctx)
    {
        modContext = ctx;

        // Update IsEnabled state when mod config changes.
        modContext.ModConfig.PropertyChanged += (sender, args) =>
        {
            OnPropertyChanged(nameof(IsEnabled));
        };
    }

    /// <summary>
    /// Name of option.
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Description of option.
    /// </summary>
    public string Description { get; init; } = string.Empty;

    /// <summary>
    /// Authors of option.
    /// </summary>
    public Author[] Authors { get; init; } = [];

    /// <summary>
    /// Func that determines if the option is enabled.
    /// </summary>
    public required Func<ModContext, bool> IsEnabledFunc { get; init; }

    /// <summary>
    /// Enable action, typically just sets a value in the config.
    /// </summary>
    public required Action<ModContext> Enable { get; init; }

    /// <summary>
    /// Disable action, maybe useful for more advanced options?
    /// </summary>
    public Action<ModContext>? Disable { get; init; }

    public bool IsEnabled
    {
        get => IsEnabledFunc(modContext);
        set
        {
            if (value)
            {
                Enable(modContext);
            }
            else
            {
                Disable?.Invoke(modContext);
            }
        }
    }
}
