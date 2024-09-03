using CommunityToolkit.Mvvm.ComponentModel;
using DynamicData.Binding;
using FemcConfig.Library.Config;
using FemcConfig.Library.Config.Models;
using System.Reactive.Linq;

namespace Femc_Config_Adjuster.ViewModels.Pages;

public class UiPageViewModel
{
    private readonly SavableFile<FemcModConfig> config;

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

        var options = new List<UiOption>();

        var colorProps = this.config.Settings.GetType().GetProperties().Where(x => x.PropertyType == typeof(ConfigColor));
        foreach (var prop in colorProps)
        {
            var option = new UiOption(prop.Name, (ConfigColor)prop.GetValue(this.config.Settings)!);
            options.Add(option);

            //option.PropertyChanged += (sender, args) => app.GetContext().FemcConfig.Save();
            option.WhenAnyPropertyChanged().Skip(1).Throttle(TimeSpan.FromMilliseconds(250)).Subscribe(_ => this.config.Save());
        }

        this.Options = options.ToArray();
    }

    public UiOption[] Options { get; }
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
            _color.A = value.A;
            _color.R = value.R;
            _color.G = value.G;
            _color.B = value.B;

            this.OnPropertyChanged(nameof(Color));
        }
    }
}
