using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FemcConfig.Library.Config;
using FemcConfig.Library.Config.Sections;
using System.Collections.ObjectModel;

namespace Femc_Config_Adjuster.ViewModels.Pages;

public partial class DashboardViewModel : ObservableObject
{
    private readonly AppService appService;

    public DashboardViewModel(AppService appService)
    {
        this.appService = appService;

        var sectionType = typeof(ISection);
        var sectionTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => sectionType.IsAssignableFrom(x) && x.IsClass)
            .ToArray();

        var sections = new List<ISection>();
        foreach (var section in sectionTypes)
        {
            var instance = (ISection)Activator.CreateInstance(section, appService)!;
            sections.Add(instance);
        }

        this.Sections = new(sections);
    }

    public ObservableCollection<ISection> Sections { get; }

    [RelayCommand]
    public void Save()
    {
        try
        {
            this.appService.SaveConfig();
        }
        catch (Exception)
        {
            // TODO: Display an error message.
        }
    }
}
