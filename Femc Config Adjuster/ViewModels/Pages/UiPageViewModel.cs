using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DynamicData.Binding;
using FemcConfig.Library.Config;
using FemcConfig.Library.Config.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows.Data;
using System.Windows;
using FemcConfig.Library.Utils;
using Microsoft.Win32;
using System.Collections.Generic;

namespace Femc_Config_Adjuster.ViewModels.Pages;

public partial class UiPageViewModel : ObservableObject
{
    private readonly SavableFile<FemcModConfig> config;
    private readonly Dictionary<string, ConfigColor> defaults = [];
    private readonly Subject<string> searchChanges = new();
    private readonly ObservableCollection<UiOption> options = new();
    private readonly PropertyInfo[] colorProperties;

    [ObservableProperty]
    private string searchQuery = string.Empty;

    private IDisposable? _colorObsSub;

    public UiPageViewModel(AppService app)
    {
        this.config = app.GetContext().FemcConfig;

        //this.Options =
        //[
        //    new(nameof(this.config.MailIconOuterCircleColorEx), this.config.MailIconOuterCircleColorEx),
        //    new(nameof(this.config.MailIconInnerCircleColorEx), this.config.MailIconInnerCircleColorEx),
        //    new(nameof(this.config.CampHighColor), this.config.CampHighColor),
        //    new(nameof(this.config.CampHighColorGradation), this.config.CampHighColorGradation),
        //    new(nameof(this.config.CampMiddleColor), this.config.CampMiddleColor),
        //    new(nameof(this.config.CampLowColor), this.config.CampLowColor),
        //    new(nameof(this.config.DateTimePanelTopTextColor), this.config.DateTimePanelTopTextColor),
        //    new(nameof(this.config.DateTimePanelBottomTextColor), this.config.DateTimePanelBottomTextColor),
        //];

        var defaultConfig = new FemcModConfig();
        this.colorProperties = this.config.Settings.GetType()
            .GetProperties()
            .Where(x => x.PropertyType == typeof(ConfigColor))
            .ToArray();

        this.OptionsView = CollectionViewSource.GetDefaultView(this.options);
        this.OptionsView.Filter = FilterOptions;

        foreach (var prop in this.colorProperties)
        {
            this.defaults[prop.Name] = (ConfigColor)prop.GetValue(defaultConfig)!;
        }

        LoadOptionsAsync();

        this.searchChanges
            .Throttle(TimeSpan.FromMilliseconds(200))
            .ObserveOn(DispatcherScheduler.Current)
            .Subscribe(_ => this.OptionsView.Refresh());
    }

    public ICollectionView OptionsView { get; }

    [RelayCommand]
    private void Reset()
    {
        var isKiwami = this.SearchQuery.Equals("kiwami", StringComparison.OrdinalIgnoreCase);
        var collection = isKiwami ? this.OptionsView.SourceCollection : this.OptionsView;

        foreach (var item in collection)
        {
            if (item is UiOption option)
            {
                option.Color = isKiwami ? ConfigColor.Green : this.defaults[option.Name];
            }
        }
    }

    [RelayCommand]
    private void Export()
    {
        var dialog = new SaveFileDialog
        {
            Title = "Export UI Colors",
            Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
            FileName = "FemcUiColors.json"
        };

        if (dialog.ShowDialog() != true)
        {
            return;
        }

        try
        {
            var exportData = new Dictionary<string, ConfigColor>();
            foreach (var prop in this.colorProperties)
            {
                if (prop.GetValue(this.config.Settings) is ConfigColor color)
                {
                    exportData[prop.Name] = new ConfigColor(color.R, color.G, color.B, color.A);
                }
            }

            JsonUtils.SerializeFile(exportData, dialog.FileName);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Failed to export UI colors.\n{ex.Message}",
                "Export Failed",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
    }

    [RelayCommand]
    private void Import()
    {
        var dialog = new OpenFileDialog
        {
            Title = "Import UI Colors",
            Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*"
        };

        if (dialog.ShowDialog() != true)
        {
            return;
        }

        try
        {
            var importData = JsonUtils.DeserializeFile<Dictionary<string, ConfigColor>>(dialog.FileName);
            var appliedAny = false;

            foreach (var item in this.OptionsView.SourceCollection)
            {
                if (item is UiOption option && importData.TryGetValue(option.Name, out var color))
                {
                    option.Color = new ConfigColor(color.R, color.G, color.B, color.A);
                    appliedAny = true;
                }
            }

            if (!appliedAny)
            {
                MessageBox.Show(
                    "No matching UI colors were found in the selected file.",
                    "Import UI Colors",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Failed to import UI colors.\n{ex.Message}",
                "Import Failed",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
    }


    private bool FilterOptions(object? obj)
    {
        if (obj is not UiOption option)
            return true;

        var query = this.SearchQuery;
        if (string.IsNullOrWhiteSpace(query))
            return true;

        return option.Name.Contains(query, StringComparison.OrdinalIgnoreCase);
    }

    partial void OnSearchQueryChanged(string value)
    {
        this.searchChanges.OnNext(value);
    }

    private void LoadOptionsAsync()
    {
        _colorObsSub?.Dispose();
        _ = Task.Run(async () =>
        {
            var colorsObs = new List<IObservable<UiOption>>();
            await Application.Current.Dispatcher.InvokeAsync(() => this.options.Clear());

            foreach (var prop in this.colorProperties)
            {
                var option = new UiOption(prop.Name, (ConfigColor)prop.GetValue(config.Settings)!);

                colorsObs.Add(option.WhenAnyPropertyChanged()!);

                await Application.Current.Dispatcher.InvokeAsync(() => this.options.Add(option));
                await Task.Delay(1);
            }

            _colorObsSub = colorsObs.Merge()
                .Throttle(TimeSpan.FromMilliseconds(250))
                .Subscribe(_ => config.Save());
        });
    }
}

public class UiOption : ObservableObject
{
    private readonly ConfigColor _color;

    public UiOption(string name, ConfigColor color)
    {
        this.Name = name;
        _color = color;
    }

    public string Name { get; }

    public ConfigColor Color
    {
        get => _color;
        set
        {
            if (_color.A == value.A &&
                _color.R == value.R &&
                _color.G == value.G &&
                _color.B == value.B)
            {
                return;
            }

            _color.A = value.A;
            _color.R = value.R;
            _color.G = value.G;
            _color.B = value.B;

            this.OnPropertyChanged(nameof(Color));
        }
    }
}