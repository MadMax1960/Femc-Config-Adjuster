using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DynamicData.Binding;
using FemcConfig.Library.Config;
using FemcConfig.Library.Config.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows.Data;
using System.Windows;

namespace Femc_Config_Adjuster.ViewModels.Pages;

public partial class UiPageViewModel : ObservableObject
{
    private readonly SavableFile<FemcModConfig> config;
    private readonly Dictionary<string, ConfigColor> defaults = [];
    private readonly Subject<string> searchChanges = new();

    [ObservableProperty]
    private string searchQuery = string.Empty;

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
        var optionCollection = new ObservableCollection<UiOption>();
        this.OptionsView = CollectionViewSource.GetDefaultView(optionCollection);
        this.OptionsView.Filter = FilterOptions;

        var colorProps = this.config.Settings.GetType()
            .GetProperties()
            .Where(x => x.PropertyType == typeof(ConfigColor))
            .ToArray();

        foreach (var prop in colorProps)
        {
            this.defaults[prop.Name] = (ConfigColor)prop.GetValue(defaultConfig)!;
        }

        LoadOptionsAsync(optionCollection, colorProps);

        this.searchChanges
            .Throttle(TimeSpan.FromMilliseconds(200))
            .ObserveOn(DispatcherScheduler.Current)
            .Subscribe(_ => this.OptionsView.Refresh());
    }

    public ICollectionView OptionsView { get; }

    [RelayCommand]
    private void Reset()
    {
        foreach (var item in this.OptionsView)
        {
            if (item is UiOption option)
            {
                option.Color = this.defaults[option.Name];
            }
        }

        this.config.Save();
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

    private void LoadOptionsAsync(ObservableCollection<UiOption> optionCollection, IEnumerable<PropertyInfo> colorProps)
    {
        _ = Task.Run(async () =>
        {
            foreach (var prop in colorProps)
            {
                var option = new UiOption(prop.Name, (ConfigColor)prop.GetValue(this.config.Settings)!);

                option.WhenAnyPropertyChanged()
                    .Skip(1)
                    .Throttle(TimeSpan.FromMilliseconds(250))
                    .Subscribe(_ => this.config.Save());

                await Application.Current.Dispatcher.InvokeAsync(() => optionCollection.Add(option));
                await Task.Delay(1);
            }
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